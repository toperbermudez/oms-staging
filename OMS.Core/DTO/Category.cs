using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.DTO
{
    public class Category : IAudit
    {
        [Required]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(30)]
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }

        public IEnumerable<Category> SubCategory { get; set; }
        public IEnumerable<Product> Product { get; set; }

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
