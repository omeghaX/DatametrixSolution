using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int employeeId);
        Employee GetById(int employeeId);
        IEnumerable<Employee> GetAll();
    }
}

