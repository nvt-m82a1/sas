using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SAS.Manage.Databases.Mod;

namespace SAS.Manage.Databases.Postgresql
{
    public class PostgreDbContext : AppDbContext
    {
        public PostgreDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseNpgsql(configuration.GetConnectionString("PostgreDatabase"));
        }
    }
}
