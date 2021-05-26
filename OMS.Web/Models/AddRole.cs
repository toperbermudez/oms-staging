using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace OMS.Web.fonts
{
    public class RoleViewModel
    {
 
        public int ID { get; set; }
 
        public string Name { get; set; }
       public string Description { get; set; }

 
        public string CreatedBy { get; set; }
 
        public DateTime CreatedDate { get; set; }
 
        public string UpdatedBy { get; set; }

       public DateTime UpdatedDate { get; set; }


    }
}