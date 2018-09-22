using System.Data.Entity;
using klaravictor.Models;

namespace klaravictor.Migrations

{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //Database.SetInitializer(new DropCreateDatabaseAlways<DataModel>());
        }

        protected override void Seed(DataModel context)
        {

        }
    }
}
