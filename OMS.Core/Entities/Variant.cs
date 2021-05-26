using OMS.Core.Interface.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace OMS.Core.Entities
{
    public class Variant :IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Description { get; set; }

        [Required]
        public VariantType Type { get; set; }

        [Required]
        public bool IsRequired { get; set; }

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
