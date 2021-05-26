using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OMS.Core.Entities
{
    public class Address :IAudit
    {
        [Key]
        public int ID { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }

        public ICollection<User> User { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }
}
