using OMS.Web.Models;

namespace OMS.Core.Interface.Repositories
{
    public interface IUserQueryRepository
    {
        DataTableResult ListEmployee(DTO.EmployeeFilter filter);
    }
}
