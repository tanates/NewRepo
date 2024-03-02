using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StroiTrendTestTask.Server.Model;
using StroiTrendTestTask.Server.Services;
using StroiTrendTestTask.Server.Services.Interface;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StroiTrendTestTask.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IReportService _reportService;

        public TableController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetReport(string name)
        {
           
           return Ok(_reportService.GetReportAsync(name));
        }

    }
}
