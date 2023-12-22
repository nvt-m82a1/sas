using SAS.Manage.Scheduler.Databases.Datatype;

namespace SAS.Manage.Scheduler.Databases.Entities
{
    internal class Ordertype : IEntity
    {
        public Guid Id { get; set; }
        public string? Typename { get; set; }
        public int SampleTypecount { get; set; }
        public int SampleAvgTimeInMinisecond { get; set; }
    }
}
