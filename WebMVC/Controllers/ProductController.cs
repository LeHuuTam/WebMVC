using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Models.DAO;

namespace WebMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductDetail(int Id)
        {
            var product = new ProductDao().GetById(Id);
            return View(product);
        }
        public ActionResult Search(string searchString)
        {
            var list = new ProductDao().Search(searchString);
            return View(list);
        }
    }
}