using SibersTetsTask.Server.Model.User;

namespace SibersTetsTask.Server.Model.ModelRequest
{
    public class ProjectTaskRequest
    {
        public Guid Id { get; set; }

        public string TaskName { get; set; }

        public EmployeeEntity Author { get; set; }
        public Guid AuthorId { get; set; }

        public EmployeeEntity Assignee { get; set; }
        public Guid AssigneeId { get; set; }

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
