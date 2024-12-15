using Frontend.ApiModel;
using Frontend.Helpers.Interface;
using Frontend.Models;
using FrontEnd.Helpers.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel;

namespace FrontEnd.Helpers.Implementations
{
    public class EmployeeHelper : IEmployeeHelper
    {
        IServiceRepository _ServiceRepository;
        public string Token { get; set; }
        public EmployeeHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }
        Employee Convertir(EmployeeViewModel employee)
        {
            return new Employee
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                IDNumber = employee.IDNumber,
                Phone = employee.Phone,
                Address = employee.Address,
                Email = employee.Email,
                HireDate = employee.HireDate,
                Position = employee.Position


            };
        }

        public EmployeeViewModel AddEmployee(EmployeeViewModel employee)
        {
            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Employee", Convertir(employee));
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return employee;
        }

        public void DeleteEmployee(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Employee/" + id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content;
            }
        }

        public EmployeeViewModel GetEmployee(int id)
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Employee/" + id.ToString());
            Employee employee = new Employee();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<Employee>(content);
            }
            EmployeeViewModel resultado = new EmployeeViewModel
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                IDNumber = employee.IDNumber,
                Phone = employee.Phone,
                Address = employee.Address,
                Email = employee.Email,
                HireDate = employee.HireDate,
                Position = employee.Position
            };
            return resultado;
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            _ServiceRepository.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Employee");
            List<Employee> employees = new List<Employee>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<Employee>>(content);
            }
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            foreach (var item in employees)
            {
                result.Add(
                    new EmployeeViewModel
                    {
                        EmployeeID = item.EmployeeID,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        IDNumber = item.IDNumber,
                        Phone = item.Phone,
                        Address = item.Address,
                        Email = item.Email,
                        HireDate = item.HireDate,
                        Position = item.Position
                    }
                    );
            }
            return result;
        }

        public EmployeeViewModel UpdateEmployee(EmployeeViewModel employee)
        {
            HttpResponseMessage response = _ServiceRepository.PutResponse("api/Client/" + employee.EmployeeID.ToString(), Convertir(employee));
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

            }
            return employee;
        }
    }
}
