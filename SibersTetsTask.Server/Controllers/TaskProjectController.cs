using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Services;

namespace SibersTetsTask.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskProjectController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult> AddTask(TaskProjectServices servisec, ProjectTaskRequest request)
        {
            await servisec.AddProjectTask(request);
            return Ok();
        }
        [HttpPost("employee")]
        public async Task<ActionResult> ProjectTaskAddAEmployee(TaskProjectServices servisec, Guid employeeId, Guid projectId)
        {

            return Ok(await servisec.ProjectTaskAddAEmployee(projectId, employeeId));
        }
        [HttpDelete("{projectTaskId}")]
        public async Task<ActionResult> ProjectTaskRemove(TaskProjectServices servisec, Guid projectTaskId)
        {
            return Ok(await servisec.ProjectTaskRemove(projectTaskId));
        }
        [HttpPut]
        public async Task<string> ProjectTaskRemoveAEmployee(TaskProjectServices servisec,Guid taskId, Guid employeeId)
        {

            return await servisec.ProjectTaskRemoveAEmployee(taskId, employeeId);
        }
        [HttpPut]
        public async Task<string> ProjectTaskRemoveAProject(TaskProjectServices servisec,Guid taskId, Guid projecId)
        {
  
            return await servisec.ProjectTaskRemoveAProject(taskId, projecId);
        }
    }
}
