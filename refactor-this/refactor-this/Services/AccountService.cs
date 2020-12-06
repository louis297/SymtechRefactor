using refactor_this.Exceptions;
using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_this.Services
{
    /// <summary>
    /// The service layer for <c>AccountController</c>
    /// </summary>
    public class AccountService: IAccountService
    {
        private RefactorDbContext _dbcontext;

        public AccountService()
        {
            _dbcontext = new RefactorDbContext();
        }
        /// <summary>
        /// Insert a new account into database
        /// </summary>
        /// <param name="account">account should be a complete <c>Account</c> data record, except its Id being generated</param>
        public void AddAccount(Account account)
        {
            account.Id = Guid.NewGuid();
            _dbcontext.Accounts.Add(account);
            _dbcontext.SaveChanges();
        }
        /// <summary>
        /// Delete a row from database, should throw <c>DataNotExistException</c> if account not found
        /// </summary>
        /// <param name="ID">ID should be the guid of the account</param>
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
        /// <summary>
        /// Select an account through its ID
        /// </summary>
        /// <param name="ID">ID should be the guid of the account</param>
        /// <returns>The account found or null</returns>
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
        /// <summary>
        /// Select all accounts from database
        /// </summary>
        /// <returns>All accounts from database in <c>IEnumerable</c> format</returns>
        public IEnumerable<Account> GetAccounts()
        {
            return _dbcontext.Accounts;
        }
        /// <summary>
        /// Update an account from database, should throw <c>DataNotExistException</c> if account not found
        /// </summary>
        /// <param name="ID">The ID of the account being modified</param>
        /// <param name="newAccount">newAccount should be a complete <c>Account</c> data record</param>
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