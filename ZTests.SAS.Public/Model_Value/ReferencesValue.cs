namespace ZTests.SAS.Public.Model_Value
{
    public class ReferencesValue
    {
        public string? mstring;
        public Guid? mguid;
        public DateTime? mdatetime;
    }

    public static class ReferencesValueExtensions
    {
        public static bool Compare(this ReferencesValue self, ReferencesValue other)
        {
            var equal = self.mstring == other.mstring &&
                self.mguid == other.mguid &&
                self.mdatetime == other.mdatetime;

            return equal;
        }
    }
}
