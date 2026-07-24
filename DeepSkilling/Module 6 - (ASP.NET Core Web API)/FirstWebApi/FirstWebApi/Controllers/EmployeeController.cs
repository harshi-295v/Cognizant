using FirstWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> employees;

        public EmployeeController()
        {
            employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Rahul",
                    Salary = 50000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1998,5,10),
                    Department = new Department
                    {
                        Id = 101,
                        Name = "IT"
                    },
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new Skill
                        {
                            Id = 2,
                            Name = "SQL"
                        }
                    }
                },

                new Employee
                {
                    Id = 2,
                    Name = "Priya",
                    Salary = 45000,
                    Permanent = false,
                    DateOfBirth = new DateTime(1999,8,15),
                    Department = new Department
                    {
                        Id = 102,
                        Name = "HR"
                    },
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Id = 3,
                            Name = "Communication"
                        }
                    }
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return BadRequest("Invalid employee id");

            employee.Name = updatedEmployee.Name;
            employee.Salary = updatedEmployee.Salary;
            employee.Permanent = updatedEmployee.Permanent;
            employee.Department = updatedEmployee.Department;
            employee.Skills = updatedEmployee.Skills;
            employee.DateOfBirth = updatedEmployee.DateOfBirth;

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return BadRequest("Invalid employee id");

            employees.Remove(employee);

            return Ok("Employee deleted successfully");
        }
    }
}