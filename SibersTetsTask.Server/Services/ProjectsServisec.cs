using SibersTetsTask.Server.Context;
using SibersTetsTask.Server.Interface.ProjectInt;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.Project;
using SibersTetsTask.Server.Model.User;
using System.Diagnostics.CodeAnalysis;

namespace SibersTetsTask.Server.Services
{
    public class ProjectsServisec
    {
       

        private readonly IProjectRepository _projectRepository;

        public ProjectsServisec(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task AddProject(ProjectRequest request, string email , string nameEmployee)
        {
            var employeesInProject = await _projectRepository.EmployeesOnProject(request.Id);
            var managerInProject = await _projectRepository.SelectManagerInProject(nameEmployee, email);
            var projectAdd = Project.Add(request, managerInProject, employeesInProject);
            await _projectRepository.AddProject(projectAdd);
        }

        public async Task<bool> Delete(Guid id)
        {
            var deletResult = await _projectRepository.Delete(id);
            if (deletResult == false)
            {
                return false;
            }
            return deletResult;
        }

        public async Task<ProjectEntity> GetProjectById(Guid id)
        {
            var project = await  _projectRepository.GetProjectById(id);
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

        public async Task <bool> Update(Project project)
        {
            var result = await _projectRepository.Update(project);

            if (result == false)
            {
                throw new Exception("The update was not successful");
            }

            return result;
        }

        public async Task<bool> RemoveEmployeeAProject(string projectName , string emailEmployee)
        {
            var result = await _projectRepository.RemoveEmployeeAProject(projectName, emailEmployee); 
               
            return result ? throw new Exception("Deleting an employee from a project was not successful"):true ;

        }
        public async Task<bool> AddEmployeeAProject(string projectName, string emailEmployee)
        {
            var result = await _projectRepository.AddEmployeeAProject(projectName, emailEmployee);

            return result ? throw new Exception("Adding an employee from a project was not successful") : true;

        }
    }
}
