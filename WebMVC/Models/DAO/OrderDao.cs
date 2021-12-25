﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models.DAO
{
    public class OrderDao
    {
        ShopDbContext db = null;
        public OrderDao()
        {
            db = new ShopDbContext();
        }
        public List<Order> GetByUser(int userId)
        {
            return db.Orders.Where(x => x.User == userId).ToList();
        }
        public List<Order> GetByStatus(int userId, int status)
        {
            return db.Orders.Where(x => x.User == userId && x.Status == status).ToList();
        }
        public bool Create(int userId, int shipDetailId, string note, out int orderId)
        {
            orderId = -1;
            try
            {
                var order = new Order()
                {
                    User = userId,
                    ShipDetail = shipDetailId,
                    Note = note,
                    Time = DateTime.Now,
                    Status = 1
                };
                db.Orders.Add(order);
                db.SaveChanges();
                orderId = order.Id;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
