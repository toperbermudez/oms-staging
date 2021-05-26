using AutoMapper;
using OMS.Core.Common;
using OMS.Core.DTO;
using OMS.Core.Interface.Repositories;
using OMS.Core.Interface.Services;
using OMS.Core.Resource;
using System;
using System.Collections.Generic;
using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;

namespace OMS.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly ICRUDRepository<Entities.Account> _accountRepo;

        public AccountService(ICRUDRepository<Entities.Account> accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public Response<Account> CreateAccount(Account account, string username)
        {
            DTO.Response<DTO.Account> response = new DTO.Response<DTO.Account>();
            try
            {
                account.Salt = Cryptography.CreateSalt();
                account.PasswordHash = Cryptography.HashString(account.PasswordHash, account.Salt);
                var accountEntity = Mapper.Map<DTO.Account, Entities.Account>(account);
                accountEntity.CreatedBy = username;
                accountEntity.CreatedDate = DateTime.UtcNow;
                accountEntity.UpdatedBy = username;
                accountEntity.UpdatedDate = DateTime.UtcNow;

                _accountRepo.Add(accountEntity);
                response.Success = true;
                response.Data = account;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public Account GetAccountByID(int accountID)
        {
            return Mapper.Map<Entities.Account, DTO.Account>(_accountRepo.GetSingle(u => u.ID.Equals(accountID)));
        }

        public IEnumerable<Account> ListAccounts()
        {
            return Mapper.Map<IEnumerable<Entities.Account>, IEnumerable<DTO.Account>>(_accountRepo.GetAll());
        }

        public Response<Account> RemoveAccount(int accountID)
        {
            DTO.Response<DTO.Account> response = new DTO.Response<DTO.Account>();
            try
            {
                Entities.Account account = _accountRepo.GetSingle(u => u.ID.Equals(accountID));
                _accountRepo.Remove(account);
                response.Success = true;
                response.Data = Mapper.Map<Entities.Account, DTO.Account>(account);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;

        }

        public Response<Account> UpdateAccount(Account account, string username)
        {
            DTO.Response<DTO.Account> response = new DTO.Response<DTO.Account>();
            try
            {
                _accountRepo.Update(Mapper.Map<DTO.Account, Entities.Account>(account));
                response.Success = true;
                response.Data = account;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;

        }

        public Response<Account> ChangeAccountPassword(Account account, string newPassword)
        {
            DTO.Response<DTO.Account> response = new DTO.Response<DTO.Account>();
            try
            {
                Entities.Account resultAccount = _accountRepo.GetSingle(a => a.UserName.Equals(account.UserName));

                account.PasswordHash = Cryptography.HashString(account.PasswordHash, resultAccount.Salt);
                if (account.PasswordHash.Equals(resultAccount.PasswordHash))
                {
                    account.Salt = Cryptography.CreateSalt();
                    account.PasswordHash = Cryptography.HashString(newPassword, account.Salt);
                    _accountRepo.Update(Mapper.Map<DTO.Account, Entities.Account>(account));

                    response.Success = true;
                    response.Data = account;
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = OMSResource.IncorrectPassword;
                }

            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;

        }

        public Response<LoginResult> LoginAccount(Account account)
        {
            DTO.Response<DTO.LoginResult> response = new DTO.Response<DTO.LoginResult>();
            try
            {
                Entities.Account resultAccount = _accountRepo.GetSingle(a => a.UserName.Equals(account.UserName), i => i.User);
                if (resultAccount != null)
                {
                    var passwordHash = Cryptography.HashString(account.PasswordHash, resultAccount.Salt);
                    if (resultAccount.PasswordHash == passwordHash)
                    {
                        response.Success = true;
                        resultAccount.User = new Entities.User
                        {
                            FirstName = resultAccount.User.FirstName,
                            LastName = resultAccount.User.LastName
                        };
                        response.Data = new LoginResult
                        {
                            Email = resultAccount.User.Email,
                            FirstName = resultAccount.User.FirstName,
                            LastName = resultAccount.User.LastName,
                            Username = resultAccount.UserName
                        };
                    }
                    else
                    {
                        response.Success = false;
                        response.ErrorMessage = OMSResource.IncorrectPassword;
                    }
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = OMSResource.ErrMsgUserNotFound;
                }
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;

        }

        public Response<string> ValidateUsername(string username)
        {
            var result = new Response<string>();
            result.Success = true;
            var query = _accountRepo.GetSingle(i => i.UserName == username);
            if(query != null)
            {
                result.Success = false;
                result.ErrorMessage = OMSResource.ErrMsgUserNameAlreadyExist;
            }
            return result;
        }
    }
}
