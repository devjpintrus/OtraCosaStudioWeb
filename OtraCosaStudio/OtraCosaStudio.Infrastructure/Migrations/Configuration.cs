using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraCosaStudio.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OtraCosaStudio.Infrastructure.Persistence.ControlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OtraCosaStudio.Infrastructure.Persistence.ControlContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
