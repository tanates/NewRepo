using Microsoft.EntityFrameworkCore;
using SibersTetsTask.Server.Context;
using SibersTetsTask.Server.Interface.ProjectInt;
using SibersTetsTask.Server.Model.Project;
using SibersTetsTask.Server.Model.User;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

namespace SibersTetsTask.Server.Repository
{
    public class ProjectRepository :IProjectRepository
    {
        private readonly ApplicationContext _context;

        public ProjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddProject(Project project)
        {

            if(await _context.Projects.AnyAsync(
                 i=>i.NameProject==project.NameProject &&            // checking if the project is already in the database
               i.CustomerCompany == project.CustomerCompany))
            {
                throw new Exception("This project already exists");
            }

            var projectEntity = new ProjectEntity // adding new project 
            {
                Id = project.Id,
                NameProject = project.NameProject,
                EndDateProject = project.EndDateProject,
                StartDateProject = project.StartDateProject,
                ExecutingCompany = project.ExecutingCompany,
                CustomerCompany = project.CustomerCompany,
                TeamMembers = project.TeamMembers,
                ProjectManager = project.ProjectManager,
                PriorityProject = project.PriorityProject,
            };
            await _context.Projects.AddAsync(projectEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return false ;
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<EmployeeEntity>> EmployeesOnProject(Guid projectId)
        {
            var membersTeam = await _context.Projects
           .Include(e => e.TeamMembers) // Uploading related project employees
           .FirstOrDefaultAsync(e => e.Id == projectId);

            if (membersTeam == null)
            {
                return new List<EmployeeEntity>();
            }

            return membersTeam.TeamMembers.ToList();
        }

        public async Task <EmployeeEntity> SelectManagerInProject(string name , string email)
        {
            var manager = await _context.Employees.FirstOrDefaultAsync(i=>i.Name== name && i.Email ==email);
           
            if(manager == null)
            {
                return new EmployeeEntity();
            }
            manager.PostEmployee = "Manager";
            _context.Update(manager);
            await _context.SaveChangesAsync();
            return manager;
        }
        public async Task<ProjectEntity> GetProjectById(Guid id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(i=>i.Id == id) ?? throw new Exception("Project not found by id");
            return project;
            
        }

        public async Task<List<ProjectEntity>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task <bool> Update(Project projectDTO)
        {
            var project = await _context.Projects.Include(p => p.ProjectManager).Include(p => p.TeamMembers)
                                         .FirstOrDefaultAsync(p => p.Id == projectDTO.Id) ?? throw new Exception("Project not found.");
            switch (projectDTO)
            {
                case { NameProject: not null }:
                    project.NameProject = projectDTO.NameProject;
                    break;
                case { ExecutingCompany: not null }:
                    project.ExecutingCompany = projectDTO.ExecutingCompany;
                    break;
                case { CustomerCompany: not null }:
                    project.CustomerCompany = projectDTO.CustomerCompany;
                    break;
                case { EndDateProject: var endDate } when endDate != DateTime.MinValue:
                    project.EndDateProject = projectDTO.EndDateProject;
                    break;
                case { PriorityProject: not 0 }:
                    project.PriorityProject = projectDTO.PriorityProject;
                    break;
                case { ProjectManager: not null }:
                    project.ProjectManager = projectDTO.ProjectManager;
                    break;
                case { TeamMembers: not null } when projectDTO.TeamMembers.Any():
                    var teamMembersIds = projectDTO.TeamMembers.Select(e => e.Id).ToList();
                    project.TeamMembers = await _context.Employees.Where(e => teamMembersIds.Contains(e.Id)).ToListAsync();
                    break;
            }

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveEmployeeAProject(string projectName, string emailEmployee)
        {
            var project = await _context.Projects.Include(p => p.TeamMembers)
                                       .FirstOrDefaultAsync(p => p.NameProject == projectName) ?? throw new Exception("Project not found.");
            var employeeToRemove = project.TeamMembers.FirstOrDefault(e => e.Email == emailEmployee) ?? throw new Exception("Employee not found.");

             project.TeamMembers.Remove(employeeToRemove);
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> AddEmployeeAProject(string projectName, string emailEmployee)
        {
            var project = await _context.Projects.Include(p => p.TeamMembers)
                                       .FirstOrDefaultAsync(p => p.NameProject == projectName) ?? throw new Exception("Project not found.");
            var employeeToAdd = project.TeamMembers.FirstOrDefault(e => e.Email == emailEmployee) ?? throw new Exception("Employee not found.");

            project.TeamMembers.Add(employeeToAdd);
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
