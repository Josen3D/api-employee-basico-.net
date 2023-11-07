using api_employee.Models;

namespace api_employee.Services.Contrato
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(int id);
        public Task<Employee> CreateEmployee(Employee model);
        public Task<bool> UpdateEmployee(Employee model);
        public Task<bool> DeleteEmployee(int id);
    }
}
