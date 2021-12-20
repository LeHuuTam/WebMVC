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
        public List<Cart> GetByListId(int[] listId)
        {
            List<Cart> list = new List<Cart>();
            foreach(var i in listId)
            {
                Cart cart = db.Carts.Where(x => x.Id == i).FirstOrDefault();
                if (cart != null)
                {
                    list.Add(cart);
                }
            }
            return list;
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
        public List<Cart> GetSelected(int userId)
        {
            var list = db.Carts.Where(x => x.User == userId && x.Selected == true).ToList();
            return list;
        }
        public bool AddCart(int userId, int proId, int quantity, bool selected)
        {
            try
            {
                var cart = new Cart()
                {
                    User = userId,
                    Product = proId,
                    Quantity = quantity,
                    Selected = selected
                };
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
        public bool ChangeSelected(int cartId)
        {
            try
            {
                var cart = db.Carts.Where(x => x.Id==cartId).FirstOrDefault();
                cart.Selected = !cart.Selected;
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