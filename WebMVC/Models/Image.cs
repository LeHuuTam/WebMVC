namespace WebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Url { get; set; }

        public int? Product { get; set; }

        public virtual Product Product1 { get; set; }
    }
}
