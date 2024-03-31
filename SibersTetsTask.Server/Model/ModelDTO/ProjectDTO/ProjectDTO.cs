using Azure.Core;
using SibersTetsTask.Server.Model.ModelEntity.ProjectTask;
using SibersTetsTask.Server.Model.ModelEntity.User;
using SibersTetsTask.Server.Model.ModelRequest;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace SibersTetsTask.Server.Model.ModelDTO.ProjectDTO
{
    public class ProjectDTO
    {
        public ProjectDTO(ProjectRequest request)
        {
            Id = new Guid();
            NameProject = request.NameProject;
            ExecutingCompany = request.ExecutingCompany;
            CustomerCompany = request.CustomerCompany;
            StartDateProject = request.StartDateProject;
            EndDateProject = request.EndDateProject;
            PriorityProject = request.PriorityProject;


        }

        public Guid Id { get; set; }
        public string NameProject { get; set; }
        public string ?ExecutingCompany { get; set; }

        public string ?CustomerCompany { get; set; }

        public DateTime? StartDateProject { get; set; }
        public DateTime? EndDateProject { get; set; }

        public int? PriorityProject { get; set; }

        public Guid? EmployeeId { get; set; }

        public List<EmployeeEntity>? TeamMembers { get; set; }
        public List<ProjectTaskEntity>? TaskProject { get; set; }
        static public ProjectDTO Add(ProjectRequest request)
        {
            return new ProjectDTO(request);
        }
    }
}
