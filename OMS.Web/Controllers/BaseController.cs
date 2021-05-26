using OMS.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMS.Web.Controllers
{
    [OMSAuthorize]
    public abstract partial class BaseController : Controller
    {
        public AppPrincipal appUser
        {
            get { return (AppPrincipal)User; }
        }
    }
}