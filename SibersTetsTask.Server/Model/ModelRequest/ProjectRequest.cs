using SibersTetsTask.Server.Model.User;

namespace SibersTetsTask.Server.Model.ModelRequest
{
    public class ProjectRequest
    {
        public Guid Id { get; set; }
        public string NameProject { get; set; }
        public string ExecutingCompany { get; set; }

        public string CustomerCompany { get; set; }

        public DateTime StartDateProject { get; set; }
        public DateTime EndDateProject { get; set; }

        public int PriorityProject { get; set; }

        public EmployeeEntity ProjectManager { get; set; }
    }


}