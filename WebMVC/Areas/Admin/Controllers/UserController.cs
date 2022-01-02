using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.DAO;

namespace WebMVC.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            var listUsers = new UserDao().GetAll();
            return View(listUsers);
        }
    }
}