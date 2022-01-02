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
            return result > 0;
        }
        public bool Register(Register reg)
        {
            try
            {
                User user = new User()
                {
                    Role = 2,
                    Name = reg.Name,
                    Email =reg.Email,
                    Phone = reg.Phone,
                    Address = reg.Address,
                    Province = reg.Province,
                    District = reg.District,
                    UserName = reg.UserName,
                    Password = reg.Password,
                };
                var result = db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public User GetByUserName(string userName)
        {
            return db.Users.FirstOrDefault(x => x.UserName == userName);
        }
        public List<User> GetAll()
        {
            return db.Users.ToList();
        }
        public bool Update(int userId, User newUser)
        {
            try
            {
                var user = db.Users.FirstOrDefault(x => x.Id == userId);
                user.Name = newUser.Name;
                user.Phone = newUser.Phone;
                user.Email = newUser.Email;
                user.Address = newUser.Address;
                user.Avatar = newUser.Avatar;
                user.UserName = newUser.UserName;
                user.Password = newUser.Password;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}