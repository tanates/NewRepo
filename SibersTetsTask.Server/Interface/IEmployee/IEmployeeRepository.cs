using SibersTetsTask.Server.Model.Project;
using SibersTetsTask.Server.Model.User;

namespace SibersTetsTask.Server.Interface.IEmployee
{
    public interface IEmployeeRepository
    {
        Task AddEmployee(Employee employee); 
        Task<List<EmployeeEntity>> GetEmployee();
        Task<EmployeeEntity> GetEmployeeById(Guid id);
        Task Update(Employee employee);
        Task<bool> Delete(Guid id);
        Task<List<ProjectEntity>> GetProjectsEmployee(Guid id);
    }
}