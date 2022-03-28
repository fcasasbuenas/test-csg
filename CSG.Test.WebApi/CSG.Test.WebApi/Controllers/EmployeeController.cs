using CSG.Test.WebApi.Commands;
using CSG.Test.WebApi.Models;
using CSG.Test.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSG.Test.WebApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeController(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(long id)
        {
            Employee employee = _employeeRepository.Get(id);
            if (employee != null)
                return Ok(employee);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateEmployeeCommand employee)
        {
            if (employee == null)
                return BadRequest();

            _employeeRepository.Add(new Employee
            {
                Name = employee.Name,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId
            });

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] UpdateEmployeeCommand employee)
        {
            if (employee == null)
                return BadRequest();

            Employee dbEmployee = _employeeRepository.Get(id);

            if (dbEmployee == null)
                return NotFound();

            _employeeRepository.Update(dbEmployee, new Employee
            {
                Name = employee.Name,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId
            });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Employee employee = _employeeRepository.Get(id);
            if (employee == null)
                return NotFound();

            _employeeRepository.Delete(employee);
            return NoContent();
        }
    }
}