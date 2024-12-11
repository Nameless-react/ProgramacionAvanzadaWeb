using Frontend.Helpers.Interface;
using FrontEnd.Helpers.Implementations;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Frontend.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        IEmployeeHelper _employeeHelper;
        public EmployeeController(IEmployeeHelper employeeHelper)
        {
            _employeeHelper = employeeHelper;
        }

        public ActionResult Index()
        {
            var list = _employeeHelper.GetEmployees();
            return View(list);
        }


        public ActionResult Details(int id)
        {
            var employee = _employeeHelper.GetEmployee(id);
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employee)
        {
            try
            {
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
            var employee = _employeeHelper.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel employee)
        {
            try
            {
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
            var employee = _employeeHelper.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeViewModel employee)
        {
            try
            {
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
