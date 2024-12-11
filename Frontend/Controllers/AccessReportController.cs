using Frontend.ApiModel;
using Frontend.Helpers.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class AccessReportController : Controller
    {
        // Declaración única del campo _accessReportHelper
        private readonly IAccessReportHelper _accessReportHelper;

        // Constructor para inyección de dependencias
        public AccessReportController(IAccessReportHelper accessReportHelper)
        {
            _accessReportHelper = accessReportHelper;
        }

        // GET: AccessReportController
        public ActionResult Index()
        {
            var reports = _accessReportHelper.GetAllReports();
            return View(reports);
        }

        // GET: AccessReportController/Details
        public ActionResult Details(int id)
        {
            var report = _accessReportHelper.GetReport(id);
            if (report == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        // GET: AccessReportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccessReportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccessReportViewModel accessReport)
        {
            try
            {
                _accessReportHelper.AddReport(accessReport);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
