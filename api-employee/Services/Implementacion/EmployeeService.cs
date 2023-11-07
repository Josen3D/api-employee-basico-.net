using api_employee.Models;
using api_employee.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace api_employee.Services.Implementacion
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CompanydbContext _dbContext;
        public EmployeeService(CompanydbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            return employee;
        }

        public async Task<Employee> CreateEmployee(Employee model)
        {
            var employee = await _dbContext.Employees.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return employee.Entity;
        }

        public async Task<bool> UpdateEmployee(Employee model)
        {
            var employee = await _dbContext.Employees.FindAsync(model.Id);

            if (employee == null) return false;

            employee.Name = model.Name;
            employee.Salary = model.Salary;

            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee == null) return false;

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        
    }
}
