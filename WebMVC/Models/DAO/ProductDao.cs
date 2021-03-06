using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models.DAO
{
    public class ProductDao
    {
        ShopDbContext db = null;
        public ProductDao()
        {
            db = new ShopDbContext();
        }
        public List<Product> GetFeatured()
        {
            return db.Products.Where(x => x.IsFeatured == true).ToList();
        }
        public List<Product> GetLatest()
        {
            List<Product> latestList = new List<Product>();
            List<Product> allPro = db.Products.ToList();
            DateTime date = allPro[0].DateCreated.Value;
            int index = 0;
            for (int j = 0; j < 6; j++)
            {
                for (int i = 1; i < allPro.Count; i++)
                {
                    if (allPro[i].DateCreated.Value > date)
                    {
                        date = allPro[i].DateCreated.Value;
                        index = i;
                    }
                }
                latestList.Add(allPro[index]);
                allPro.RemoveAt(index);
                index = 0;
                date = allPro[0].DateCreated.Value;
            }
            return latestList;
        }
        public List<Product> GetByCategory(int cateId = 0)
        {
            return db.Products.Where(x => x.Category == cateId).ToList();//Skip((pageSize-1)*pageSize).Take(pageSize).ToList();
        }
        public Product GetById(int Id)
        {
            return db.Products.Where(x => x.Id == Id).FirstOrDefault();//Skip((pageSize-1)*pageSize).Take(pageSize).ToList();
        }
        public List<Product> Search(string searchString)
        {
            return db.Products.Where(x => x.Name.Contains(searchString)).ToList();
        }
        public bool UpdateStock(int? proId, int? minus)
        {
            try
            {
                var pro = db.Products.Where(x => x.Id == proId).FirstOrDefault();
                pro.Stock -= minus;
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