using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SAS.Manage.Databases.Entities;

namespace SAS.Manage.Databases.Mod
{
    public class AppDbContext : DbContext
    {
        protected IConfiguration configuration;
        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Ordertype> Ordertypes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
