using SAS.Manage.Scheduler.Databases.Entities;

namespace SAS.Manage.Scheduler.Databases
{
    internal class OrderTable
    {
        public OrderTable Instance = new OrderTable();
        private OrderTable()
        {
            Orders = new List<Order>();
        }

        public ICollection<Order> Orders { get; set; }
    }
}
