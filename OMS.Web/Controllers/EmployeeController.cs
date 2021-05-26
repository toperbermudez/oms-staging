using OMS.Core.DTO;
using OMS.Core.Entities;
using OMS.Core.Interface.Services;
using OMS.Web.Extension;
using OMS.Web.Models;
using System.Web.Mvc;

namespace OMS.Web.Controllers
{
    public partial class EmployeeController : BaseController
    {

        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleSevice;
        public EmployeeController(IAccountService accountService,
                                  IUserService userService,
                                  IRoleService roleSevice)
        {

            _accountService = accountService;
            _userService = userService;
            _roleSevice = roleSevice;
        }

        // GET: Employee
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult CreateNewEmployee(int id = 0)
        {
            return View();
        }

        [HttpPost]
        public virtual JsonResult CreateNewEmployee(EmployeeViewModel model)
        {
            var validateUsernameResult = _accountService.ValidateUsername(model.UserName);
            if (validateUsernameResult.Success)
            {
                var userDto = model.MapToUser(appUser.Username);
                var userResult = _userService.CreateUser(userDto, appUser.Username);
                if (userResult.Success)

                {
                    var accountDto = model.MapToAccount(appUser.Username);
                    accountDto.UserID = userResult.Data.ID;
                    var accountResult = _accountService.CreateAccount(accountDto, appUser.Username);
                    return Json(accountResult);
                }
                return Json(userResult);
            }
            return Json(validateUsernameResult);
        }

        [HttpGet]
        public virtual JsonResult GetRoles()
        {
            return Json(_roleSevice.ListRoles(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult ListEmployee(string search = "", EmployeeFilterType filterType = EmployeeFilterType.AllUsers)
        {
            var start = Request.Params["start"];
            var length = Request.Params["length"];
            var draw = Request.Params["draw"];

            var result = _userService.ListUsers(new EmployeeFilter()
            {
                Take = int.Parse(length),
                Skip = int.Parse(start),
                FilterType = filterType,
                Query = search
            });
            result.draw = int.Parse(draw);
            return Json(result);
        }
    }
}