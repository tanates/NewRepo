using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SibersTetsTask.Server.Interface.Auth;
using SibersTetsTask.Server.Interface.IEmployee;
using SibersTetsTask.Server.Interface.ProjectInt;
using SibersTetsTask.Server.Model.ModelDTO.UserDTO;
using SibersTetsTask.Server.Model.ModelEntity.User;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.ModelDTO.ProjectDTO;

namespace SibersTetsTask.Server.Services
{
    public class EmployeesServisec
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordHash  _passwordHash;
        private readonly IProjectTaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;
        public EmployeesServisec(IEmployeeRepository employeeRepository, IPasswordHash passwordHash, 
            IProjectTaskRepository taskRepository, IProjectRepository projectRepository)
        {
            _employeeRepository = employeeRepository;
            _passwordHash = passwordHash;
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
        }


        public async Task <ICollection<EmployeeEntity>> GetAllEmployee()
        {
            var employeeListEntity = await _employeeRepository.GetEmployee();
            if (employeeListEntity == null)
            {
                return new List<EmployeeEntity>();
            }
            
            return employeeListEntity;
        }

        public async Task<bool> DeleteEmployee(string  Email) 
        {
            var deletResult = await _employeeRepository.Delete(Email);
            if (deletResult== false)
            {
                return false;
            }
            return deletResult;
        }

        public async Task AddEmployee(EmployeeRequest employee, string password)
        {
            var hashPassword =  _passwordHash.Generate(password);

            var employeeAdd = EmployeeDTO.Add(employee);

            await _employeeRepository.AddEmployee(employeeAdd , hashPassword);
        }

        private async Task<EmployeeEntity> GetEmployeeByEmail(Guid employeeId)
        {
            var employeeById = await _employeeRepository.GetEmployeeByEmail(employeeId);
            if(employeeById == null)
            {
                return new EmployeeEntity();
            }
            return employeeById;
        } //this method serch an employee maybe need 
        public async Task<string> SetEmployeeInProjecc(Guid employeeId, Guid projectId)  //this method adds an employee to the project
        {
        
            var result =await _projectRepository.AddEmployeeAProject(projectId, employeeId);
         

            return result;
        }
        public async Task<string> Update(EmployeeRequest request)
        {
            var employeeDTO = EmployeeDTO.Add(request);
            var resultUpdate = await _employeeRepository.Update(employeeDTO);
          
            return resultUpdate;
        }
    }
}
