using Test.TimeTracker.Server.Models;

namespace Test.TimeTracker.Server.Data
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<TimeEntry> TimeEntries { get; }
        IRepository<Person> People { get; }
        IRepository<TaskItem> Tasks { get; }

        Task<int> CompleteAsync();
    }
}
