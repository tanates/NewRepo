using SibersTetsTask.Server.Model.ProjectTask;

namespace SibersTetsTask.Server.Interface.ProjectInt
{
    public interface IProjectTaskRepository
    {
        Task ProjectTaskAdd(ProjectTaskDTO taskDTO);
        Task ProjectTaskRemove(Guid id);
        Task ProjectTaskAddAEmployee(Guid taskId , string emailEmployee);
        Task ProjectTaskRemoveAEmployee(Guid taskId , string emailEmployee);
        Task ProjectTaskRemoveAProject (Guid taskId , string nameProject);
        Task ProjectTaskAddAProject (Guid taskId , string nameProject);
    }
}