using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Models.DAO;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Top()
        {
            return View();
        }
        public ActionResult Featured()
        {
            var proList = new ProductDao().GetFeatured();
            return View(proList);
        }
        public ActionResult Latest()
        {
            var proList = new ProductDao().GetLatest();
            return View(proList);
        }
    }
}