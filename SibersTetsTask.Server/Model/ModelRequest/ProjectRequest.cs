using SibersTetsTask.Server.Model.ModelDTO.UserDTO;

namespace SibersTetsTask.Server.Model.ModelRequest
{
    public class ProjectRequest
    {
        public string? NameProject { get; set; }
        public string? ExecutingCompany { get; set; }
        public string? CustomerCompany { get; set; }
        public string? emailEmployee { get; set; }
        public string ?nameEmployee { get; set; }
        public DateTime ?StartDateProject { get; set; }
        public DateTime? EndDateProject { get; set; }

        public int? PriorityProject { get; set; }

    }


}