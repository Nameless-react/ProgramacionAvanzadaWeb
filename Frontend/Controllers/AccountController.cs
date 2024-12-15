using Frontend.Helpers.Implementations;
using Frontend.Helpers.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        IAccountHelper _accountHelper;

        public AccountController(IAccountHelper accountHelper) 
        { 
            _accountHelper = accountHelper;
        }

        public ActionResult Index() 
        {
            _accountHelper.Token = HttpContext.Session.GetString("token");
            var list = _accountHelper.GetAccounts();
            return View(list);
        }

        public ActionResult Details(int id) 
        {
            _accountHelper.Token = HttpContext.Session.GetString("token");
            var account = _accountHelper.GetAccount(id);
            return View(account);
        }

        public ActionResult Create() 
        {
            _accountHelper.Token = HttpContext.Session.GetString("token");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountViewModel account) 
        {
            try
            {
                _accountHelper.Token = HttpContext.Session.GetString("token");
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
            _accountHelper.Token = HttpContext.Session.GetString("token");
            var account = _accountHelper.GetAccount(id);
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountViewModel account) 
        {
            try
            {
                _accountHelper.Token = HttpContext.Session.GetString("token");
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
            _accountHelper.Token = HttpContext.Session.GetString("token");
            var account = _accountHelper.GetAccount(id);

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AccountViewModel account)
        {
            try
            {
                _accountHelper.Token = HttpContext.Session.GetString("token");
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
