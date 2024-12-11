using Backend.DTO;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController :ControllerBase
    {
        IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService) 
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeDTO> Get() 
        { 
            return employeeService.Get();
        }

        [HttpGet("{id}")]
        public EmployeeDTO Get(int id)
        {
            return employeeService.Get(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmployeeDTO employee)
        {
            employeeService.Add(employee);

            return Ok(employee);
        }

        [HttpPut]
        public IActionResult Put([FromBody] EmployeeDTO employee)
        {
            employeeService.Edit(employee);
            return Ok(employee);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EmployeeDTO employee = new EmployeeDTO
            {
                EmployeeID = id
            };
            employeeService.Delete(employee);
        }
    }
}
