using AutoMapper;
using OMS.Core.Interface.Repositories;
using OMS.Core.Interface.Services;
using OMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;


namespace OMS.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly ICRUDRepository<Entities.Role> _roleRepo;

        public RoleService(ICRUDRepository<Entities.Role> roleRepo)
        {
            _roleRepo = roleRepo;
        }

        



        public DTO.Response<DTO.Role> CreateRole(DTO.Role Role)
        {
            DTO.Response<DTO.Role> role = new DTO.Response<DTO.Role>();
            try
            {
                Role.CreatedDate = DateTime.UtcNow;
                Role.UpdatedDate = DateTime.UtcNow;
                _roleRepo.Add(Mapper.Map<DTO.Role, Entities.Role>(Role));
                role.Success = true;
                role.Data = Role;
            }
            catch (Exception e)
            {
                role.ErrorMessage = e.GetBaseException().Message;
                role.Success = false;
            }
            return role;

        }

        public DataTableResult ListRole(int take, int skip)
        {
            var allCategories = _roleRepo.GetAll();
            var result = allCategories.Skip(skip).Take(take).Select(i => new DTO.Category
            {
                ID = i.ID,
                Name = i.Name,
                Description = i.Description
            });
            return new DataTableResult(result, allCategories.Count());
        }



        public DTO.Role GetRoleByID(int roleID)
        {
            return Mapper.Map<Entities.Role, DTO.Role>(_roleRepo.GetSingle(u => u.ID.Equals(roleID)));
        }

        public IEnumerable<DTO.SelectListDto> ListRoles()
        {
            var roles = _roleRepo.GetAll().Select(i => new DTO.SelectListDto {
                 Text = i.Name,
                  Value = i.ID.ToString()
            });
            return roles;
        }

        public DTO.Response<DTO.Role> RemoveRole(int roleID)
        {
            DTO.Response<DTO.Role> role = new DTO.Response<DTO.Role>();
            try
            {
                Entities.Role Role = _roleRepo.GetSingle(u => u.ID.Equals(roleID));
                _roleRepo.Remove(Role);
                role.Success = true;
                role.Data = Mapper.Map<Entities.Role, DTO.Role>(Role);
            }
            catch (Exception e)
            {
                role.ErrorMessage = e.Message;
                role.Success = false;
            }
            return role;

        }

        public DTO.Response<DTO.Role> UpdateRole(DTO.Role Role)
        {
            Role.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Role> role = new DTO.Response<DTO.Role>();
            try
            {
                _roleRepo.Update(Mapper.Map<DTO.Role, Entities.Role>(Role));
                role.Success = true;
                role.Data = Role;
            }
            catch (Exception e)
            {
                role.ErrorMessage = e.Message;
                role.Success = false;
            }
            return role;

        }
    }
}
