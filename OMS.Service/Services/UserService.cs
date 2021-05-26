using AutoMapper;
using OMS.Core.Common;
using OMS.Core.Interface.Repositories;
using OMS.Core.Interface.Services;
using OMS.Web.Models;
using System;
using System.Collections.Generic;
using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;

namespace OMS.Service.Services
{
    public class UserService : IUserService
    {
        private ICRUDRepository<Entities.User> _userRepo;
        private IUserQueryRepository _userQueryRepository;
        public UserService(ICRUDRepository<Entities.User> userRepo,
                           IUserQueryRepository userQueryRepository)
        {
            _userRepo = userRepo;
            _userQueryRepository = userQueryRepository;
        }
        public DTO.Response<DTO.User> CreateUser(DTO.User user,string username)
        {
            DTO.Response<DTO.User> response = new DTO.Response<DTO.User>();
            try {
                var userEntities = Mapper.Map<DTO.User, Entities.User>(user);
                userEntities.SetCreatedAudit(username);
                _userRepo.Add(userEntities);
                response.Success = true;
                response.Data = Mapper.Map<Entities.User,DTO.User>(userEntities);
            }
            catch (Exception e) {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DTO.User GetUserByID(int userID, bool isActive)
        {
            
            return Mapper.Map<Entities.User,DTO.User>(_userRepo.GetSingle(u => u.ID.Equals(userID) && u.IsActive.Equals(isActive)));
        }

        public IEnumerable<DTO.User> ListUsers(bool isActive)
        {
            return Mapper.Map<IEnumerable<Entities.User>,IEnumerable<DTO.User>>(_userRepo.GetList(u => u.IsActive.Equals(isActive)));
        }

        public DataTableResult ListUsers(DTO.EmployeeFilter filter)
        {
            return _userQueryRepository.ListEmployee(filter);
        }

        public DTO.Response<DTO.User> RemoveUser(int userID)
        {
            DTO.Response<DTO.User> user = new DTO.Response<DTO.User>();
            try
            {
                Entities.User User = _userRepo.GetSingle(u=>u.ID.Equals(userID)); 
                _userRepo.Remove(User);
                user.Success = true;
                user.Data = Mapper.Map<Entities.User,DTO.User>(User);
            }
            catch (Exception e)
            {
                user.ErrorMessage = e.GetBaseException().Message;
                user.Success = false;
            }
            return user;
        }

        public DTO.Response<DTO.User> UpdateUser(DTO.User user)
        {
            DTO.Response<DTO.User> response = new DTO.Response<DTO.User>();
            try
            {
                _userRepo.Update(Mapper.Map < DTO.User, Entities.User >(user));
                response.Success = true;
                response.Data = user;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }
    }
}
