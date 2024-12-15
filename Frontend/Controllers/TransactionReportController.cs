using Frontend.Helpers.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    [Authorize]
    public class TransactionReportController : Controller
    {
        ITransactionReportHelper _transactionReportHelper;
        IAccountHelper _accountHelper;
        public TransactionReportController(ITransactionReportHelper transactionReportHelper)
        {
            _transactionReportHelper = transactionReportHelper;
        }

        public ActionResult Index()
        {
            _transactionReportHelper.Token = HttpContext.Session.GetString("token");
            var list = _transactionReportHelper.GetTransactions();
            return View(list);
        }

    }
}
