using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Models.DAO;

namespace WebMVC.Controllers
{
    public class ShipDetailController : Controller
    {
        // GET: ShipDetail
        public ActionResult Index()
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var shipDetail = new ShipDetailDao().GetByUser(user.Id);
            return View(shipDetail);
        }
        public ActionResult Create()
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        //[HttpPost]
        //public ActionResult Create(ShipDetail ship)
        //{
        //    var result = new ShipDetailDao().Create(ship);
        //    if (result)
        //    {
        //        return RedirectToAction("Index", "Order");
        //    }
        //    return View("Create");
        //}
    }
}