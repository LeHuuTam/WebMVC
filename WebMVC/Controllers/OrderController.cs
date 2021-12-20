using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Models.DAO;

namespace WebMVC.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var shipOfUser = new ShipDetailDao().CheckByUser(user.Id);
            if (!shipOfUser)
            {
                ViewBag.UserName = user.Name;
                ViewBag.Phone = user.Phone;
                ViewBag.Address = user.Address;
            }
            else
            {
                var shipDetail = new ShipDetailDao().GetByUser(user.Id)[0];
                ViewBag.UserName = shipDetail.ReceiverName;
                ViewBag.Phone = shipDetail.Phone;
                ViewBag.Address = shipDetail.Address;
            }
            var selectedCart = new CartDao().GetByUser(user.Id).Where(x => x.Selected == true).ToList();
            //var shipDetail = new ShipDetailDao().GetByUser(user.Id);
            ViewData["SelectedCart"] = selectedCart;
            //ViewData["shipDetail"] = shipDetail;
            return View();
        }
        [HttpPost]
        public ActionResult Create(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var user = (User)Session["user"];
                var shipOfUser = new ShipDetailDao().CheckByUser(user.Id);
                int shipDetailId, orderId;
                List<Product> proList = new List<Product>();
                var shipDetail = new ShipDetailDao().GetShipDetail(user.Id, model.ReceiverName, model.Phone, model.Address);
                if(shipDetail == null)
                {
                    var ship = new ShipDetail()
                    {
                        ReceiverName = model.ReceiverName,
                        Phone = model.Phone,
                        Address = model.Address,
                        User = user.Id,
                    };
                    var createShipDt = new ShipDetailDao().Create(ship, out shipDetailId);
                }
                else
                {
                    shipDetailId = shipDetail.Id;
                }
                var createOrder = new OrderDao().Create(user.Id, shipDetailId, model.Note, out orderId);
                var SelectedCart = new CartDao().GetSelected(user.Id);
                foreach (var cart in SelectedCart)
                {
                    proList.Add(cart.Product1);
                }
                var createProInorder = new ProductInOrderDao().Create(proList, orderId);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "đã có lỗi xảy ra");
                return View("Index");
            }
        }
    }
}