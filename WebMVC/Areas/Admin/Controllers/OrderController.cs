using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Models.DAO;

namespace WebMVC.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Index(int status)
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Status = status;
            var orderModelList = new List<OrderModel>();
            var orderList = new OrderDao().GetByStatus(status);
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
        public ActionResult Confirm(int orderId)
        {
            var result = new OrderDao().UpdateStatus(orderId, 2);
            var proInOrder = new ProductInOrderDao().GetByOrder(orderId);
            var dao = new ProductDao();
            foreach (var pro in proInOrder)
            {
                var decrease = dao.UpdateStock(pro.Product, pro.Quantity);
            }
            return RedirectToAction("Index", new { status = 1 });
        }
        public ActionResult Delivered(int orderId)
        {
            var result = new OrderDao().UpdateStatus(orderId, 3);
            return RedirectToAction("Index", new { status = 2 });
        }

    }
}