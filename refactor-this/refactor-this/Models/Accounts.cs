using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace refactor_this.Models
{
    public class Account
    {
        //private bool isNew;
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public double Amount { get; set; }

        //public Account()
        //{
        //    isNew = true;
        //}

        //public Account(Guid id)
        //{
        //    isNew = false;
        //    Id = id;
        //}
    }
}