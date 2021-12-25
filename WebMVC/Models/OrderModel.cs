using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class OrderModel
    {
        public List<ProductInOrder> ListProduct { get; set; }
        public ShipDetail ShipDetail { get; set; }
        public Order Order { get; set; }
    }
}