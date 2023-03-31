using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;
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
            try
            {
                Process[] processes = Process.GetProcesses();
                List<ProcessModel> processModels = new List<ProcessModel>();
                foreach (var process in processes)
                {
                    processModels.Add(process.ConvertTo());

                }
                return Ok(processModels);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpGet("SearchProcess")]
        public IActionResult SearchProcess(string Name)
        {
            try
            {
                Name = Name.ToUpper();
                Process[] processes = Process.GetProcesses();
                if (!processes.Any(a => a.ProcessName.ToUpper() == Name))
                {
                    return NotFound();
                }

                List<ProcessModel> findedProcesses = new List<ProcessModel>();
                foreach (var process in processes) 
                    if (process.ProcessName.ToUpper() == Name) 
                        findedProcesses.Add(process.ConvertTo());

                return Ok(findedProcesses);
            } catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
        
        [HttpDelete("KillProcess")]
        public IActionResult KillProcess(int Id)
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                if (!processes.Any(a => a.Id == Id))
                {
                    return NotFound();
                }

                Process process = processes.First(process => process.Id == Id);
                process.Kill();

                return Accepted(process);
            } catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
