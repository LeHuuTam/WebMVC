using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models.DAO
{
    public class ProductInOrderDao
    {
        ShopDbContext db = null;
        public ProductInOrderDao()
        {
            db = new ShopDbContext();
        }
        public bool Create(List<Product> proList, int orderId)
        {
            try
            {
                foreach (var pro in proList)
                {
                    var proInOrder = new ProductInOrder()
                    {
                        Product = pro.Id,
                        Order = orderId
                    };
                    db.ProductInOrders.Add(proInOrder);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}