using refactor_this.Exceptions;
using refactor_this.Models;
using refactor_this.ResponseModels;
using refactor_this.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace refactor_this.Controllers
{
    public class TransactionController : ApiController
    {
        private ITransactionService _service;

        public TransactionController()
        {
            _service = new TransactionService();
        }

        [HttpGet, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult GetTransactions(Guid id)
        {
            try
            {
                var transactions = _service.GetTransactions(id)
                    .Select(t => new TransactionResponseModel(t))
                    .ToList();
                Console.WriteLine(transactions);
                return Ok(transactions);
            }
            catch (DataNotExistException)
            {
                return NotFound();
            } 
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult AddTransaction(Guid id, Transaction transaction)
        {
            try
            {
                if (id != transaction.AccountId)
                {
                    return StatusCode(HttpStatusCode.Forbidden);
                }
                _service.AddTransaction(id, transaction);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}