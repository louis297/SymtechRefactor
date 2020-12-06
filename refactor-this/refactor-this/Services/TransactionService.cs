using refactor_this.Exceptions;
using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_this.Services
{
    public class TransactionService: ITransactionService
    {
        private RefactorDbContext _dbcontext;

        public TransactionService()
        {
            _dbcontext = new RefactorDbContext();
        }

        public void AddTransaction(Guid ID, Transaction transaction)
        {
            var account = GetAccountByID(ID);
            if (account == null)
            {
                throw new DataNotExistException("Account not exist");
            }
            var transactionFound = _dbcontext.Transactions
                .Where(t => t.Id == transaction.Id)
                .FirstOrDefault();
            if (transactionFound == null)
            {
                transaction.Id = Guid.NewGuid();
                _dbcontext.Transactions.Add(transaction);
            } else
            {
                transactionFound.Amount += transaction.Amount;
            }
            _dbcontext.SaveChanges();
        }

        public IEnumerable<Transaction> GetTransactions(Guid ID)
        {
            var account = GetAccountByID(ID);
            if(account == null)
            {
                throw new DataNotExistException("Account not exist");
            }
            return _dbcontext.Transactions
                .Where(t => t.AccountId == ID);
        }

        private Account GetAccountByID(Guid ID)
        {
            return _dbcontext.Accounts
                    .Where(a => a.Id == ID)
                    .FirstOrDefault();
        }
    }
}