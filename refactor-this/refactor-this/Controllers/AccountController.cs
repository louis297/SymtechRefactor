using refactor_this.Exceptions;
using refactor_this.Models;
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
    public class AccountController : ApiController
    {
        private IAccountService _service;

        public AccountController()
        {
            _service = new AccountService();
        }


        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetById(Guid id)
        {
            try
            {
                var account = _service.GetAccountByID(id);
                if(account == null)
                {
                    throw new DataNotExistException("Account not found");
                }
                return Ok(account);
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

        [HttpGet, Route("api/Accounts")]
        public IHttpActionResult Get()
        {
            try
            {
                var accounts = _service.GetAccounts().ToList();
                return Ok(accounts);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult Add(Account account)
        {
            try
            {
                _service.AddAccount(account);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
            
        }

        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult Update(Guid id, Account account)
        {
            try
            {
                if(id != account.Id)
                {
                    return StatusCode(HttpStatusCode.Forbidden);
                }
                _service.ModifyAccount(id, account);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                _service.DeleteAccount(id);
                return Ok();
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
    }
}