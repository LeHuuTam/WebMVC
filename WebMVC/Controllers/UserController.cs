using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(user);
        }
        public ActionResult UserInformation()
        {
            return View();
        }
    }
}