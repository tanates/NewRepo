using SibersTetsTask.Server.Model.ModelEntity.User;

namespace SibersTetsTask.Server.Model.ModelRequest
{
    public class ProjectTaskRequest
    {
        public Guid Id { get; set; }

        public string TaskName { get; set; }

  
        public Guid ProjectId { get; set; }

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
