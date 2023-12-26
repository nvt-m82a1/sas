using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using SAS.Manage.Databases.Datatype;
using SAS.Manage.Databases.Entities.Views;
using StackExchange.Redis;

namespace SAS.Manage.Databases.Mod
{
    public abstract class AppDatabase
    {
        protected abstract AppDbContext AppDbContext { get; set; }
        protected IConfiguration configuration;
        protected IConnectionMultiplexer cacheConnect;

        public AppDatabase()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("database.json")
                .Build();

            try
            {
                var endpoint = configuration.GetSection("Redis").GetValue<string>("ConnectionString")!;
                ConfigurationOptions cacheOptions = new ConfigurationOptions()
                {
                    EndPoints =
                    {
                        { endpoint }
                    },
                    AbortOnConnectFail = false,
                };

                cacheConnect = ConnectionMultiplexer.Connect(cacheOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Redis exception" + ex.Message);
            }

            Orders = new AppRepository<Entities.Order>(cacheConnect, AppDbContext);
            States = new AppRepository<Entities.State>(cacheConnect, AppDbContext);
            Status = new AppRepository<Entities.Status>(cacheConnect, AppDbContext);
            Ordertypes = new AppRepository<Entities.Ordertype>(cacheConnect, AppDbContext);
        }

        public void SaveChanged()
        {
            AppDbContext.SaveChanges();
        }

        public Repository<Entities.Order> Orders { get; set; }
        public Repository<Entities.State> States { get; set; }
        public Repository<Entities.Status> Status { get; set; }
        public Repository<Entities.Ordertype> Ordertypes { get; set; }

        // Views
        public IEnumerable<ViewTypeTimeAnalyst> ViewTypesTimeAnalyst
        {
            get
            {
                var oders = AppDbContext.Orders;
                var status = AppDbContext.Status.Where(record => record.Completed);

                return status.LeftJoin(oders,
                    status => status.Id, order => order.Id,
                    (statusRecord, orderRecord) => new ViewTypeTimeAnalyst()
                    {
                        TypeId = orderRecord.TypeId,
                        TimeCreated = statusRecord.TimeCreated,
                        TimeUpdated = statusRecord.TimeUpdated,
                    }).AsEnumerable();
            }
        }
        // End Views
    }
}
