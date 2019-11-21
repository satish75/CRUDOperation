using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbContextExample.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbContextExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository employee)
        {
            _repository = employee;
        }

        [HttpGet]
        public IList<Employees> Get()
        {
            var results = _repository.GetAllEmployees();
            return results.ToList();
        }

        [HttpGet]
        [Route("GetById")]
        public Employees GetById(int Id)
        {
            var results = _repository.GetEmployees(Id);
            return results;
        }

        [HttpPost]
        public Employees Add(Employees employees)
        {
            var results = _repository.AddEmployee(employees);
            return results;
        }

        [HttpPut]
        public Employees Update(Employees employees)
        {
            var results = _repository.UpdateEmployee(employees);
            return results;
        }

        [HttpDelete]
        public Employees Delete(int Id)
        {
            var results = _repository.Delete(Id);
            return results;
        }

    }
}