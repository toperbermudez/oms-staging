using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Interface.Entity
{
    public interface IAudit
    {  
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }

    }
}
