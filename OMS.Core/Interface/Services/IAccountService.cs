using OMS.Core.DTO;
using System.Collections.Generic;

namespace OMS.Core.Interface.Services
{
    public interface IAccountService
    {
        IEnumerable<Account> ListAccounts();

        Response<Account> CreateAccount(Account account,string username);

        Response<Account> UpdateAccount(Account account, string username);

        Response<Account> RemoveAccount(int accountID);

        Account GetAccountByID(int accountID);

        Response<Account> ChangeAccountPassword(Account account,string newPassword);

        Response<LoginResult> LoginAccount(Account account);

        Response<string> ValidateUsername(string username);
    }
}
