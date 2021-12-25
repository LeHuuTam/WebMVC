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
        public bool Create(List<Cart> cartList, int orderId)
        {
            try
            {
                foreach (var cart in cartList)
                {
                    var proInOrder = new ProductInOrder()
                    {
                        Product = cart.Product1.Id,
                        Quantity = cart.Quantity,
                        Order = orderId
                    };
                    db.ProductInOrders.Add(proInOrder);
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ProductInOrder> GetByOrder(int orderId)
        {
            return db.ProductInOrders.Where(x => x.Order == orderId).ToList();
        }
    }
}