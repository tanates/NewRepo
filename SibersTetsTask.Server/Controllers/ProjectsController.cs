using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.ModelDTO.ProjectDTO;
using SibersTetsTask.Server.Services;
using SibersTetsTask.Server.Model.ModelEntity.User;

namespace SibersTetsTask.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        [HttpGet("all")]
        public async Task<ActionResult> GetAllProject(ProjectsServisec projectsServisec)
        {
            var project = await projectsServisec.GetProjects();
            return Ok(project);
        }
        [HttpPost("add")]
        public async Task<ActionResult> AddProject(ProjectsServisec servisec, ProjectRequest request)
        {

            var projectAdd = await servisec.AddProject(request);

            if (projectAdd == false)
            {

                var messagErorr = new { message = "when adding something went wrong" };
                return Conflict(messagErorr);
            }
            return Ok(projectAdd);
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> RemoveProject(ProjectsServisec servisec, Guid id)
        {
       
            var projectRemove = await servisec.Delete(id);
            
            return Ok(projectRemove);
        }
        [HttpPut("update")]
        public async Task<ActionResult> UpdateProject(ProjectsServisec servisec, ProjectRequest request)
        {
            var projectUpdate = await servisec.Update(request);
            return Ok(projectUpdate);
        }

        [HttpPut("delete/employee")]
        public async Task<ActionResult> RemoveEmployeeAProject(ProjectsServisec servisec, [FromBody]ProjectDeletRequest request)
        {

            var removeEmployee = await servisec.RemoveEmployeeAProject(request.ProjectId, request.EmployeeId);
           
            return Ok(removeEmployee);
        }
        [HttpPut("add/employee")]
        public async Task<ActionResult> AddEmployeeAProject(EmployeesServisec servisec, [FromBody]AddEmployeeProjectRequest request )
           {
               var addEmployee = await servisec.SetEmployeeInProjecc(request.EmployeeId, request.ProjectId);
               
               return Ok(addEmployee);
           }
        [HttpGet("employee/{projectId}")]
        public async Task<ActionResult> GetEmployInProject(ProjectsServisec servisec,Guid projectId)
        {
            var result = await servisec.GetEmployInProject(projectId);
            return Ok(result.Select(employee => new { employee.Id, employee.Email }));
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult> EmployeesOnProject(ProjectsServisec servisec,Guid projectId)
        {
            return Ok (await servisec.EmployeesOnProject(projectId));
        }
    }
}
