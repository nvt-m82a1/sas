namespace SAS.Manage.Databases.Datatype
{
    public interface IEntityList<T> : ICollection<T> where T : IEntity
    {
        public T this[Guid id] { get; }
    }
}
