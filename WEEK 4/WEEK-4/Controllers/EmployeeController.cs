using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")] // Requires JWT token with Admin role
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John Doe",
                Salary = 50000,
                Permanent = true,
                DateOfBirth = new DateTime(1990, 5, 1),
                Department = new Department { Id = 101, Name = "IT" },
                Skills = new List<Skill>
                {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = "SQL" }
                }
            }
        };

        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            return Ok(_employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound($"Employee with id {id} not found.");
            return Ok(emp);
        }

        [HttpPost]
        public ActionResult<Employee> Create([FromBody] Employee newEmp)
        {
            newEmp.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(newEmp);
            return CreatedAtAction(nameof(GetById), new { id = newEmp.Id }, newEmp);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Update(int id, [FromBody] Employee updatedEmp)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return BadRequest("Invalid employee id");

            emp.Name = updatedEmp.Name;
            emp.Salary = updatedEmp.Salary;
            emp.Permanent = updatedEmp.Permanent;
            emp.Department = updatedEmp.Department;
            emp.Skills = updatedEmp.Skills;
            emp.DateOfBirth = updatedEmp.DateOfBirth;

            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found.");

            _employees.Remove(emp);
            return NoContent();
        }
    }
}
