using SibersTetsTask.Server.Model.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SibersTetsTask.Server.Model.Project;

namespace SibersTetsTask.Server.Model.ProjectTask
{
    public class ProjectTaskEntity
    {
        public Guid Id { get; set; }

        public string TaskName { get; set; }

        [ForeignKey("AuthorId")]
        public EmployeeEntity Author { get; set; }
        public Guid AuthorId { get; set; }

        [ForeignKey("AssigneeId")]
        public EmployeeEntity Assignee { get; set; }
        public Guid AssigneeId { get; set; }

        public ProjectEntity Project { get; set; }
        public TaskStatus Status { get; set; }

        public string Comment { get; set; }

        public int Priority { get; set; }
    }

    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done
    }
}

