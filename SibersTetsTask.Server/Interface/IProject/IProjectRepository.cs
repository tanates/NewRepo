using SibersTetsTask.Server.Model.ModelDTO.ProjectDTO;
using SibersTetsTask.Server.Model.ModelEntity.Project;
using SibersTetsTask.Server.Model.ModelEntity.User;
using SibersTetsTask.Server.Model.ModelDTO.ProjectTaskDTO;
using SibersTetsTask.Server.Services;
using SibersTetsTask.Server.Model.ModelRequest;

namespace SibersTetsTask.Server.Interface.ProjectInt
{
    public interface IProjectRepository
    {
        Task AddProject(ProjectDTO project);
        Task <List<ProjectEntity>> GetProjects();
        Task <ProjectEntity> GetProjectByName(string projectName);
        Task <string> Update(ProjectDTO project);
        Task<string> Delete(Guid ProjectID);
        Task<List<EmployeeEntity>> EmployeesOnProject(Guid id);
        Task<EmployeeEntity> SelectManagerInProject( string email);
        Task <string>RemoveEmployeeAProject(Guid employeeID, Guid ProjectID);
        Task<string> AddEmployeeAProject(Guid employeeID, Guid ProjectID);

        Task<ICollection<EmployeeEntity>> GetEmployInProject(Guid projectId);


    }
}