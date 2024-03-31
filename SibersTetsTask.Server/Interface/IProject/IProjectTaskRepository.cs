using SibersTetsTask.Server.Model.ModelDTO.ProjectTaskDTO;
using SibersTetsTask.Server.Model.ModelEntity.ProjectTask;
using SibersTetsTask.Server.Model.ModelDTO.UserDTO;

namespace SibersTetsTask.Server.Interface.ProjectInt
{
    public interface IProjectTaskRepository
    {
       // Task<List<EmployeeProjectEntity>> GetProjectTaskByEmployee(string emailEmployee);
        Task<List<ProjectTaskEntity>> GetProjectTaskByProject (string projectName);
        Task ProjectTaskAdd(ProjectTaskDTO taskDTO);
        Task <string> ProjectTaskRemove(Guid id);
        Task<string> ProjectTaskAddAEmployee(Guid taskId, Guid employeeId);
        Task<string> ProjectTaskRemoveAEmployee(Guid taskId , Guid employeeId);
        Task<string> ProjectTaskRemoveAProject (Guid taskId , Guid projectId);
        Task<string> ProjectTaskAddAProject (Guid taskId , Guid projectId);
      //  Task<bool> UpdateEmployeeInPtojectTask(string emailEmployee, Guid idTask);
        Task<string> UpdateTaskProject(Guid idTask , ProjectTaskDTO taskDTO);

    }
}