using SAS.Manage.Scheduler.Databases.Datatype;
using SAS.Manage.Scheduler.Databases.Entities;

namespace SAS.Manage.Scheduler.Databases
{
    internal class MDatabases
    {
        public static MDatabases Instance = new MDatabases();
        private MDatabases()
        {
            Orders = new EntityList<Order>();
            States = new EntityList<State>();
            Status = new EntityList<Status>();
            Ordertypes = new EntityList<Ordertype>();
        }

        public IEntityList<Order> Orders { get; set; }
        public IEntityList<State> States { get; set; }
        public IEntityList<Status> Status { get; set; }
        public IEntityList<Ordertype> Ordertypes { get; set;}
    }
}
