using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.TimeTracker.Server.Data;
using Test.TimeTracker.Server.DTOs;

namespace Test.TimeTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeopleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var people = await _unitOfWork.People
             .GetQueryable()
             .Select(p => new PersonResponseDto
             {
                 Id=p.Id,
                 Name=p.FullName

             }).ToListAsync();

            return Ok(people);
        }
    }
}
