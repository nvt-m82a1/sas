namespace SAS.Manage.Scheduler.Databases.Datatype
{
    internal interface IEntityList<T> : ICollection<T> where T : IEntity
    {
        public T this[Guid id] { get; }
    }
}
