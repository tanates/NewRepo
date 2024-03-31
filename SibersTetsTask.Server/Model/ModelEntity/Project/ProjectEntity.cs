using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Migrations;
using SibersTetsTask.Server.Model.ModelEntity.ProjectTask;
using SibersTetsTask.Server.Model.ModelEntity.User;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SibersTetsTask.Server.Model.ModelEntity.Project
{

    //A model for entering data into a database
    public class ProjectEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string ExecutorName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Priority { get; set; }


        public Guid? ProjectManagerId { get; set; }
        public ICollection<EmployeeEntity>? Employees { get; set; }
        public ManagerEntity? ProjectManager { get; set; }
        public ICollection<ProjectTaskEntity>? Tasks { get; set; }
    }
}
