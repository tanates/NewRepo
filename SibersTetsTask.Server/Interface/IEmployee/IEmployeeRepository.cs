using SibersTetsTask.Server.Model.ModelDTO.UserDTO;
using SibersTetsTask.Server.Model.ModelEntity.Project;
using SibersTetsTask.Server.Model.ModelEntity.User;

namespace SibersTetsTask.Server.Interface.IEmployee
{
    public interface IEmployeeRepository
    {
        Task AddEmployee(EmployeeDTO employee , string hashPassword); 
        Task<List<EmployeeEntity>> GetEmployee();
        Task<EmployeeEntity> GetEmployeeByEmail(Guid id);
        Task <string> Update(EmployeeDTO employee);
        Task<bool> Delete(string email);
        Task<List<ProjectEntity>> GetProjectsEmployee(Guid id);
    }
}