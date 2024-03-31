using Azure.Core;
using SibersTetsTask.Server.Model.ModelEntity.Project;
using SibersTetsTask.Server.Model.ModelEntity.User;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.ModelDTO.UserDTO;
using System.Collections.Generic;

namespace SibersTetsTask.Server.Model.ModelDTO.UserDTO
{
    public class EmployeeDTO
    {
        public EmployeeDTO(EmployeeRequest request)
        {
            Id = new Guid();
            Name = request.FirstName ?? "";
            Surname = request.LastName ?? "";
            MiddleName = request.MiddleName ?? "";
            Email = request.Email ?? "";
            PostEmployee = "Employee";
        }
        public Guid Id { get; private set; }
        public string PostEmployee { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string MiddleName { get; private set; }
        public string Email { get; private set; }
        public ICollection<ProjectEntity> Projects { get; private set; }
        public EmployeeEntity Manager { get; set; }
        static public EmployeeDTO Add(EmployeeRequest request)
        {
            return new EmployeeDTO(request);
        }
    }
}
