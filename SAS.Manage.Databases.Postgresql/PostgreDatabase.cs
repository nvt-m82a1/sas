using SAS.Manage.Databases.Mod;

namespace SAS.Manage.Databases.Postgresql
{
    public class PostgreDatabase : AppDatabase
    {
        protected override AppDbContext AppDbContext { get; set; }

        public PostgreDatabase()
        {
            AppDbContext = new PostgreDbContext(configuration);
        }
    }
}
