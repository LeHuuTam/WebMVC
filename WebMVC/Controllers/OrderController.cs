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
        [HttpGet]
        public ActionResult Index(int status)
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Status = status;
            var orderModelList = new List<OrderModel>();
            var orderList = new OrderDao().GetByStatus(user.Id, status);
            if (orderList.Count > 0)
            {
                foreach (var order in orderList)
                {
                    var proInOderList = new ProductInOrderDao().GetByOrder(order.Id);
                    var orderModel = new OrderModel()
                    {
                        Order = order,
                        ShipDetail = order.ShipDetail1,
                        ListProduct = proInOderList
                    };
                    orderModelList.Add(orderModel);
                }
            }
            return View(orderModelList);
        }
        public ActionResult Create()
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
                ViewBag.Province = user.Province;
                ViewBag.District = user.District;
            }
            else
            {
                var shipDetail = new ShipDetailDao().GetByUser(user.Id)[0];
                ViewBag.UserName = shipDetail.ReceiverName;
                ViewBag.Phone = shipDetail.Phone;
                ViewBag.Address = shipDetail.Address;
                ViewBag.Province = shipDetail.Province;
                ViewBag.District = shipDetail.District;
            }
            var selectedCart = new CartDao().GetByUser(user.Id).Where(x => x.Selected == true).ToList();
            ViewData["SelectedCart"] = selectedCart;
            return View();
        }
        [HttpPost]
        public ActionResult Create(ShipDetailModel model)
        {
            if (ModelState.IsValid)
            {
                var user = (User)Session["user"];
                int shipDetailId, orderId;
                var shipDetail = new ShipDetailDao().GetShipDetail(user.Id, model.ReceiverName, model.Phone, model.Address);
                if (shipDetail == null)
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
                var SelectedCart = new CartDao().GetSelected(user.Id);
                int totalPrice = 0;
                foreach (var cart in SelectedCart)
                {
                    totalPrice += cart.Product1.Price * cart.Quantity;
                }
                var createOrder = new OrderDao().Create(user.Id, shipDetailId, model.Note, out orderId, totalPrice);
                var createProInorder = new ProductInOrderDao().Create(SelectedCart, orderId);
                var removeSelectedCart = new CartDao().RemoveSelected(user.Id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "đã có lỗi xảy ra");
                return View("Index");
            }
        }
        public ActionResult Cancel(int orderId)
        {
            var result = new OrderDao().UpdateStatus(orderId, 0);
            return RedirectToAction("Index", new { status = 1});
        }
    }
}