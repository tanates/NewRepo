using SibersTetsTask.Server.Model.Project;
using SibersTetsTask.Server.Model.ProjectTask;

namespace SibersTetsTask.Server.Model.User
{
    public class EmployeeEntity
    {
        public Guid  Id  { get; set; }
        public string HashPassword { get;  set; }
        public string PostEmployee { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public List <ProjectTaskEntity> ProjectTask { get; set; }
        public List<ProjectEntity> Projects { get; set; }
    }
}
