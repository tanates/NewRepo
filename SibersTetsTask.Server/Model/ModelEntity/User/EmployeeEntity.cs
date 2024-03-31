using SibersTetsTask.Server.Model.ModelEntity.Project;
using SibersTetsTask.Server.Model.ModelEntity.ProjectTask;

namespace SibersTetsTask.Server.Model.ModelEntity.User
{
    public class EmployeeEntity
    {
        public Guid Id { get; set; }
        public string HashPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public ICollection<ProjectEntity>? Projects { get; set; }
        public ICollection<ManagerEntity>? ManagedProjects { get; set; }
        // public ICollection<EmployeeProjectEntity> AuthoredTasks { get; set; } 
        public ICollection<ProjectTaskEntity>? ExecutedTasks { get; set; }

    }
}
