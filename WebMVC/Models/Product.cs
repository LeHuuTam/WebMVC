namespace WebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Carts = new HashSet<Cart>();
            Images = new HashSet<Image>();
            ProductInOrders = new HashSet<ProductInOrder>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Price { get; set; }

        [StringLength(20)]
        public string Brand { get; set; }

        [StringLength(20)]
        public string MadeIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Expiry { get; set; }

        [StringLength(200)]
        public string Preservation { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public int? Stock { get; set; }

        public int? Category { get; set; }

        public bool? IsFeatured { get; set; }

        public DateTime? DateCreated { get; set; }

        [StringLength(100)]
        public string Avatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Category Category1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductInOrder> ProductInOrders { get; set; }
    }
}
