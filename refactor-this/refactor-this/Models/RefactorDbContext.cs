using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace refactor_this.Models
{
    public class RefactorDbContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public RefactorDbContext()
            : base("Default")
        {

        }

        public static RefactorDbContext Create()
        {
            return new RefactorDbContext();
        }
    }
}