using OMS.Core.Interface.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Core.Entities
{
    public class Stock : IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required,ForeignKey("Product")]
        public int ProductID { get; set; }

        public Product Product { get; set; }

        [Required]
        public int GoodQuantity { get; set; }

        [Required]
        public int DamagedQuantity { get; set; }

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
