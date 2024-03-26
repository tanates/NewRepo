using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SibersTetsTask.Server.Interface.Auth;
using SibersTetsTask.Server.Interface.IEmployee;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.Project;
using SibersTetsTask.Server.Model.User;

namespace SibersTetsTask.Server.Services
{
    public class EmployeesServisec
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordHash  _passwordHash;
        public EmployeesServisec(IEmployeeRepository employeeRepository, IPasswordHash passwordHash)
        {
            _employeeRepository = employeeRepository;
            _passwordHash = passwordHash;
        }


        public async Task <List<EmployeeEntity>> GetAllEmployee()
        {
            var employeeListEntity = await _employeeRepository.GetEmployee();
            if (employeeListEntity == null)
            {
                return new List<EmployeeEntity>();
            }

           
            
            return employeeListEntity;
        }

        public async Task<bool> DeleteEmployee(Guid id) 
        {
            var deletResult = await _employeeRepository.Delete(id);
            if (deletResult== false)
            {
                return false;
            }
            return deletResult;
        }

        public async Task AddEmployee(EmployeeRequest employee, string password)
        {
            var projects  = await _employeeRepository.GetProjectsEmployee(employee.Id);

            var hashPassword = _passwordHash.Generate(password);

            var employeeAdd = Employee.Add(employee, projects, hashPassword);

            await _employeeRepository.AddEmployee(employeeAdd);
        }

 
        public async Task<EmployeeEntity> GetEmployeeById(Guid id)
        {
            var employeeById = await _employeeRepository.GetEmployeeById(id);
            if(employeeById == null)
            {
                return new EmployeeEntity();
            }
            return employeeById;
        }

        public Task Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
