using System.ComponentModel.DataAnnotations;

namespace Test.TimeTracker.Server.DTOs
{
    public class TimeEntryCreateDto
    {
        [Required(ErrorMessage = "Please select a person.")]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Please select a task.")]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Date and Time are required.")]
        public DateTime DateTimeEntry { get; set; } 
    }
}
