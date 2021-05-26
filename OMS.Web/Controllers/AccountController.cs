using Newtonsoft.Json;
using OMS.Core.Interface.Services;
using OMS.Web.Extension;
using OMS.Web.Models;
using OMS.Web.Security;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OMS.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        public AccountController(IAccountService accountService, IUserService userService)
        {

            _accountService = accountService;
            _userService = userService;
        }

        // GET: Account
        [OMSAuth]
        public virtual ActionResult Index()
        {
            //var result = _userService.CreateUser(new Core.DTO.User
            //{
            //    Address = new Core.DTO.Address
            //    {
            //        AddressLineTwo = string.Empty,
            //        AddressLineOne = string.Empty,
            //        City = string.Empty,
            //        CreatedBy = "admin",
            //        CreatedDate = DateTime.UtcNow,
            //        PostalCode = string.Empty,
            //        UpdatedBy = "admin",
            //        UpdatedDate = DateTime.UtcNow
            //    },
            //    Email = "fcebu@parachutesoftware.com",
            //    FirstName = "Topan",
            //    LastName = "Admin",
            //    Gender = Core.Entities.Gender.Male,
            //    IsActive = true,
            //    MobileNumber = 7920364,
            //    RoleId = 1,
            //}, "admin");
            //_accountService.CreateAccount(new Core.DTO.Account
            //{
            //    PasswordHash = "password",
            //    UserName = "tpadmin",
            //    UserID = 1
            //}, "admin");
            return View();
        }

        [HttpPost]
        public virtual JsonResult Index(UserCredentialViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var result = _accountService.LoginAccount(viewmodel.MapToAccount());
                if (result.Success)
                {
                    var serializableObject = new AppSerializeModal
                    {
                        UserId = result.Data.ID,
                        Username = result.Data.Username,
                        Email = result.Data.Email,
                        FirstName = result.Data.FirstName,
                        LastName = result.Data.LastName
                    };
                    string userData = JsonConvert.SerializeObject(serializableObject);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, viewmodel.Username, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);

                    string enTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, enTicket);
                    faCookie.Expires = DateTime.Now.AddMinutes(15);
                    Response.Cookies.Add(faCookie);
                }
                return Json(result);
            }
            return Json(true);
        }

        public virtual ActionResult Logout()
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                FormsAuthentication.SignOut();
            }
            return RedirectToAction(AccountController.ActionNameConstants.Index);
        }
    }
}