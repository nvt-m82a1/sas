using System.Collections.Concurrent;
using System.Reflection;

namespace SAS.Public.Def.Convert
{
    public class DataTypes
    {
        public static DataTypes Instance = new DataTypes();

        private ConcurrentDictionary<int, IEnumerable<(string?, PropertyInfo)>> map;
        private DataTypes()
        {
            map = new ConcurrentDictionary<int, IEnumerable<(string?, PropertyInfo)>>();
        }

        public IEnumerable<(string? typeFullname, PropertyInfo info)> CheckProps<T>() where T : class
        {
            var hashcode = typeof(T).GetHashCode();
            if (!map.ContainsKey(hashcode))
            {
                var props = typeof(T).GetProperties();
                IEnumerable<(string? fullname, PropertyInfo info)> infos = props
                    .Select(p =>
                    {
                        if (p.PropertyType.Name == DataNames.Name_Nulable && p.PropertyType.IsGenericType)
                        {
                            return (p.PropertyType.GetGenericArguments()[0].FullName, p);
                        }
                        else
                        {
                            return (p.PropertyType.FullName, p);
                        }
                    });

                map[hashcode] = infos;
            }

            return map[hashcode];
        }
    }
}
