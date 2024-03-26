using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.User;

namespace SibersTetsTask.Server.Model.ProjectTask
{
    public class ProjectTaskDTO
    {
        public ProjectTaskDTO(ProjectTaskRequest request)
        {
            Id = Id;
            TaskName = request.TaskName;
            Author = request.Author;
            AuthorId = request.AuthorId;
            Assignee = request.Assignee;
            AssigneeId =request. AssigneeId;
            Status = (TaskStatus)request.Status;
            Comment = request.Comment;
            Priority = request.Priority;
        }

        public Guid Id { get; set; }

        public string TaskName { get; set; }

        public EmployeeEntity Author { get; set; }
        public Guid AuthorId { get; set; }

        public EmployeeEntity Assignee { get; set; }
        public Guid AssigneeId { get; set; }

        public TaskStatus Status { get; set; }

        public string Comment { get; set; }

        public int Priority { get; set; }

        static public ProjectTaskDTO Add (ProjectTaskRequest request)
        {
            return new ProjectTaskDTO(request);
        }
    }
}
