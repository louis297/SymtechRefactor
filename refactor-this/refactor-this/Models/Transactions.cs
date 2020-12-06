using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_this.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public double? Amount { get; set; }
        public DateTime? Date { get; set; }
        public Guid? AccountId { get; set; }
    }
}