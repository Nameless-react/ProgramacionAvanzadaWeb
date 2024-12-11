using Frontend.Helpers.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class TransactionReportController : Controller
    {
        ITransactionReportHelper _transactionReportHelper;
        public TransactionReportController(ITransactionReportHelper transactionReportHelper)
        {
            _transactionReportHelper = transactionReportHelper;
        }

        public ActionResult Index()
        {
            var list = _transactionReportHelper.GetTransactions();
            return View(list);
        }

    }
}
