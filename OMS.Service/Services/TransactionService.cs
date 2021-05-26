using AutoMapper;
using OMS.Core.Interface.Repositories;
using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;


namespace OMS.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ICRUDRepository<Entities.Transaction> _transactionRepo;
        public TransactionService(ICRUDRepository<Entities.Transaction> transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }
        public DTO.Response<DTO.Transaction> CreateTransaction(DTO.Transaction transaction)
        {
            DTO.Response<DTO.Transaction> response = new DTO.Response<DTO.Transaction>();
            try
            {
                transaction.CreatedDate = DateTime.UtcNow;
                transaction.UpdatedDate = DateTime.UtcNow;
                _transactionRepo.Add(Mapper.Map<DTO.Transaction, Entities.Transaction>(transaction));
                response.Success = true;
                response.Data = transaction;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;

        }

        public DTO.Transaction GetTransactionByID(int transactionID)
        {
            return Mapper.Map<Entities.Transaction, DTO.Transaction>(_transactionRepo.GetSingle(u => u.ID.Equals(transactionID)));
        }

        public IEnumerable<DTO.Transaction> ListTransactions()
        {
            return Mapper.Map<IEnumerable<Entities.Transaction>, IEnumerable<DTO.Transaction>>(_transactionRepo.GetAll());
        }

        public IEnumerable<DTO.Transaction> ListTransactionsByUserID(int userID)
        {
            //return Mapper.Map<IEnumerable<Entities.Transaction>, IEnumerable<DTO.Transaction>>(_transactionRepo.GetList(p => p.User.ID.Equals(userID)));
            return null;
        }

        public DTO.Response<DTO.Transaction> RemoveTransaction(int transactionID)
        {
            DTO.Response<DTO.Transaction> response = new DTO.Response<DTO.Transaction>();
            try
            {
                Entities.Transaction transaction = _transactionRepo.GetSingle(u => u.ID.Equals(transactionID));
                _transactionRepo.Remove(transaction);
                response.Success = true;
                response.Data = Mapper.Map<Entities.Transaction, DTO.Transaction>(transaction);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DTO.Response<DTO.Transaction> UpdateTransaction(DTO.Transaction transaction)
        {
            transaction.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Transaction> response = new DTO.Response<DTO.Transaction>();
            try
            {
                _transactionRepo.Update(Mapper.Map<DTO.Transaction, Entities.Transaction>(transaction));
                response.Success = true;
                response.Data = transaction;
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
