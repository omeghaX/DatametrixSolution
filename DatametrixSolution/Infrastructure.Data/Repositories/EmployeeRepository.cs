using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Domain.Entities;
using Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(int employeeId)
        {
            var employee = _context.Employees
                .Include(e => e.Tasks) // Incluye las tareas relacionadas
                .FirstOrDefault(e => e.Id == employeeId);

            if (employee != null)
            {
                _context.Tasks.RemoveRange(employee.Tasks);

                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public Employee GetById(int employeeId)
        {
            return _context.Employees.Include(e => e.Tasks).FirstOrDefault(e => e.Id == employeeId);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Include(e => e.Tasks).ToList();
        }
    }
}

