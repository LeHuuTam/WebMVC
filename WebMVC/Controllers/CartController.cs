using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Models.DAO;

namespace WebMVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var list = new CartDao().GetByUser(user.Id);
            return View(list);
        }
        [HttpPost]
        public ActionResult AddItem(int proId)
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var list = new CartDao().GetByUser(user.Id);
            bool result = false;
            if (list != null)
            {
                if (list.Exists(x => x.Product == proId))
                {
                    var cart = list.Where(x => x.Product == proId).FirstOrDefault();
                    result = new CartDao().UpdateQuantity(cart, 1);
                }
                else
                {
                    result = new CartDao().AddCart(user.Id, proId, 1, false);
                }
            }
            //Neu user chua co gio hang hoac gio hang chua co sp nay
            else
            {
                result = new CartDao().AddCart(user.Id, proId, 1, false);
            }
            if (result)
            {
                int totalPrice = new CartDao().GetTotalPriceByUser(user.Id);
                int totalProduxts = new CartDao().GetTotalProductsByUser(user.Id);
                return Json(new
                {
                    status = "true",
                    totalProducts = totalProduxts,
                    totalPrice = totalPrice,
                });
            }
            else
            {
                return Json(new
                {
                    status = "false",
                    totalProducts = 0,
                    totalPrice = 0,
                });
            }
        }
        [HttpPost]
        public JsonResult Remove(int proId)
        {
            var user = (User)Session["user"];
            var list = new CartDao().GetByUser(user.Id);
            var cart = list.Where(x => x.Product == proId).FirstOrDefault();
            var result = new CartDao().Remove(cart.Id);
            if (result)
            {
                int totalPrice = new CartDao().GetTotalPriceByUser(user.Id);
                int totalProduxts = new CartDao().GetTotalProductsByUser(user.Id);
                return Json(new
                {
                    status = result,
                    totalProducts = totalProduxts,
                    totalPrice = totalPrice,
                });
            }
            else
            {
                return Json(new
                {
                    status = result,
                    totalProducts = 0,
                    totalPrice = 0,
                });
            }
        }
        [HttpPost]
        public JsonResult ChangeSelected(int proId)
        {
            var user = (User)Session["user"];
            var list = new CartDao().GetByUser(user.Id);
            var cart = list.Where(x => x.Product == proId).FirstOrDefault();
            var result = new CartDao().ChangeSelected(cart.Id);
            return Json(new
            {
                status = result
            });
        }
    }
}