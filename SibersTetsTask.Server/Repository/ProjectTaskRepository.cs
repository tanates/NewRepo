using Microsoft.EntityFrameworkCore;
using SibersTetsTask.Server.Context;
using SibersTetsTask.Server.Interface.ProjectInt;
using SibersTetsTask.Server.Model.ModelDTO.ProjectTaskDTO;
using SibersTetsTask.Server.Model.ModelEntity.ProjectTask;
using SibersTetsTask.Server.Model.ModelDTO.ProjectDTO;
using SibersTetsTask.Server.Model.ModelDTO.UserDTO;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace SibersTetsTask.Server.Repository
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly ApplicationContext _context;
        public ProjectTaskRepository(ApplicationContext context)
        {
            _context = context;
        }

     /*  public async Task<List<>> GetProjectTaskByEmployee(string emailEmployee)
        {
           var projectTask = await _context.EmployeeProjects
                /Where(i => i.AsigneeEmail == emailEmployee).ToListAsync()??throw new Exception("No task in the employee");

            return projectTask;
        }
     */
        public async Task<List<ProjectTaskEntity>> GetProjectTaskByProject(Guid projectId)
        {
            var projectTask = await _context.ProjectTasks
                .Where(i => i.Project.Id == projectId).ToListAsync() ?? throw new Exception("No task in the employee");

            return projectTask;
        }

        public async Task<List<ProjectTaskEntity>> GetProjectTaskByProject(string projectName)
        {
            // Получить проект по имени
            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.Name == projectName);

            if (project == null)
            {
                return new List<ProjectTaskEntity>(); // Вернуть пустой список, если проект не найден
            }

            // Получить список задач проекта
            var projectTasks = await _context.ProjectTasks
                .Where(pt => pt.ProjectId == project.Id)
                .ToListAsync();

            return projectTasks;
        }

        public async Task ProjectTaskAdd(ProjectTaskDTO taskDTO)
        {
            var task = new ProjectTaskEntity
            {
                Id = taskDTO.Id,
                Comment = taskDTO.Comment,
                Priority = taskDTO.Priority,
                Project = taskDTO.ProjectName,
                Status = taskDTO.Status.ToString(),
                Name = taskDTO.TaskName,
            };

            await _context.ProjectTasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<string> ProjectTaskAddAEmployee(Guid taskId, Guid employeeId)
        {
            var task = await _context.ProjectTasks.FindAsync(taskId);
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
            {
                return "Employee not found";
            }
            if(task == null)
            {
                return "Task not found";
            }
            var taskEmployee = new TaskEmployee
            {
                TaskId = taskId,
                EmployeeId = employeeId
            };
            employee.ExecutedTasks.Add(task);
            await  _context.EmployeeTasks.AddAsync(taskEmployee);
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return "Addin in project task successfully";
        }

        public async Task<string> ProjectTaskAddAProject(Guid taskId, Guid projectId)
        {
            var task = await _context.ProjectTasks.FindAsync(taskId);
            var project = await _context.Projects.FindAsync(projectId);

            if (task == null)
            {
                return "Error task ";
            }
            if(project == null)
            {
                return "Error project";
            }

            task.Project = project;
            project.Tasks.Add(task);
            await _context.Projects.AddAsync(project);
            await _context.ProjectTasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return "Adding project successfully";
        }

        public async Task<string> ProjectTaskRemove(Guid id)
        {
            var projectTask = await _context.ProjectTasks.FindAsync(id) ?? throw new Exception("Project task not found") ;
           
            _context.ProjectTasks.Remove(projectTask);
            await _context.SaveChangesAsync();

            return "Remove successfully";
        }

        public async Task<string> ProjectTaskRemoveAEmployee(Guid taskId, Guid employeeId)
        {
            var taskEmployee = await _context.EmployeeTasks
                .FirstOrDefaultAsync(i => i.TaskId == taskId && i.EmployeeId == employeeId);

            if (taskEmployee == null)
            {
                return "Связь между задачей и сотрудником не найдена";
            }
            _context.EmployeeTasks.Remove(taskEmployee);
           
            await _context.SaveChangesAsync();
            return "Сотрудник успешно удален из задачи";

        }

        public async Task<string> ProjectTaskRemoveAProject(Guid taskId, Guid projectId)
        {
            
            var projectTask = await _context.ProjectTasks.FindAsync(taskId);
            if (projectTask == null)
            {
                return "Задача не найдена";
            }
       
            

            _context.ProjectTasks.Remove(projectTask);
            
            await _context.SaveChangesAsync();
            return "Задача успешно удалена";
        }

   
        public async Task <string> UpdateTaskProject(Guid idTask, ProjectTaskDTO taskDTO)
        {
            var projectTask = await _context.ProjectTasks.FirstOrDefaultAsync(p => p.Id == idTask) ?? throw new Exception("Project not found.");
       

            _context.ProjectTasks.Update(projectTask);
            await _context.SaveChangesAsync();
            return "Задача успешно удалена";
        }


    }
}
