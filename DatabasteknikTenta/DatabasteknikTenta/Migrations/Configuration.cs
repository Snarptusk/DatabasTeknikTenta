namespace DatabasteknikTenta.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabasteknikTenta.Models.NORTHWNDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabasteknikTenta.Models.NORTHWNDContext context)
        {
            
        }
    }
}
