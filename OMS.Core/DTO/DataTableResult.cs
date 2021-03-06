using System.Collections.Generic;
using System.Linq;

namespace OMS.Web.Models
{
    public class DataTableResult
    {
        public DataTableResult(IEnumerable<object> list,int totalCount)
        {
            this.recordsTotal = totalCount;
            this.recordsFiltered = totalCount;
            List<List<string>> arr = new List<List<string>>();
            foreach(var item in list)
            {
                arr.Add(item.GetType().GetProperties().Select(p =>
                {
                    object value = p.GetValue(item, null);
                    return value == null ? string.Empty : value.ToString();
                }).ToList());
            }
            data = arr;
        }
        public int draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public List<List<string>> data { get; set; }
    }
}