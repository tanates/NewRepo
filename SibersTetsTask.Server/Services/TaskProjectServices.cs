using Microsoft.EntityFrameworkCore;
using SibersTetsTask.Server.Interface.ProjectInt;
using SibersTetsTask.Server.Model.ModelDTO.ProjectTaskDTO;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.ModelDTO.UserDTO;

namespace SibersTetsTask.Server.Services
{
    public class TaskProjectServices
    {
        private readonly IProjectTaskRepository _projectTaskRepository;

        public TaskProjectServices(IProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }


        public async Task AddProjectTask(ProjectTaskRequest request)
        {
            var taskDto = ProjectTaskDTO.Add(request);
            await _projectTaskRepository.ProjectTaskAdd(taskDto);

        }

        public async Task<string> ProjectTaskAddAEmployee(Guid projectId , Guid employeeId)
        {
            var result =  await _projectTaskRepository.ProjectTaskAddAEmployee(projectId, employeeId);
            return result; 
        }

        public async  Task<string> ProjectTaskAddAProject(Guid taskId, Guid projecId)
        {
           
            var result = await _projectTaskRepository.ProjectTaskAddAProject(taskId, projecId);
            return result;
        }
        public async Task <string>ProjectTaskRemove(Guid id)
        {
          var result = await _projectTaskRepository.ProjectTaskRemove(id);
            
          return result;
        }
        public async Task <string> ProjectTaskRemoveAEmployee(Guid taskId, Guid employeeId)
        {
             var result = await _projectTaskRepository.ProjectTaskRemoveAEmployee(taskId, employeeId);
         
            return result;
        }
        public async Task<string> ProjectTaskRemoveAProject(Guid taskId, Guid projecId)
        {
            var result = await _projectTaskRepository.ProjectTaskRemoveAProject(taskId, projecId);
           
            return result;
        }
  
        public Task<bool> UpdateTaskProject(Guid idTask, ProjectTaskDTO taskDTO)
        {
            throw new NotImplementedException();
        }
    }
}
