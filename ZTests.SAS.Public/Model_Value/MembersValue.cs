namespace ZTests.SAS.Public.Model_Value
{
    public class MembersValue
    {
        public bool mbool;
        public byte mbyte;
        public sbyte msbyte;
        public char mchar;
        public decimal mdecimal { get; set; }
        public double mdouble { get; set; }
        public float mfloat { get; set; }
        public int mint { get; set; }
        public uint muint { get; set; }
        public long mlong { get; set; }
        public short mshort { get; set; }
        public ushort mushort { get; set; }
        
        public string? mstring { get; set; }
        public DateTime? mdatetime { get; set; }
        public Guid? mguid { get; set; }
    }

    public static class MembersValueExtensions
    {
        public static bool Compare(this MembersValue self, MembersValue other)
        {
            var equal = self.mbool == other.mbool &&
                self.mbyte == other.mbyte &&
                self.msbyte == other.msbyte &&
                self.mchar == other.mchar &&
                self.mdecimal == other.mdecimal &&
                self.mdouble == other.mdouble &&
                self.mfloat == other.mfloat &&
                self.mint == other.mint &&
                self.muint == other.muint &&
                self.mlong == other.mlong &&
                self.mshort == other.mshort &&
                self.mushort == other.mushort &&
                self.mstring == other.mstring &&
                self.mguid == other.mguid &&
                self.mdatetime == other.mdatetime;

            return equal;
        }
    }
}
