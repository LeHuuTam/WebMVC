using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.DAO;

namespace WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAll()
        {
            var CateList = new CateDao().GetAll();
            return View(CateList);
        }
    }
}