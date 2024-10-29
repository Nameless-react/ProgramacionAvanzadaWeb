using Backend.DTO;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
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
        public IActionResult Post([FromBody] AccountDTO accountDTO)
        {
            _accountService.Add(accountDTO);
            return Ok();
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AccountDTO account)
        {
            _accountService.Update(account);
            return Ok();
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var account = new AccountDTO
            {
                AccountId = id
            };
            _accountService.Remove(account);
            return Ok();
        }
    }
}
