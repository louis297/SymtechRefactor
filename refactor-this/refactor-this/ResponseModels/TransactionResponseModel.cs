using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_this.ResponseModels
{
    public class TransactionResponseModel
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionResponseModel(Transaction transaction)
        {
            Amount = (double)transaction.Amount;
            Date = (DateTime)transaction.Date;
        }
    }
}