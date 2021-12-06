using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models.DAO
{
    public class UserDao
    {
        ShopDbContext db = null;
        public UserDao()
        {
            db = new ShopDbContext();
        }
        public bool Login(string userName, string pwd)
        {
            var result = db.Users.Count(x => x.UserName == userName && x.Password == pwd);
            return result > 0 ? true : false;
        }
        public User GetByUserName(string userName)
        {
            return db.Users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}