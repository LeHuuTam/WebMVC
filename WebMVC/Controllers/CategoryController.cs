using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
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
        public ActionResult ProductsList(int cateId)
        {
            var cate = new CateDao().GetById(cateId);
            ViewBag.Cate = cate.Name;
            var list = new ProductDao().GetByCategory(cateId);
            return View(list);
        }
    }
}