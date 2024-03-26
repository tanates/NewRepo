using Azure.Core;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.ProjectTask;
using SibersTetsTask.Server.Model.User;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SibersTetsTask.Server.Model.Project
{
    public class Project
    {
        public Project(ProjectRequest request, EmployeeEntity projectManager, List<EmployeeEntity> teamMembers , List<ProjectTaskEntity> taskProject)
        {
            Id = request.Id ;
            NameProject = request.NameProject;
            ExecutingCompany = request.ExecutingCompany;
            CustomerCompany = request.CustomerCompany;
            StartDateProject = request.StartDateProject;
            EndDateProject = request.EndDateProject;
            PriorityProject = request.PriorityProject;
            ProjectManager = projectManager;
            TeamMembers = teamMembers;
            TaskProject = taskProject;
        }

        public Guid Id { get; set; }
        public string NameProject { get; set; }
        public string ExecutingCompany { get; set; }

        public string CustomerCompany { get; set; }

        public DateTime StartDateProject { get; set; }
        public DateTime EndDateProject { get; set; }

        public int PriorityProject { get; set; }

        public EmployeeEntity ProjectManager { get; set; }

        public List<EmployeeEntity> TeamMembers { get; set; }
        public List<ProjectTaskEntity> TaskProject { get; set; }
        static public Project Add(ProjectRequest request, EmployeeEntity projectManager, List<EmployeeEntity> teamMembers , List<ProjectTaskEntity> taskProject)
        {
            return new Project(request, projectManager, teamMembers , taskProject);
        }
    }
}
