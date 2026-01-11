using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.TimeTracker.Server.Data;
using Test.TimeTracker.Server.DTOs;
using Test.TimeTracker.Server.Models;

namespace Test.TimeTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TimeEntriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeEntries()
        {
            var entries = await _unitOfWork.TimeEntries.GetAllAsync();
            return Ok(entries);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTimeEntry([FromBody] TimeEntryCreateDto dto)
        {
            var entry = new TimeEntry
            {
                PersonId = dto.PersonId,
                TaskId = dto.TaskId,
                DateTimeEntry = dto.DateTimeEntry,
            };

            await _unitOfWork.TimeEntries.AddAsync(entry);
            await _unitOfWork.CompleteAsync(); 

            return Ok(entry);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateEntry(int id,[FromBody] TimeEntryCreateDto dto)
        {
            var existingEntry = await _unitOfWork.TimeEntries.GetByIdAsync(id);
            if (existingEntry == null)
                return NotFound();

            existingEntry.PersonId = dto.PersonId;
            existingEntry.TaskId = dto.TaskId;
            existingEntry.DateTimeEntry = dto.DateTimeEntry;


             _unitOfWork.TimeEntries.Update(existingEntry);

            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteEntry(int id)
        {
            var existingEntry = await _unitOfWork.TimeEntries.GetByIdAsync(id);
            if (existingEntry == null)
                return NotFound();

            _unitOfWork.TimeEntries.Delete(id);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }


    }
}
