using OMS.Core.DTO;
using OMS.Web.Models;
using System;

namespace OMS.Web.Extension
{
    public static class ViewModelToModelExtension
    {
        public static Account MapToAccount(this UserCredentialViewModel model)
        {
            return new Account
            {
                UserName = model.Username,
                PasswordHash = model.Password
            };
        }

        public static User MapToUser(this EmployeeViewModel model, string createdBy)
        {
            return new User
            {
                Address = new Address
                {
                    AddressLineOne = model.AddressLineOne,
                    AddressLineTwo = model.AddressLineTwo,
                    City = model.City,
                    PostalCode = model.PostalCode,
                    CreatedBy = createdBy,
                    UpdatedBy = createdBy,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                },
                UpdatedDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = createdBy,
                CreatedBy = createdBy,
                Email = model.Email,
                FirstName = model.FirstName,
                Gender = Core.Entities.Gender.Female,
                LastName = model.LastName,
                MobileNumber = model.MobileNumber,
                IsActive = true,
                RoleId = model.RoleId
            };
        }

        public static Account MapToAccount(this EmployeeViewModel model, string createdBy)
        {
            return new Account
            {
                PasswordHash = model.Password,
                UserName = model.UserName,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = createdBy,
                UpdatedBy = createdBy,
                UpdatedDate = DateTime.UtcNow,
                Status = 1
            };
        }
    }
}