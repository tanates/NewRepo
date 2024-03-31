using SibersTetsTask.Server.Model.ModelEntity.Project;
using SibersTetsTask.Server.Model.ModelEntity.ProjectTask;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.ModelDTO.UserDTO;

namespace SibersTetsTask.Server.Model.ModelDTO.ProjectTaskDTO
{
    public class ProjectTaskDTO
    {
        public ProjectTaskDTO(ProjectTaskRequest request)
        {
            Id = Id;
            TaskName = request.TaskName;
            Status = request.Status.ToString();
            Comment = request.Comment;
            Priority = request.Priority;
        }

        public Guid Id { get; set; }

        public string TaskName { get; set; }

        public string AuthorEmail { get; set; }

        public Guid AuthorId { get; set; }
        public string AssigneeEmail { get; set; }

        public ProjectEntity ProjectName { get; set; }
        public string Status { get; set; }

        public string Comment { get; set; }

        public int Priority { get; set; }

        static public ProjectTaskDTO Add(ProjectTaskRequest request)
        {
            return new ProjectTaskDTO(request);
        }
    }
}
