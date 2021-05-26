using OMS.Core.Entities;

namespace OMS.Core.DTO
{
    public class EmployeeFilter
    {
        public string Query { get; set; }
        public EmployeeFilterType FilterType { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
