using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMS.Web.Models
{
    public class AddCategory
    {

  
        public int ID { get; set; }

    
        public string Name { get; set; }
  
        public string Description { get; set; }

        public int VariantID { get; set; }

        public List<Variant>  Variant { get; set; }

        public string CreatedBy { get; set; }
    
 
        public string UpdatedBy { get; set; }
  
    



    }
}