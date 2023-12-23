using SAS.Manage.Databases.Datatype;

namespace SAS.Manage.Databases.Entities
{
    public class Status : IEntity
    {
        public Guid Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCanceled { get; set; }
        public int ScanCount { get; set; }
    }
}
