using SAS.Manage.Scheduler.Databases.Datatype;

namespace SAS.Manage.Scheduler.Databases.Entities
{
    public class Order : IEntity
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public int Priority { get; set; }
    }
}
