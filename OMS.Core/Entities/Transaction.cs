using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Core.Entities
{
    public class Transaction:IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, ForeignKey("Customer")]
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        [Required,ForeignKey("Address")]
        public int AddressID { get; set; }

        public Address Address { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public ICollection<Order> order { get; set; }

    }
}
