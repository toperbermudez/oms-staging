using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.DTO
{
    public class Variant : IAudit
    {
        [Required]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Description { get; set; }

        public IEnumerable<Category> Category { get; set; }
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
