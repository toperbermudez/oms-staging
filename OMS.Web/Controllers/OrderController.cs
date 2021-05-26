using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMS.Web.Controllers
{
    public partial class OrderController : BaseController
    {
        // GET: Order
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}