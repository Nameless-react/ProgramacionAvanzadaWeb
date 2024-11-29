using Frontend.Helpers.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class AccountController : Controller
    {
        IAccountHelper _accountHelper;

        public AccountController(IAccountHelper accountHelper) 
        { 
            _accountHelper = accountHelper;
        }

        public ActionResult Index() 
        {
            var list = _accountHelper.GetAccounts();
            return View(list);
        }

        public ActionResult Details(int id) 
        {
            var account = _accountHelper.GetAccount(id);
            return View(account);
        }

        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountViewModel account) 
        {
            try
            {
                _accountHelper.Add(account);
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
            }
        }

        public ActionResult Edit(int id) 
        {
            var account = _accountHelper.GetAccount(id);
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountViewModel account) 
        {
            try
            {
                _accountHelper.Update(account);
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {

            var account = _accountHelper.GetAccount(id);

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AccountViewModel account)
        {
            try
            {
                _accountHelper.Delete(account.AccountId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
