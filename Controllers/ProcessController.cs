using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult GetProcesses() {
            Process[] processes = Process.GetProcesses();
            List<ProcessModel> processModels = new List<ProcessModel>();
            processes.ToList().ForEach(process => processModels.Add(process.ConvertTo()));
            return Ok(processModels);
        }
    }
}
