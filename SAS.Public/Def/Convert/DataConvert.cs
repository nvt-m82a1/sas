using SAS.Public.Def.Container;

namespace SAS.Public.Def.Convert
{
    public class DataConvert
    {
        public static DataConvert Instance = new DataConvert();
        private DataConvert() { }

        public byte[] ToBytes<T>(T o) where T : class
        {
            var members = DataTypes.Instance.CheckMembers<T>();

            var writer = new DataWriter();
            foreach (var member in members)
            {
                switch (member.TypeFullName)
                {
                    // 1
                    case DataNames.FullName_Boolean: writer.Add((bool)member.GetValue(o)!); break;
                    case DataNames.FullName_Byte: writer.Add((byte)member.GetValue(o)!); break;
                    case DataNames.FullName_SByte: writer.Add((sbyte)member.GetValue(o)!); break;

                    // 2
                    case DataNames.FullName_Char: writer.Add((char)member.GetValue(o)!); break;
                    case DataNames.FullName_Int16: writer.Add((short)member.GetValue(o)!); break;
                    case DataNames.FullName_UInt16: writer.Add((ushort)member.GetValue(o)!); break;

                    // 4
                    case DataNames.FullName_Int32: writer.Add((int)member.GetValue(o)!); break;
                    case DataNames.FullName_UInt32: writer.Add((uint)member.GetValue(o)!); break;
                    case DataNames.FullName_Single: writer.Add((float)member.GetValue(o)!); break;

                    // 8
                    case DataNames.FullName_Double: writer.Add((double)member.GetValue(o)!); break;
                    case DataNames.FullName_Int64: writer.Add((long)member.GetValue(o)!); break;

                    // 16
                    case DataNames.FullName_Decimal: writer.Add((decimal)member.GetValue(o)!); break;

                    // ref
                    case DataNames.FullName_String: writer.Add((string?)member.GetValue(o)!); break;
                    case DataNames.FullName_DateTime: writer.Add((DateTime?)member.GetValue(o)!); break;
                    case DataNames.FullName_Guid: writer.Add((Guid?)member.GetValue(o)!); break;

                    default: break;
                }
            }

            return writer.ToBytes();
        }

        public T ToClass<T>(byte[] bytes) where T : class, new()
        {
            var result = new T();
            var members = DataTypes.Instance.CheckMembers<T>();

            var reader = new DataReader(bytes);
            foreach (var member in members)
            {
                switch (member.TypeFullName)
                {
                    // 1
                    case DataNames.FullName_Boolean: member.SetValue(result, reader.ReadBoolean()); break;
                    case DataNames.FullName_Byte: member.SetValue(result, reader.ReadByte()); break;
                    case DataNames.FullName_SByte: member.SetValue(result, reader.ReadSByte()); break;
                    
                    // 2
                    case DataNames.FullName_Char: member.SetValue(result, reader.ReadChar()); break;
                    case DataNames.FullName_Int16: member.SetValue(result, reader.ReadShort()); break;
                    case DataNames.FullName_UInt16: member.SetValue(result, reader.ReadUShort()); break;
                    
                    // 4
                    case DataNames.FullName_Int32: member.SetValue(result, reader.ReadInt()); break;
                    case DataNames.FullName_UInt32: member.SetValue(result, reader.ReadUInt()); break;
                    case DataNames.FullName_Single: member.SetValue(result, reader.ReadFloat()); break;
                    
                    // 8
                    case DataNames.FullName_Double: member.SetValue(result, reader.ReadDouble()); break;
                    case DataNames.FullName_Int64: member.SetValue(result, reader.ReadLong()); break;
                    
                    // 16
                    case DataNames.FullName_Decimal: member.SetValue(result, reader.ReadDecimal()); break;
                    
                    // ref
                    case DataNames.FullName_String: member.SetValue(result, reader.ReadString()); break;
                    case DataNames.FullName_DateTime: member.SetValue(result, reader.ReadDateTime()); break;
                    case DataNames.FullName_Guid: member.SetValue(result, reader.ReadGuid()); break;

                    default: break;
                }
            }

            return result;
        }
    }
}
