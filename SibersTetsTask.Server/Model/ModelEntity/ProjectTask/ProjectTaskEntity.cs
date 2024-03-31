using SibersTetsTask.Server.Model.ModelDTO.UserDTO; 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using SibersTetsTask.Server.Model.ModelEntity.Project;

namespace SibersTetsTask.Server.Model.ModelEntity.ProjectTask
{
    public class ProjectTaskEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }


        [ForeignKey(nameof(ProjectId))]
        public ProjectEntity Project { get; set; }
        public Guid ProjectId { get; set; }

    }

   
}

