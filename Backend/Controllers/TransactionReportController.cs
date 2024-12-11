using Backend.DTO;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionReportController :ControllerBase
    {
        ITransactionReportService transactionReportService;

        public TransactionReportController(ITransactionReportService transactionReportService) 
        {
            this.transactionReportService = transactionReportService;
        }

        [HttpGet]
        public IEnumerable<TransactionReportDTO> Get() 
        { 
            return transactionReportService.Get();
        }

        [HttpGet("{id}")]
        public TransactionReportDTO Get(int id)
        {
            return transactionReportService.Get(id);
        }
    }
}
