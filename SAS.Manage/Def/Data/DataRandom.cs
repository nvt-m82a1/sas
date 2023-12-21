using SAS.Public.Def.Convert;
using System.Security.Cryptography;

namespace SAS.Public.Def.Data
{
    public class DataRandom
    {
        public static DataRandom Instance = new DataRandom();
        private DataRandom() { }

        public void FillPropsMin<T>(T o) where T : class, new()
        {
            var props = DataTypes.Instance.CheckProps<T>();

            foreach (var prop in props)
            {
                switch (prop.typeFullname)
                {
                    // 1
                    case DataNames.FullName_Boolean: prop.info.SetValue(o, false); break;
                    case DataNames.FullName_Byte: prop.info.SetValue(o, Byte.MinValue); break;
                    case DataNames.FullName_SByte: prop.info.SetValue(o, SByte.MinValue); break;

                    // 2
                    case DataNames.FullName_Char: prop.info.SetValue(o, Char.MinValue); break;
                    case DataNames.FullName_Int16: prop.info.SetValue(o, Int16.MinValue); break;
                    case DataNames.FullName_UInt16: prop.info.SetValue(o, UInt16.MinValue); break;

                    // 4
                    case DataNames.FullName_Int32: prop.info.SetValue(o, Int32.MinValue); break;
                    case DataNames.FullName_UInt32: prop.info.SetValue(o, UInt32.MinValue); break;
                    case DataNames.FullName_Single: prop.info.SetValue(o, Single.MinValue); break;

                    // 8
                    case DataNames.FullName_Double: prop.info.SetValue(o, Double.MinValue); break;
                    case DataNames.FullName_Int64: prop.info.SetValue(o, Int64.MinValue); break;

                    // 16
                    case DataNames.FullName_Decimal: prop.info.SetValue(o, Decimal.MinValue); break;

                    // ref
                    case DataNames.FullName_String: prop.info.SetValue(o, null); break;
                    case DataNames.FullName_DateTime: prop.info.SetValue(o, DateTime.MinValue); break;
                    case DataNames.FullName_Guid: prop.info.SetValue(o, null); break;

                    default: break;
                }
            }
        }

        public void FillPropsMax<T>(T o) where T : class, new()
        {
            var props = DataTypes.Instance.CheckProps<T>();

            foreach (var prop in props)
            {
                switch (prop.typeFullname)
                {
                    // 1
                    case DataNames.FullName_Boolean: prop.info.SetValue(o, true); break;
                    case DataNames.FullName_Byte: prop.info.SetValue(o, Byte.MaxValue); break;
                    case DataNames.FullName_SByte: prop.info.SetValue(o, SByte.MaxValue); break;

                    // 2
                    case DataNames.FullName_Char: prop.info.SetValue(o, Char.MaxValue); break;
                    case DataNames.FullName_Int16: prop.info.SetValue(o, Int16.MaxValue); break;
                    case DataNames.FullName_UInt16: prop.info.SetValue(o, UInt16.MaxValue); break;

                    // 4
                    case DataNames.FullName_Int32: prop.info.SetValue(o, Int32.MaxValue); break;
                    case DataNames.FullName_UInt32: prop.info.SetValue(o, UInt32.MaxValue); break;
                    case DataNames.FullName_Single: prop.info.SetValue(o, Single.MaxValue); break;

                    // 8
                    case DataNames.FullName_Double: prop.info.SetValue(o, Double.MaxValue); break;
                    case DataNames.FullName_Int64: prop.info.SetValue(o, Int64.MaxValue); break;

                    // 16
                    case DataNames.FullName_Decimal: prop.info.SetValue(o, Decimal.MaxValue); break;

                    // ref
                    case DataNames.FullName_String: prop.info.SetValue(o, RandomString()); break;
                    case DataNames.FullName_DateTime: prop.info.SetValue(o, DateTime.MaxValue); break;
                    case DataNames.FullName_Guid:
                        prop.info.SetValue(o, new Guid(
                        int.MaxValue, short.MaxValue, short.MaxValue,
                        byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue,
                        byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue)
                        ); break;

                    default: break;
                }
            }
        }


        public void FillPropsRandom<T>(T o) where T : class, new()
        {
            var props = DataTypes.Instance.CheckProps<T>();

            foreach (var prop in props)
            {
                switch (prop.typeFullname)
                {
                    // 1
                    case DataNames.FullName_Boolean: prop.info.SetValue(o, Random.Shared.Next(0, 2) == 0); break;
                    case DataNames.FullName_Byte: prop.info.SetValue(o, (byte)Random.Shared.Next(Byte.MinValue, Byte.MaxValue)); break;
                    case DataNames.FullName_SByte: prop.info.SetValue(o, (sbyte)Random.Shared.Next(SByte.MinValue, SByte.MaxValue)); break;

                    // 2
                    case DataNames.FullName_Char: prop.info.SetValue(o, (char)Random.Shared.Next(Char.MinValue, Char.MaxValue)); break;
                    case DataNames.FullName_Int16: prop.info.SetValue(o, (short)Random.Shared.Next(Int16.MinValue, Int16.MaxValue)); break;
                    case DataNames.FullName_UInt16: prop.info.SetValue(o, (ushort)Random.Shared.Next(UInt16.MinValue, UInt16.MaxValue)); break;

                    // 4
                    case DataNames.FullName_Int32: prop.info.SetValue(o, (int)Random.Shared.Next(Int32.MinValue, Int32.MaxValue)); break;
                    case DataNames.FullName_UInt32: prop.info.SetValue(o, (uint)Random.Shared.NextInt64(0, UInt32.MaxValue)); break;
                    case DataNames.FullName_Single: prop.info.SetValue(o, (float)Random.Shared.NextSingle() * Single.MaxValue); break;

                    // 8
                    case DataNames.FullName_Double: prop.info.SetValue(o, (double)Random.Shared.NextDouble() * Double.MaxValue); break;
                    case DataNames.FullName_Int64: prop.info.SetValue(o, (long)Random.Shared.NextInt64(Int64.MinValue, Int64.MaxValue)); break;

                    // 16
                    case DataNames.FullName_Decimal: prop.info.SetValue(o, (decimal)((uint)Random.Shared.NextSingle() * Decimal.MaxValue)); break;

                    // ref
                    case DataNames.FullName_String: prop.info.SetValue(o, RandomString()); break;
                    case DataNames.FullName_DateTime: prop.info.SetValue(o, RandomDatetime()); break;
                    case DataNames.FullName_Guid: prop.info.SetValue(o, Guid.NewGuid()); break;

                    default: break;
                }
            }
        }

        public string RandomString(int minLength = 10, int maxLength = 20)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var length = RandomNumberGenerator.GetInt32(minLength, maxLength);
            var stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[Random.Shared.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public DateTime RandomDatetime()
        {
            var rndDays = RandomNumberGenerator.GetInt32(-100, 100);
            var rndHours = RandomNumberGenerator.GetInt32(1, 24);
            var rndMinutes = RandomNumberGenerator.GetInt32(1, 60);
            var rndSeconds = RandomNumberGenerator.GetInt32(1, 60);
            var rndDatetime = DateTime.Now
                .AddDays(rndDays)
                .AddHours(rndHours)
                .AddMinutes(rndMinutes)
                .AddSeconds(rndSeconds);

            return rndDatetime;
        }
    }
}
