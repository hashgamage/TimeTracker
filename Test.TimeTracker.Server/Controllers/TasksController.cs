using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.TimeTracker.Server.Data;
using Test.TimeTracker.Server.DTOs;

namespace Test.TimeTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _unitOfWork.Tasks
            .GetQueryable()
            .Select(p => new TaskResponseDto
            { 
                Id = p.Id,
                TaskName = p.Name,
                Description =p.Description,
                
            })
            .ToListAsync();
            return Ok(tasks);
        }
    }
}
