namespace WebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShipDetail")]
    public partial class ShipDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShipDetail()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public int? User { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiverName { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Province { get; set; }

        [StringLength(100)]
        public string District { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual User User1 { get; set; }
    }
}
