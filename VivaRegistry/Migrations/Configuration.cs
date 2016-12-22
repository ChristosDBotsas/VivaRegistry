namespace VivaRegistry.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VivaRegistryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VivaRegistryContext context)
        {
            context.Applications.AddOrUpdate(
                x => x.ApplicationName,
                new Application { ApplicationName = "Wallet", CreationDate = DateTime.Now }
            );
            context.LogLevels.AddOrUpdate(
                x => x.LogLevelName,
                new LogLevel { LogLevelName = "Critical" },
                new LogLevel { LogLevelName = "Error" },
                new LogLevel { LogLevelName = "Warning" },
                new LogLevel { LogLevelName = "Information" }
            );

            context.Events.AddOrUpdate
            (
                x => x.EventId,
                new Event
                {
                    AppId = context.Applications.FirstOrDefault(a => a.ApplicationName == "Wallet").ApplicationId,
                    LogId = context.LogLevels.FirstOrDefault(l => l.LogLevelName == "Error").LogLevelId,
                    EventGenerationDate = DateTime.Now
                },
                new Event
                {
                    AppId = context.Applications.FirstOrDefault(a => a.ApplicationName == "Wallet").ApplicationId,
                    LogId = context.LogLevels.FirstOrDefault(l => l.LogLevelName == "Warning").LogLevelId,
                    EventGenerationDate = DateTime.Now
                }
            );
        }
    }
}
