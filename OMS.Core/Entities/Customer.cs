using OMS.Core.Interface.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace OMS.Core.Entities
{
    public class Customer : IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string FirstName { get; set; }

        [Required, StringLength(25)]
        public string LastName { get; set; }

        [Required]
        public int MobileNumber { get; set; }

        public int Tin { get; set; }

        public string BusinessName { get; set; }

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
