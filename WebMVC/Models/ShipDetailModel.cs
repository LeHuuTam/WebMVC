using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class ShipDetailModel
    {
        public string ReceiverName { get; set; }
        public string Phone { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
    }
}