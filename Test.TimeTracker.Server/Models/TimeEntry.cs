using Azure.Core.Pipeline;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.TimeTracker.Server.Models
{
    public class TimeEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }

        [Required]
        public int TaskId { get; set; }

        [Required]
        public DateTime DateTimeEntry { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person? Person { get; set; }

        [ForeignKey("TaskId")]
        public virtual TaskItem? Task { get; set; }

    }
}
