using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_this.Services
{
    public interface IAccountService
    {
        Account GetAccountByID(Guid ID);
        IEnumerable<Account> GetAccounts();
        void AddAccount(Account account);
        void DeleteAccount(Guid ID);
        void ModifyAccount(Guid ID, Account account);
    }
}
