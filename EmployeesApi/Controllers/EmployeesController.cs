using com.test.employees.api.Models;
using com.test.employees.api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace com.test.employees.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _EmployeeService;

        public EmployeesController(EmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get() =>
            _EmployeeService.Get();

        [HttpGet("{id:length(24)}", Name = "GetEmployee")]
        public ActionResult<Employee> Get(string id)
        {
            var Employee = _EmployeeService.Get(id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Employee;
        }

        [HttpPost]
        public ActionResult<Employee> Create(Employee Employee)
        {
            _EmployeeService.Create(Employee);

            return CreatedAtRoute("GetEmployee", new { id = Employee.Id.ToString() }, Employee);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Employee EmployeeIn)
        {
            var Employee = _EmployeeService.Get(id);

            if (Employee == null)
            {
                return NotFound();
            }

            _EmployeeService.Update(id, EmployeeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Employee = _EmployeeService.Get(id);

            if (Employee == null)
            {
                return NotFound();
            }

            _EmployeeService.Remove(id);

            return NoContent();
        }
    }
}
