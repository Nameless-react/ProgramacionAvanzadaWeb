using Frontend.Helpers.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{

    [Authorize]
    public class ClientController : Controller
    {
        IClientHelper _clientHelper;
        IAccountHelper _accountHelper;
        public ClientController(IClientHelper clientHelper)
        {
            _clientHelper = clientHelper;
        }

        public ActionResult Index()
        {
            _clientHelper.Token = HttpContext.Session.GetString("token");
            var list = _clientHelper.GetClients();
            return View(list);
        }


        public ActionResult Details(int id)
        {
            _clientHelper.Token = HttpContext.Session.GetString("token");
            var client = _clientHelper.Get(id);
            return View(client);
        }


        public ActionResult Create()
        {
            _clientHelper.Token = HttpContext.Session.GetString("token");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel client)
        {
            try
            {
                _clientHelper.Token = HttpContext.Session.GetString("token");
                _clientHelper.Add(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            _clientHelper.Token = HttpContext.Session.GetString("token");
            var client = _clientHelper.Get(id);
            return View(client);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientViewModel client)
        {
            try
            {
                _clientHelper.Token = HttpContext.Session.GetString("token");
                _clientHelper.Update(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            _clientHelper.Token = HttpContext.Session.GetString("token");
            var client = _clientHelper.Get(id);
            return View(client);
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClientViewModel client)
        {
            try
            {
                _clientHelper.Token = HttpContext.Session.GetString("token");
                _clientHelper.Delete(client.ClientId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
