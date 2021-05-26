using OMS.Core.Interface.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Core.Entities
{
    public class CategoryVariant : IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required,ForeignKey("Category")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        [Required, ForeignKey("Variant")]
        public int VariantID { get; set; }

        public Variant Variant { get; set; }

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
