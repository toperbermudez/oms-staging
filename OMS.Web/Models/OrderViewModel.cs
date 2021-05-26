using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMS.Core.DTO;

namespace OMS.Web.Models
{
    public class OrderViewModel
    {

        public int ID { get; set; }

        public int Quantity { get; set; }


        public Product Product { get; set; }
     




    }
}