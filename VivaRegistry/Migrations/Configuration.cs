namespace VivaRegistry.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VivaRegistry.Models.VivaRegistryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VivaRegistry.Models.VivaRegistryContext context)
        {
            context.Applications.AddOrUpdate(
                x => x.ApplicationName,
                new Application { ApplicationName = "Wallet", ApplicationKey = 12491, CreationDate = DateTime.Now}
            );
            context.LogLevels.AddOrUpdate(
                x => x.LogLevelName,
                new LogLevel { LogLevelName = "Critical" },
                new LogLevel { LogLevelName = "Error" },
                new LogLevel { LogLevelName = "Warning"},
                new LogLevel { LogLevelName = "Information"}
            );
        }
    }
}
