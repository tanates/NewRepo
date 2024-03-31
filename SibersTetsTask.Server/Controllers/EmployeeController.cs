using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SibersTetsTask.Server.Model.ModelRequest;
using SibersTetsTask.Server.Model.ModelDTO.ProjectDTO;
using SibersTetsTask.Server.Model.ModelDTO.UserDTO; 
using SibersTetsTask.Server.Services;

namespace SibersTetsTask.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        public async Task AddEmployee(EmployeeRequest request, EmployeesServisec servisec)
        {
            await servisec.AddEmployee(request, request.Password);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllEmployee(EmployeesServisec servisec)
        {
            var result = await servisec.GetAllEmployee();
            return Ok(result);
        }
        [HttpDelete]
        public async Task <ActionResult>DeleteEmoloyee (EmployeesServisec servisec , string email)
        {
            var result = await servisec.DeleteEmployee(email);

            return Ok(result);
        }
        [HttpPut]
        public async Task <ActionResult> UpdateEmployee(EmployeesServisec servisec,  EmployeeRequest request)
        {
            var result = await servisec.Update(request);
            return Ok(result);
        }

        
    }
}
