using CSG.Test.WebApi.Commands;
using CSG.Test.WebApi.Models;
using CSG.Test.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSG.Test.WebApi.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentController(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Department> departments = _departmentRepository.GetAll();
            return Ok(departments);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetById(long id)
        {
            Department department = _departmentRepository.Get(id);
            if (department != null)
                return Ok(department);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDeparmentCommand department)
        {
            if (department == null)
                return BadRequest();

            _departmentRepository.Add(new Department
            {
                Name = department.Name,
                Location = department.Location
            });

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] UpdateDepartmentCommand department)
        {
            if (department == null)
                return BadRequest();

            Department dbDepartment = _departmentRepository.Get(id);

            if (dbDepartment == null)
                return NotFound();

            _departmentRepository.Update(dbDepartment, new Department
            {
                Name = department.Name,
                Location = department.Location
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Department department = _departmentRepository.Get(id);
            if (department == null)
                return NotFound();

            _departmentRepository.Delete(department);
            return NoContent();
        }
    }
}