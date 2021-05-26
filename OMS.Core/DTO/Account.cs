using System;
using System.ComponentModel.DataAnnotations;

namespace OMS.Core.DTO
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public string Salt { get; set; }

        public int UserID { get; set; }

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
