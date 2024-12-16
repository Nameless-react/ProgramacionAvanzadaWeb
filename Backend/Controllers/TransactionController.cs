using Backend.DTO;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController :ControllerBase
    {
        ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService) 
        {
            this.transactionService = transactionService;
        }

        [HttpGet]
        public ActionResult Get() 
        { 
            var result = transactionService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = transactionService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public void Post([FromBody] TransactionDTO transactionDTO)
        {
            transactionService.Add(transactionDTO);


        }

        [HttpPut("{id}")]
        public void Put(int id,[FromBody] TransactionDTO transaction)
        {
            transactionService.Edit(transaction);
            

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
            transactionService.Remove(id);
        }
    }
}
