using Core.Application.Services;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            _employeeService.CreateEmployee(employee);
            return Ok();
        }

        [HttpPut("{id}/tasks")]
        public IActionResult AssignTask(int id, string taskName)
        {
            var task = new Core.Domain.Entities.Task { Name = taskName };
            _employeeService.AssignTaskToEmployee(id, task);
            return Ok();
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetAllEmployees(int id)
        {
            var employees = _employeeService.GetAllEmployees();
            
            return Ok(employees.First(n => n.Id==id));
        }
    }
}
