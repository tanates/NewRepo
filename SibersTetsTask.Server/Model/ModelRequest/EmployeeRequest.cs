namespace SibersTetsTask.Server.Model.ModelRequest
{
    public class EmployeeRequest
    {
       
        public Guid   Id { get; set; }
        public string Password { get; set; }
        public string HashPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
    }
}