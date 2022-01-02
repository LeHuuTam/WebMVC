using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Common;
using WebMVC.Models;
using WebMVC.Models.DAO;

namespace WebMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result)
                {
                    var user = dao.GetByUserName(model.UserName);
                    Session.Add("user", user);
                    ViewBag.UserName = user.Name;
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công!");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return Redirect("/Home/Index");
        }
    }
}