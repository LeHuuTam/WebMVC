namespace WebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int Id { get; set; }

        public int? User { get; set; }

        public int? Product { get; set; }

        public int Quantity { get; set; }

        public bool? Selected { get; set; }

        public virtual Product Product1 { get; set; }

        public virtual User User1 { get; set; }
    }
}
