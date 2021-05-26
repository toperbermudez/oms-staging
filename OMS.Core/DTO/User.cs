using OMS.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace OMS.Core.DTO
{
    public class User
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

        public int AddressId { get; set; }

        public Address Address { get; set; }

        [Required]
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
    }
}
