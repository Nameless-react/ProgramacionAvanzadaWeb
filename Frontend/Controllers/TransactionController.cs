using Frontend.Helpers.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        ITransactionHelper _transactionHelper;
        IAccountHelper _accountHelper;
        public TransactionController(ITransactionHelper transactionHelper)
        {
            _transactionHelper = transactionHelper;
        }

        public ActionResult Index()
        {
            _transactionHelper.Token = HttpContext.Session.GetString("token");
            var list = _transactionHelper.GetTransactions();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            _transactionHelper.Token = HttpContext.Session.GetString("token");
            var client = _transactionHelper.Get(id);
            return View(client);
        }

        public ActionResult Create()
        {
            _transactionHelper.Token = HttpContext.Session.GetString("token");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionViewModel transaction)
        {
            try
            {
                _transactionHelper.Token = HttpContext.Session.GetString("token");
                _transactionHelper.Add(transaction);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            _transactionHelper.Token = HttpContext.Session.GetString("token");
            var transaction = _transactionHelper.Get(id);
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransactionViewModel transaction)
        {
            try
            {
                _transactionHelper.Token = HttpContext.Session.GetString("token");
                _transactionHelper.Update(transaction);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            _transactionHelper.Token = HttpContext.Session.GetString("token");
            var transaction = _transactionHelper.Get(id);
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TransactionViewModel transaction)
        {
            try
            {
                _transactionHelper.Token = HttpContext.Session.GetString("token");
                _transactionHelper.Delete(transaction.TransactionId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
