using OMS.Core.Entities;
using System.ComponentModel;

namespace OMS.Web.Models
{
    public class EmployeeViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        [DisplayName("Address Line")]
        public string AddressLineOne { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressLineTwo { get; set; }

        public string City { get; set; }

        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [DisplayName("Role")]
        public int RoleId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}