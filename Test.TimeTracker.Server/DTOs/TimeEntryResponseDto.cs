namespace Test.TimeTracker.Server.DTOs
{
    public class TimeEntryResponseDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}
