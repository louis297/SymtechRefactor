using refactor_this.Exceptions;
using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_this.Services
{
    public class AccountService: IAccountService
    {
        private RefactorDbContext _dbcontext;

        public AccountService()
        {
            _dbcontext = new RefactorDbContext();
        }

        public void AddAccount(Account account)
        {
            account.Id = Guid.NewGuid();
            _dbcontext.Accounts.Add(account);
            _dbcontext.SaveChanges();
        }

        public void DeleteAccount(Guid ID)
        {
            var account = GetAccountByID(ID);
            if (account == null)
            {
                throw new DataNotExistException("Account not exist");
            }
            _dbcontext.Accounts
                .Remove(account);
            _dbcontext.SaveChanges();
        }
        public Account GetAccountByID(Guid ID)
        {
            try
            {
                return _dbcontext.Accounts
                    .Where(a => a.Id == ID)
                    .FirstOrDefault();
            } catch
            {
                return null;
            }

        }

        public IEnumerable<Account> GetAccounts()
        {
            return _dbcontext.Accounts;
        }

        public void ModifyAccount(Guid ID, Account newAccount)
        {
            var account = GetAccountByID(ID);
            if (account == null)
            {
                throw new DataNotExistException("Account not exist");
            }
            account.Name = newAccount.Name;
            _dbcontext.SaveChanges();

        }
    }
}