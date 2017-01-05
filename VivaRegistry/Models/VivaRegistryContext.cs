using System.Data.Entity;

namespace VivaRegistry.Models
{
    public class VivaRegistryContext : DbContext
    {
        public VivaRegistryContext() : base("VivaRegistryContext")
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<LogLevel> LogLevels { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupEvent> GroupEvent { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}