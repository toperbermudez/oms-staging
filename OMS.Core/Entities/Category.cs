
using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Category:IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(30)]
        public string Description { get; set; }

        public Category ParentCategory { get; set; }

        public ICollection<Category> SubCategory { get; set; }

        public ICollection<Product> Product { get; set; }

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
