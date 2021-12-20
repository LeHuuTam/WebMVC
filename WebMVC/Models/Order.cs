namespace WebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            ProductInOrders = new HashSet<ProductInOrder>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }

        public int? User { get; set; }

        public DateTime? Time { get; set; }

        public int? ShipDetail { get; set; }

        public int? ShipMethod { get; set; }

        public DateTime? ReceiveDate { get; set; }

        public int? TotalPrice { get; set; }

        [Column(TypeName = "ntext")]
        public string Note { get; set; }

        public int? Status { get; set; }

        public virtual ShipDetail ShipDetail1 { get; set; }

        public virtual ShipMethod ShipMethod1 { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductInOrder> ProductInOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
