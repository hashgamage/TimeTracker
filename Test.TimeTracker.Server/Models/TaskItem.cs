using System.ComponentModel.DataAnnotations;

namespace Test.TimeTracker.Server.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<TimeEntry> TimeEntries { get; set; } = new HashSet<TimeEntry>();
    }
}
