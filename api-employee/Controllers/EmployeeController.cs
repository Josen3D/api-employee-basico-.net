using api_employee.Models;
using api_employee.Services.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace api_employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Employee> employees = await _employeeService.GetEmployees();

                return Ok(employees);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Employee employee = await _employeeService.GetEmployee(id);

                if (employee == null) return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee model)
        {
            try
            {
                var employee = await _employeeService.CreateEmployee(model);

                return Created($"http://localhost:5053/api/employee/{employee.Id}", employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put(Employee model)
        {
            try
            {
                var result = await _employeeService.UpdateEmployee(model);

                if (result == false) return NotFound();

                return Ok($"item updated: {result}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _employeeService.DeleteEmployee(id);

                if (result == false) return NotFound();

                return Ok($"item deleted: {result}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
