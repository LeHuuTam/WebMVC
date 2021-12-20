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
            var proDao = new ProductDao();
            var home = new HomeModel()
            {
                Featured = proDao.GetFeatured(),
                Latest = proDao.GetLatest()
            };
            return View(home);
        }
    }
}