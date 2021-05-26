using OMS.Core.Interface.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Core.Entities
{
    public class ProductVariant : IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required,ForeignKey("Product")]
        public int ProductID { get; set; }

        public Product Product { get; set; }

        [Required, ForeignKey("Variant")]
        public int VariantID { get; set; }

        public Variant Variant { get; set; }

        public string Value { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}
