using SibersTetsTask.Server.Model.Project;
using SibersTetsTask.Server.Model.ProjectTask;
using SibersTetsTask.Server.Model.User;

namespace SibersTetsTask.Server.Interface.ProjectInt
{
    public interface IProjectRepository
    {
        Task AddProject(Project project);
        Task <List<ProjectEntity>> GetProjects();
        Task <ProjectEntity> GetProjectById(Guid id);
        Task <bool> Update(Project project);
        Task<bool> Delete(Guid id);
        Task<List<EmployeeEntity>> EmployeesOnProject(Guid id);
        Task<EmployeeEntity> SelectManagerInProject(string name, string email);
        Task <bool>RemoveEmployeeAProject(string projectName, string emailEmployee);
        Task<bool> AddEmployeeAProject(string projectName, string emailEmployee);


    }
}