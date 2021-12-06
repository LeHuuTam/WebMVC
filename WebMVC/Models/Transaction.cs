namespace WebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        public int Id { get; set; }

        public int? User { get; set; }

        public int? Order { get; set; }

        public DateTime? Time { get; set; }

        public int? Status { get; set; }

        public virtual Order Order1 { get; set; }

        public virtual User User1 { get; set; }
    }
}
