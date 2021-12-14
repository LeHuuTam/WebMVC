using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models.DAO
{
    public class CateDao
    {
        ShopDbContext db = null;
        public CateDao()
        {
            db = new ShopDbContext();
        }
        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public Category GetById(int Id)
        {
            return db.Categories.Where(x=>x.Id==Id).FirstOrDefault();
        }        
    }
}