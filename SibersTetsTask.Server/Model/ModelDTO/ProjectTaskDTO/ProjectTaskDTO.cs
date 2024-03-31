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
            Id = new Guid();
            TaskName = request.TaskName;
            Status =(int) request.Status;
            Comment = request.Comment;
            Priority = request.Priority;
            ProjectId = request.ProjectId;
        }

        public Guid Id { get; set; }

        public string TaskName { get; set; }

        public string ?AuthorEmail { get; set; }

        public Guid  ProjectId { get; set; }
        public string? AssigneeEmail { get; set; }

        public ProjectEntity ?ProjectName { get; set; }
        public int Status { get; set; }

        public string Comment { get; set; }

        public int Priority { get; set; }

        static public ProjectTaskDTO Add(ProjectTaskRequest request)
        {
            return new ProjectTaskDTO(request);
        }
    }
}
