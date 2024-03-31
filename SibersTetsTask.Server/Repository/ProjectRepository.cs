using Microsoft.EntityFrameworkCore;
using SibersTetsTask.Server.Context;
using SibersTetsTask.Server.Interface.ProjectInt;
using SibersTetsTask.Server.Model.ModelDTO.ProjectDTO;
using SibersTetsTask.Server.Model.ModelEntity.Project;
using SibersTetsTask.Server.Model.ModelEntity.User;
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

        public async Task AddProject(ProjectDTO project) 
        {

            if(await _context.Projects.AnyAsync(
                 i=>i.Name==project.NameProject &&            // checking if the project is already in the database
               i.CustomerName == project.CustomerCompany))
            {
                throw new Exception("This project already exists");
            }

            var projectEntity = new ProjectEntity // adding new project 
            {
                Id = project.Id,
                Name = project.NameProject,
                EndDate = project.EndDateProject,
                StartDate = project.StartDateProject,
                ExecutorName = project.ExecutingCompany,
                CustomerName = project.CustomerCompany,
                Priority = project.PriorityProject,
                ProjectManagerId = null,
                Employees = null,
                ProjectManager = null,
                Tasks = null
            };
            await _context.Projects.AddAsync(projectEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<string> Delete(Guid ProjectID)
        {
            try
            {
                var project = await _context.Projects.FirstOrDefaultAsync(i => i.Id == ProjectID);
                if (project == null)
                {
                    return "The project was not found to be deleted";
                }

                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();

                return "The deletion has been completed";
            }
            catch (Exception ex)
            {

                return $"The project was not error to be deleted : {ex.Message} ";
            }
            
        }

        public async Task<List<EmployeeEntity>> EmployeesOnProject(Guid projectId)
        {
            var project = await _context.Projects.Include(p => p.Employees).FirstOrDefaultAsync(p => p.Id == projectId);

            var allEmployees = await _context.Employees.ToListAsync();
            var assignedEmployees = project.Employees?.Select(e => e.Id).ToList() ?? new List<Guid>();

            var unassignedEmployees = allEmployees.Where(e => !assignedEmployees.Contains(e.Id)).ToList();

            return unassignedEmployees;
        }

       public async Task <EmployeeEntity> SelectManagerInProject(string email)
        {
            var manager = await _context.Employees
                .FirstOrDefaultAsync(i => i.Email == email)
                ??throw new Exception("employee not found!!Error method SelectManager");
            
            return manager;
        }
        public async Task<ProjectEntity> GetProjectByName(string projectName)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(i=>i.Name== projectName) ?? throw new Exception("Project not found by id");
            return project;
            
        }

        public async Task<List<ProjectEntity>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task <string> Update(ProjectDTO projectDTO)
        {
            try
            {
                var project = await _context.Projects.FindAsync(projectDTO.Id) ?? throw new Exception("Project not found");

                project.Name = projectDTO.NameProject ?? project.Name;
                project.CustomerName = projectDTO.CustomerCompany ?? project.CustomerName;
                project.ExecutorName = projectDTO.ExecutingCompany ?? project.ExecutorName;
                if (projectDTO.StartDateProject != null)
                {
                    project.StartDate = projectDTO.StartDateProject.Value;
                }
                if (projectDTO.EndDateProject != null)
                {
                    project.StartDate = projectDTO.EndDateProject.Value;
                }
                if (projectDTO.PriorityProject != null)
                {
                    project.Priority = projectDTO.PriorityProject;
                }
                if (projectDTO.EmployeeId != null)
                {
                    project.ProjectManagerId = projectDTO.EmployeeId;
                }

                _context.Projects.Update(project);
                await _context.SaveChangesAsync();
                return "Update succsefull";
            }
            catch (Exception ex)  
            {
                return $"Error update project {ex}";
            }
        }

        public async Task<string> RemoveEmployeeAProject(Guid ProjectID  ,Guid employeeID)
        {
            var project = await _context.Projects
                .Include(i => i.Employees)
                .FirstOrDefaultAsync(i => i.Id == ProjectID);

            if (project == null)
            {
                return "The project was not found";
            }

            var employee = await _context.Employees.Include(i => i.Projects).FirstOrDefaultAsync(i => i.Id == employeeID);

            if (employee == null)
            {
                return "The employee was not found";
            }

            var projectEmployee = employee.Projects?.FirstOrDefault(p => p.Id == project.Id);
            if (projectEmployee == null)
            {
                return "The employee is not assigned to the project";
            }

            employee.Projects?.Remove(projectEmployee);
            project.Employees?.Remove(employee);
            await _context.SaveChangesAsync();

            return "Delete ok";
        }


        public async Task<string> AddEmployeeAProject(Guid projectId, Guid employeeID)
        {
            try
            {
                var project = await _context.Projects.Include(p => p.Employees).FirstOrDefaultAsync(p => p.Id == projectId);

                if (project == null)
                {
                    return "Error when adding an employee: The project was not found";
                }

                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeID);

                if (employee == null)
                {
                    return "Error when adding an employee: The employee was not found";
                }

                if (project.Employees?.Any(e => e.Id == employeeID) == true)
                {
                    return "Employee already exists in the project";
                }

                project.Employees?.Add(employee);
                employee.Projects?.Add(project);

                _context.Projects.Update(project);
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                return "Adding successful";
            }
            catch (Exception ex)
            {
                return $"Error adding employee: {ex.Message}";
            }
        }


        public async Task <ICollection<EmployeeEntity>> GetEmployInProject  (Guid projectId)
        {
            var project  = await  _context.Projects
                .Include(p => p.Employees).FirstOrDefaultAsync(p => p.Id == projectId);
            var employess = project?.Employees;
            if(employess == null)
            {
                return new HashSet<EmployeeEntity>(); 
            }

            return employess;
        }


    }
}
