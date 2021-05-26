using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS.Core.DTO;
using OMS.Core.Interface.Services;


namespace OMS.Web.Controllers
{
    public partial class RoleController : BaseController
    {


        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {

            _roleService = roleService;

        }


        // GET: Role
        public virtual ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public virtual ActionResult ListRole()
        {
            var start = Request.Params["start"];
            var length = Request.Params["length"];
            var draw = Request.Params["draw"];
            var result = _roleService.ListRole(int.Parse(length), int.Parse(start));
            result.draw = int.Parse(draw);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult CreateRole()
        {
              return View();
        }

        [HttpPost]
        public virtual JsonResult CreateRole(Role role)
        {
            role.CreatedBy = appUser.Username;
            role.UpdatedBy = appUser.Username;
            Response<Role> response;
            if (role.ID == 0)
            {
                response = _roleService.CreateRole(role);
            }
            else
            {
                response = _roleService.UpdateRole(role);
            }
            return Json(response);
        }


        [HttpGet]
        public virtual JsonResult GetRole(int id)
        {
            return Json(_roleService.GetRoleByID(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual JsonResult DeleteRole(int id)
        {
            return Json(_roleService.RemoveRole(id), JsonRequestBehavior.AllowGet);
        }

    }
}