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
        public ActionResult ProductsList(int cateId, int? page, string sort)
        {            
            //Lay all san pham trong danh muc
            var cate = new CateDao().GetById(cateId);
            ViewBag.CateName = cate.Name;
            ViewBag.CateId = cateId;

            var listSort = new List<SortModel>();
            listSort.Add(new SortModel(1, "Tên sản phẩm A-Z"));
            listSort.Add(new SortModel(2, "Tên sản phẩm Z-A"));
            listSort.Add(new SortModel(3, "Giá từ thấp đến cao"));
            listSort.Add(new SortModel(4, "Giá từ cao đến thấp"));
            var list = new ProductDao().GetByCategory(cateId);

            ViewBag.Sort = new SelectList(listSort, "Id", "Name");
            List<Product> pageListProducts = new List<Product>();
            //sap xep
            switch (sort)
            {
                case "none":
                    pageListProducts = (from l in list select l).OrderBy(x => x.Id).ToList();
                    break;
                case "nameIncrease":
                    pageListProducts = (from l in list select l).OrderBy(x => x.Name).ToList();
                    break;
                case "nameDecrease":
                    pageListProducts = (from l in list select l).OrderByDescending(x => x.Name).ToList();
                    break;
                case "priceIncrease":
                    pageListProducts = (from l in list select l).OrderBy(x => x.Price).ToList();
                    break;
                case "priceDecrease":
                    pageListProducts = (from l in list select l).OrderByDescending(x => x.Price).ToList();
                    break;
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(pageListProducts.ToPagedList(pageNumber, pageSize));
        }
    }
}