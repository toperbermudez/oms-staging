using OMS.Core.Interface.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Core.Entities
{
    public class VariantOption : IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required,ForeignKey("Variant")]
        public int VariantID { get; set; }

        public string Name { get; set; }

        public Variant Variant { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
