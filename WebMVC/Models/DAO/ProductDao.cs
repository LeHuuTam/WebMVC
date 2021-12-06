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
            for(int j = 0; j < 6; j++)
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
    }
}