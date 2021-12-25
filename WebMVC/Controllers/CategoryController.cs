using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Models.DAO;
using PagedList;

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
        public ActionResult ProductsList(int cateId, int? page)
        {            
            //Lay all san pham trong danh muc
            var cate = new CateDao().GetById(cateId);
            ViewBag.CateName = cate.Name;
            ViewBag.CateId = cateId;
            var list = new ProductDao().GetByCategory(cateId);
            //sap xep
            var pageListProducts = (from l in list select l).OrderBy(x => x.Id);
            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return View(pageListProducts.ToPagedList(pageNumber, pageSize));
        }
    }
}