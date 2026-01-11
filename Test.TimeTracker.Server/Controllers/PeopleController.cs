using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.TimeTracker.Server.Data;

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
            var people = await _unitOfWork.People.GetAllAsync();
            return Ok(people);
        }
    }
}
