using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;

namespace OMS.Core.Interface.Services
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> ListTransactions();

        Response<Transaction> CreateTransaction(Transaction transaction);

        Response<Transaction> UpdateTransaction(Transaction transaction);

        Response<Transaction> RemoveTransaction(int transactionID);

        Transaction GetTransactionByID(int transactionID);

        IEnumerable<Transaction> ListTransactionsByUserID(int userID);

    }
}
