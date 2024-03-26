using SibersTetsTask.Server.Model.ProjectTask;
using SibersTetsTask.Server.Model.User;

namespace SibersTetsTask.Server.Model.Project
{

    //A model for entering data into a database
    public class ProjectEntity
    {
        public Guid Id { get; set; }
        public string NameProject { get; set; } 
        public string ExecutingCompany  { get; set; } 

        public  string CustomerCompany { get; set; } 
        
        public DateTime StartDateProject { get; set; }
        public DateTime EndDateProject { get; set;}

        public  int PriorityProject { get; set; }

        public EmployeeEntity ProjectManager { get; set; }

        public List<EmployeeEntity> TeamMembers { get; set; }
        public ProjectTaskEntity ProjectTask { get; set; }

    }
}
