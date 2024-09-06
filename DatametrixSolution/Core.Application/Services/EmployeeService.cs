using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Domain.Entities;
using Core.Domain.Repositories;

namespace Core.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void CreateEmployee(Employee employee)
        {
            _employeeRepository.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.Update(employee);
        }

        public void AssignTaskToEmployee(int employeeId, Domain.Entities.Task task)
        {
            var employee = _employeeRepository.GetById(employeeId);
            if (employee != null && employee.CanAssignTask(task))
            {
                employee.AssignTask(task);
                _employeeRepository.Update(employee);
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            _employeeRepository.Delete(employeeId);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }
    }
}

