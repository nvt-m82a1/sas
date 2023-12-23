namespace ZTests.SAS.Public.Model_Value
{
    public class TypesValue
    {
        public bool mbool;
        public byte mbyte;
        public sbyte msbyte;
        public char mchar;
        public decimal mdecimal;
        public double mdouble;
        public float mfloat;
        public int mint;
        public uint muint;
        public long mlong;
        public short mshort;
        public ushort mushort;
    }

    public static class TypesValueExtensions
    {
        public static bool Compare(this TypesValue self, TypesValue other)
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
                self.mushort == other.mushort;

            return equal;
        }
    }
}
