using Microsoft.EntityFrameworkCore;
using Test.TimeTracker.Server.Models;

namespace Test.TimeTracker.Server.Data
{
    public class WorkbenchContext:DbContext
    {
        public WorkbenchContext(DbContextOptions<WorkbenchContext> options):base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person { Id=1,FullName="Anton"},
                new Person { Id=2,FullName="John"}
                );

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1,Name="Programming",Description=null },
                new TaskItem { Id=2, Name="Testing",Description=null}
                );
        }
    }
}
