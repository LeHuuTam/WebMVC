using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models.DAO
{
    public class CartDao
    {
        ShopDbContext db = null;
        public CartDao()
        {
            db = new ShopDbContext();
        }
        public List<Cart> GetByUser(int userId)
        {
            return db.Carts.Where(x=>x.User==userId).ToList();
        }
        public int GetTotalPriceByUser(int userId)
        {
            var list = db.Carts.Where(x => x.User == userId).ToList();
            int total = 0;
            foreach(var i in list)
            {
                total += i.Product1.Price * i.Quantity;
            }
            return total;
        }
        public int GetTotalProductsByUser(int userId)
        {
            var list = db.Carts.Where(x => x.User == userId).ToList();
            int total = 0;
            foreach (var i in list)
            {
                total += i.Quantity;
            }
            return total;
        }
        public bool AddCart(Cart cart)
        {
            try
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }                
        }
        public bool UpdateQuantity(Cart cart, int quantity)
        {
            try
            {
                Cart c = db.Carts.Where(x => x.Id == cart.Id).FirstOrDefault();
                c.Quantity += quantity;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(int cartId)
        {
            try
            {
                Cart c = db.Carts.Where(x => x.Id == cartId).FirstOrDefault();
                db.Carts.Remove(c);
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