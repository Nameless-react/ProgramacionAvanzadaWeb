using Backend.DTO;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public IEnumerable<TransactionDTO> Get() 
        { 
            return transactionService.Get();
        }

        [HttpGet("{id}")]
        public TransactionDTO Get(int id)
        {
            return transactionService.Get(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TransactionDTO transaction)
        {
            transactionService.Add(transaction);

            return Ok(transaction);
        }

        [HttpPut]
        public IActionResult Put([FromBody] TransactionDTO transaction)
        {
            transactionService.Edit(transaction);
            return Ok(transaction);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TransactionDTO transaction = new TransactionDTO
            {
                TransactionId = id
            };
            transactionService.Delete(transaction);
        }
    }
}
