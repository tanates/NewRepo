using SibersTetsTask.Server.Model.ModelEntity.User;

namespace SibersTetsTask.Server.Model.ModelEntity.ProjectTask
{
    public class TaskEmployee
    {

        public Guid Id { get; set; }


        public Guid EmployeeId { get; set; }
        public EmployeeEntity DesignatedEmployee { get; set; }

        public Guid TaskId { get; set; }
        public ProjectTaskEntity Task { get; set; }
    }
}
