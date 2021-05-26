using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Core.Entities
{
    public class User : IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string FirstName { get; set; }

        [Required, StringLength(25)]
        public string LastName { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address Address { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }
        
        public ICollection<Order> Order { get; set; }

        public ICollection<Transaction> Transaction { get; set; }

    }
}
