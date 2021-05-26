using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace OMS.Web.Security
{

    public class AppPrincipal : IPrincipal
    {
        #region Identity Properties  

        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        #endregion

        public IIdentity Identity
        {
            get; private set;
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public AppPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }
    }

    public class AppSerializeModal
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}