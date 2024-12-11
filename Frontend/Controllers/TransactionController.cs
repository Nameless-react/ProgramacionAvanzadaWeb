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
        public TransactionController(ITransactionHelper transactionHelper)
        {
            _transactionHelper = transactionHelper;
        }

        public ActionResult Index()
        {
            var list = _transactionHelper.GetTransactions();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var client = _transactionHelper.Get(id);
            return View(client);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionViewModel transaction)
        {
            try
            {
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
            var transaction = _transactionHelper.Get(id);
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransactionViewModel transaction)
        {
            try
            {
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
            var transaction = _transactionHelper.Get(id);
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TransactionViewModel transaction)
        {
            try
            {
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
