using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models.DAO
{
    public class ShipDetailDao
    {
        ShopDbContext db = null;
        public ShipDetailDao()
        {
            db = new ShopDbContext();
        }
        public List<ShipDetail> GetByUser(int userId)
        {
            return db.ShipDetails.Where(x => x.User == userId).ToList();
        }
        public bool CheckByUser(int userId)
        {
            int count = db.ShipDetails.Where(x => x.User == userId).ToList().Count;
            return count > 0;
        }
        public ShipDetail GetShipDetail(int userId, string name, string phone, string address)
        {
            ShipDetail ship = db.ShipDetails.Where(x => x.User == userId
                && x.ReceiverName == name
                && x.Phone == phone
                && x.Address == address).FirstOrDefault();
            return ship;
        }
        public bool Create(ShipDetail ship, out int shipDetailId)
        {
            shipDetailId = -1;
            try
            {
                db.ShipDetails.Add(ship);
                db.SaveChanges();
                shipDetailId = ship.Id;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}