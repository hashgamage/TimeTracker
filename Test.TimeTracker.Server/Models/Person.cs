using System.ComponentModel.DataAnnotations;

namespace Test.TimeTracker.Server.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }
        public virtual ICollection<TimeEntry> TimeEntries { get; set; } = new HashSet<TimeEntry>();

    }
}
