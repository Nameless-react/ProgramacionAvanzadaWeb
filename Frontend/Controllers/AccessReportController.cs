using Frontend.ApiModel;
using Frontend.Helpers.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    [Authorize]
    public class AccessReportController : Controller
    {

        IAccountHelper _accountHelper;

        private readonly IAccessReportHelper _accessReportHelper;


        public AccessReportController(IAccessReportHelper accessReportHelper)
        {
            _accessReportHelper = accessReportHelper;
        }

        public ActionResult Index()
        {
            _accessReportHelper.Token = HttpContext.Session.GetString("token");
            var reports = _accessReportHelper.GetAllReports();
            return View(reports);
        }


    }
}
