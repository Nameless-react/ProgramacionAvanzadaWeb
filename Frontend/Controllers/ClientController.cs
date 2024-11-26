using Frontend.Helpers.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ClientController : Controller
    {
        IClientHelper _clientHelper;
        public ClientController(IClientHelper clientHelper)
        {
            _clientHelper = clientHelper;
        }
        // GET: ClientController
        public ActionResult Index()
        {
            var list = _clientHelper.GetClients();
            return View(list);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {   
            var client = _clientHelper.Get(id);
            return View(client);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel client)
        {
            try
            {
                _clientHelper.Add(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _clientHelper.Get(id);
            return View(client);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientViewModel client)
        {
            try
            {
                _clientHelper.Update(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            var client = _clientHelper.Get(id);
            return View(client);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClientViewModel client)
        {
            try
            {
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
