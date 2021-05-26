using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.DTO
{
    public class Order : IAudit
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public int TransactionId { get; set; }

        public Transaction Transaction { get; set; }
        public Product Product { get; set; }
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
