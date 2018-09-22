using System.Data.Entity;

namespace klaravictor.Models
{

    public class DataModel : DbContext
    {
        static DataModel()
        {
            //Database.SetInitializer<DataModel>(null);

            Database.SetInitializer<DataModel>(new DropCreateDatabaseIfModelChanges<DataModel>());

        }

        public virtual DbSet<RvspModel> RvspResponses { get; set; }

    }
}