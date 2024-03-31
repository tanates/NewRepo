using SibersTetsTask.Server.Context;
using SibersTetsTask.Server.Interface.ProjectInt;
using SibersTetsTask.Server.Model.ModelDTO.ProjectDTO;
using SibersTetsTask.Server.Model.ModelEntity.Project;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.ModelDTO.UserDTO;
using System.Diagnostics.CodeAnalysis;
using SibersTetsTask.Server.Model.ModelEntity.User;

namespace SibersTetsTask.Server.Services
{
    public class ProjectsServisec
    {
       

        private readonly IProjectRepository _projectRepository;
        private readonly IProjectTaskRepository _projectTaskRepository;
        public ProjectsServisec(IProjectRepository projectRepository, IProjectTaskRepository projectTaskRepository)
        {
            _projectRepository = projectRepository;
            _projectTaskRepository = projectTaskRepository;
        }

        public async Task <bool> AddProject(ProjectRequest request)
        {
            try
            {
                var projectAdd = ProjectDTO.Add(request);
                await _projectRepository.AddProject(projectAdd);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<string> Delete(Guid projectId)
        {
            var deletResult = await _projectRepository.Delete(projectId);
           
            return deletResult;
        }
        public async Task<ICollection<EmployeeEntity>> GetEmployInProject(Guid projectId)
        {
            var result = await _projectRepository.GetEmployInProject(projectId);
            return result;
        }
        public async Task<ProjectEntity> GetProjectByName(string projectName)
        {
            var project = await  _projectRepository.GetProjectByName(projectName);
            if (project == null)
            {
                throw new Exception("Not found project");
            }
            return project;

        }

        public async Task<List<ProjectEntity>> GetProjects()
        {
            var projectsListEntity = await _projectRepository.GetProjects();
            if (projectsListEntity == null)
            {
                return new List<ProjectEntity>();
            }



            return projectsListEntity;
        }

        public async Task <string> Update(ProjectRequest request)
        {
           // var projectTask = await _projectTaskRepository.GetProjectTaskByEmployee(request.NameProject);
           // var employeesInProject = await _projectRepository.EmployeesOnProject(request.Id);
            var managerInProject = await _projectRepository.SelectManagerInProject( request.emailEmployee);
            var project = ProjectDTO.Add(request /*, employeesInProject */);
            var result = await _projectRepository.Update(project);


            return result;
        }

        public async Task<string> RemoveEmployeeAProject(Guid projectId, Guid employeeId)
        {
            var result = await _projectRepository.RemoveEmployeeAProject(projectId, employeeId); 
               
            return result  ;

        }

        public async Task<List<EmployeeEntity>> EmployeesOnProject(Guid projectId)
        {
            var result = await _projectRepository.EmployeesOnProject(projectId);
            return result;
        }


    }
}
