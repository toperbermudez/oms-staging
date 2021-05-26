using OMS.Core.DTO;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Web.Models;

namespace OMS.Core.Interface.Services
{
    public interface IRoleService
    {
        IEnumerable<DTO.SelectListDto> ListRoles();

        DataTableResult ListRole(int take, int skip);




        Response<Role> CreateRole(Role Role);

        Response<Role> UpdateRole(Role Role);

        Response<Role> RemoveRole(int roleID);

        Role GetRoleByID(int roleID);

    }
}
