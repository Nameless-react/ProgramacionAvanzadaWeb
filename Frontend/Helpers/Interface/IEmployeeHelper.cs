using Frontend.ApiModel;
using Frontend.Models;

namespace Frontend.Helpers.Interface
{
    public interface IEmployeeHelper
    {
        List<EmployeeViewModel> GetEmployees();
        string Token { get; set; }
        EmployeeViewModel GetEmployee(int id);
        EmployeeViewModel AddEmployee(EmployeeViewModel employee);
        EmployeeViewModel UpdateEmployee(EmployeeViewModel employee);
        void DeleteEmployee(int id);
    }
}
