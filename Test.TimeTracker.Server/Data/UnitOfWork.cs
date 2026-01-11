using Test.TimeTracker.Server.Models;

namespace Test.TimeTracker.Server.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkbenchContext _context;
        public IRepository<TimeEntry> TimeEntries { get; private set; }
        public IRepository<Person> People { get; private set; }
        public IRepository<TaskItem> Tasks { get; private set; }


        public UnitOfWork (WorkbenchContext context)
        {
            _context = context;
            TimeEntries = new Repository<TimeEntry>(context);
            People = new Repository<Person>(context);
            Tasks = new Repository<TaskItem>(context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
        
    }
}
