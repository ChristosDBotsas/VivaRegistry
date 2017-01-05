using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}