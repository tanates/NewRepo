using Azure.Core;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.Project;
using SibersTetsTask.Server.Model.ProjectTask;
using System.Collections.Generic;

namespace SibersTetsTask.Server.Model.User
{
    public class Employee
    {
        public Employee(EmployeeRequest request, List<ProjectEntity> projects, string hashPassword , List<ProjectTaskEntity> taskProject)
        {
            Id = request.Id;
            Name = request.Name;
            Surname = request.Surname;
            MiddleName = request.MiddleName;
            Email = request.Email;
            Projects = projects;
            HashPassword = hashPassword;
            PostEmployee = "Employee";
            TaskProject = taskProject;
        }
        public Guid Id { get;private  set; }
        public string PostEmployee { get; private set; }
        public string HashPassword { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string MiddleName { get; private set; }
        public string Email { get; private set; }
        public List<ProjectEntity> Projects { get; private set; }
        public List<ProjectTaskEntity> TaskProject { get; private set; }
        static public Employee Add(EmployeeRequest request, List<ProjectEntity> projects, string hashPassword , List<ProjectTaskEntity> taskProject)
        {
            return new Employee(request, projects, hashPassword , taskProject);
        }
    }
}
