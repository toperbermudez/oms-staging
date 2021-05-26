using OMS.Core.Interface.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Core.Entities
{
    public class Order:IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Transaction")]
        public int TransactionID { get; set; }

        public Transaction Transaction { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductID { get; set; }

        public Product Product { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

    }
}
