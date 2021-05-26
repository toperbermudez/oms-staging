using OMS.Core.Interface.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace OMS.Core.Entities
{
    public class InventoryLog : IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Note { get; set; }

        [Required]
        public int InvoiceNumber { get; set; }

        [Required]
        public InventoryProcess Process { get; set; }

        [Required]
        public Supplier Supplier { get; set; }

        [Required]
        public Product Product { get; set; }

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
