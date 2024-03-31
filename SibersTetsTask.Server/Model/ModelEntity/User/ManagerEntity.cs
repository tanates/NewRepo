using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SibersTetsTask.Server.Model.ModelEntity.Project;

namespace SibersTetsTask.Server.Model.ModelEntity.User
{
    public class ManagerEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProjectEntity>? Projects { get; set; }

        public Guid? EmployeeId { get; set; }
        public EmployeeEntity? Employee { get; set; }

    }
}
