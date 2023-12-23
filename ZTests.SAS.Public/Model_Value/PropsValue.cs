namespace ZTests.SAS.Public.Model_Value
{
    public class PropsValue
    {
        public bool mbool { get; set; }
        public byte mbyte { get; set; }
        public sbyte msbyte { get; set; }
        public char mchar { get; set; }
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

    public static class PropsValueExtensions
    {
        public static bool Compare(this PropsValue self, PropsValue other)
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
