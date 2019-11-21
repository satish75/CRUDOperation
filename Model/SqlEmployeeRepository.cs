using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbContextExample.Model
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public SqlEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employees AddEmployee(Employees employees)
        {
            context.employee.Add(employees);
            context.SaveChanges();
            return employees;
        }

        public Employees Delete(int id)
        {
            Employees employees = context.employee.Find(id);
            if(employees != null)
            {
                context.employee.Remove(employees);
                context.SaveChanges();
            }
            return employees;
        }

        public IEnumerable<Employees> GetAllEmployees()
        {
            return context.employee;
        }

        public Employees GetEmployees(int id)
        {
            return context.employee.Find(id);
        }

        public Employees UpdateEmployee(Employees employee)
        {
            var emp = context.employee.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employee;
        }
    }
}
