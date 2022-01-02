using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Common;
using WebMVC.Models;
using WebMVC.Models.DAO;

namespace WebMVC.Controllers
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
                    switch (user.Role)
                    {
                        case 1:
                            return Redirect("/Admin/User/Index");
                        case 2:
                            return RedirectToAction("Index", "Home");
                    }
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
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var userName = dao.GetByUserName(model.UserName);
                if (userName != null)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
                    return View("Register");
                }
                else if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Mật khẩu không trùng khớp");
                    return View("Register");
                }
                else
                {
                    var result = dao.Register(model);
                    if (result)
                    {
                        var user = dao.GetByUserName(model.UserName);
                        Session.Add("user", user);
                        ViewBag.UserName = user.Name;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công!");
                    }
                }
            }
            return View("Register");
        }
    }
}