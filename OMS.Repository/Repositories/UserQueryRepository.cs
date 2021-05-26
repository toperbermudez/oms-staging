using OMS.Core.Entities;
using OMS.Core.Interface.Repositories;
using OMS.Web.Models;
using System.Linq;
using DTO = OMS.Core.DTO;

namespace OMS.Repository.Repositories
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly OMSContext _context;
        public UserQueryRepository(OMSContext context)
        {
            _context = context;
        }

        public DataTableResult ListEmployee(DTO.EmployeeFilter filter)
        {
            var query = (from u in _context.User

                         join aLeft in _context.Accounts on u.ID equals aLeft.UserID into uaLeft
                         from acc in uaLeft.DefaultIfEmpty()

                         join addressLeft in _context.Addresses on u.AddressId equals addressLeft.ID into addLeft
                         from address in addLeft.DefaultIfEmpty()

                         join role in _context.Roles on u.RoleId equals role.ID

                         where (u.FirstName.Contains(filter.Query) ||
                               u.LastName.Contains(filter.Query) ||
                               acc.UserName.Contains(filter.Query) ||
                               role.Name.Contains(filter.Query)) &&
                               (filter.FilterType == EmployeeFilterType.AllUsers ? true : (filter.FilterType == EmployeeFilterType.Active ? u.IsActive : !u.IsActive))

                         select new DTO.Employee
                         {
                             ID = u.ID,
                             Address = address.AddressLineOne + " " + address.AddressLineTwo + " " + address.PostalCode + " " + address.City,
                             CreatedBy = u.CreatedBy,
                             CreatedDate = u.CreatedDate,
                             FirstName = u.FirstName,
                             IsActive = u.IsActive,
                             LastName = u.LastName,
                             Role = role.Name,
                             Username = acc.UserName
                         }).ToList();

            return new DataTableResult(query.Skip(filter.Skip).Take(filter.Take),query.Count());
        }
    }
}
