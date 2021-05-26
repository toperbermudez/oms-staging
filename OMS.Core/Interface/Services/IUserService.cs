using OMS.Core.DTO;
using OMS.Web.Models;
using System.Collections.Generic;

namespace OMS.Core.Interface.Services
{
    public interface IUserService
    {
        IEnumerable<User> ListUsers(bool isActive);

        Response<User> CreateUser(User user, string username);

        Response<User> UpdateUser(User user);

        Response<User> RemoveUser(int userID);

        User GetUserByID(int userID,bool isActive);

        DataTableResult ListUsers(DTO.EmployeeFilter filter);
    }
}
