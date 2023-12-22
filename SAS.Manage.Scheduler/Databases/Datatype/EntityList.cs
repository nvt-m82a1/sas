using System.Collections.Concurrent;

namespace SAS.Manage.Scheduler.Databases.Datatype
{
    internal class EntityList<T> : List<T>, IEntityList<T> where T : IEntity
    {
        private ConcurrentDictionary<Guid, T> cached = new ConcurrentDictionary<Guid, T>();

        public new void Add(T item)
        {
            base.Add(item);
            cached[item.Id] = item;
        }

        public T this[Guid id]
        {
            get
            {
                return cached[id];
            }
        }
    }
}
