using Newtonsoft.Json;
using OMS.Web.App_Start;
using OMS.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace OMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var serializeModel = JsonConvert.DeserializeObject<AppSerializeModal>(authTicket.UserData);
                AppPrincipal principal = new AppPrincipal(authTicket.Name)
                {
                    FirstName = serializeModel.FirstName,
                    Email = serializeModel.Email,
                    LastName = serializeModel.LastName,
                    UserId = serializeModel.UserId,
                    Username = serializeModel.Username
                };
                HttpContext.Current.User = principal;
            }

        }
    }
}
