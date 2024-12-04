using Backend.DTO;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        // GET: api/<AccountsController>
        [HttpGet]
        public ActionResult Get()
        {
            var result = _accountService.GetAll();
            return Ok(result);
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _accountService.Get(id);
            return Ok(result);
        }

        // POST api/<AccountsController>
        [HttpPost]
        public void Post([FromBody] AccountDTO accountDTO)
        {
            _accountService.Add(accountDTO);

        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AccountDTO account)
        {
            _accountService.Update(account);
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AccountDTO account = new AccountDTO
            {
                AccountId = id
            };
            _accountService.Remove(account);
        }
    }
}
