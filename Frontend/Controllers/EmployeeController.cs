using Frontend.ApiModel;
using Frontend.Helpers.Interface;
using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        IEmployeeHelper _employeeHelper;
        IAccountHelper _accountHelper;
        public EmployeeController(IEmployeeHelper employeeHelper)
        {
            _employeeHelper = employeeHelper;
        }

        public ActionResult Index()
        {
            _employeeHelper.Token = HttpContext.Session.GetString("token");
            var list = _employeeHelper.GetEmployees();
            return View(list);
        }


        public ActionResult Details(int id)
        {
            _employeeHelper.Token = HttpContext.Session.GetString("token");
            var employee = _employeeHelper.GetEmployee(id);
            return View(employee);
        }

        public ActionResult Create()
        {
            _employeeHelper.Token = HttpContext.Session.GetString("token");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employee)
        {
            try
            {
                _employeeHelper.Token = HttpContext.Session.GetString("token");
                _employeeHelper.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            _employeeHelper.Token = HttpContext.Session.GetString("token");
            var employee = _employeeHelper.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel employee)
        {
            try
            {
                _employeeHelper.Token = HttpContext.Session.GetString("token");
                _employeeHelper.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            _employeeHelper.Token = HttpContext.Session.GetString("token");
            var employee = _employeeHelper.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeViewModel employee)
        {
            try
            {
                _employeeHelper.Token = HttpContext.Session.GetString("token");
                _employeeHelper.DeleteEmployee(employee.EmployeeID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
