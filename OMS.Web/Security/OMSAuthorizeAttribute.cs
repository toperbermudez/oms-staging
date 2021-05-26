using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMS.Web.Security
{
    public class OMSAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _role;
        public OMSAuthorizeAttribute(string role = "")
        {
            _role = role;
        }

        protected virtual AppPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as AppPrincipal; }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return CurrentUser == null ? false : true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;

            if (CurrentUser == null)
            {
                routeData = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new
                    {
                        controller = "Account",
                        action = "index",
                    }));
            }
            else
            {
                routeData = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new
                    {
                        controller = "Error",
                        action = "AccessDenied"
                    }));
            }

            filterContext.Result = routeData;
        }
    }

    public class OMSAuthAttribute : AuthorizeAttribute
    {
        protected virtual AppPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as AppPrincipal; }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return CurrentUser != null ? false : true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;

            if (CurrentUser != null)
            {
                routeData = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new
                    {
                        controller = "Product",
                        action = "index",
                    }));
            }

            filterContext.Result = routeData;
        }

    }
}