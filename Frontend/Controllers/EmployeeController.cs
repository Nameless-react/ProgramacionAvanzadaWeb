using Frontend.Helpers.Interface;
using FrontEnd.Helpers.Implementations;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeHelper _employeeHelper;

        public EmployeeController(IEmployeeHelper employeeHelper) 
        {
            _employeeHelper = employeeHelper;
        }

        //Get: EmployeeController
        public ActionResult Index() 
        { 
            var list = _employeeHelper.GetEmployees();
            return View(list);
        }

        // Get: EmployeeController/Details
        public ActionResult Details(int id) 
        { 
            var employee = _employeeHelper.GetEmployee(id);
            return View(employee);
        }

        //Get: EmployeeController/Create
        public ActionResult Create() 
        { 
            return View();
        }

        //Post: EmployeeController/Create
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

        //Get: EmployeeController/Edit
        public ActionResult Edit(int id) 
        {
            var employee = _employeeHelper.GetEmployee(id);
            return View(employee);
        }

        //Post: EmployeeController/Edit
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

        //Get: EmployeeController/Delete
        public ActionResult Delete(int id)
        {
            var employee = _employeeHelper.GetEmployee(id);
            return View(employee);
        }

        //Post: EmployeeController/Delete
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
