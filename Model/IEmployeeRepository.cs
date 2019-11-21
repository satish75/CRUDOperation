using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbContextExample.Model
{
   public interface IEmployeeRepository
    {
        Employees GetEmployees(int id);
        IEnumerable<Employees> GetAllEmployees();
        Employees AddEmployee(Employees employees);
        Employees UpdateEmployee(Employees employees);
        Employees Delete(int id);
    }
}
