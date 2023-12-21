using SAS.Public.Def.Container;

namespace SAS.Public.Def.Convert
{
    public class DataConvert
    {
        public static DataConvert Instance = new DataConvert();
        private DataConvert() { }

        public byte[] ToBytes<T>(T o) where T : class
        {
            var props = DataTypes.Instance.CheckProps<T>();

            var writer = new DataWriter();
            foreach (var prop in props)
            {
                switch (prop.typeFullname)
                {
                    // 1
                    case DataNames.FullName_Boolean: writer.Add((bool)prop.info.GetValue(o)!); break;
                    case DataNames.FullName_Byte: writer.Add((byte)prop.info.GetValue(o)!); break;
                    case DataNames.FullName_SByte: writer.Add((sbyte)prop.info.GetValue(o)!); break;

                    // 2
                    case DataNames.FullName_Char: writer.Add((char)prop.info.GetValue(o)!); break;
                    case DataNames.FullName_Int16: writer.Add((short)prop.info.GetValue(o)!); break;
                    case DataNames.FullName_UInt16: writer.Add((ushort)prop.info.GetValue(o)!); break;

                    // 4
                    case DataNames.FullName_Int32: writer.Add((int)prop.info.GetValue(o)!); break;
                    case DataNames.FullName_UInt32: writer.Add((uint)prop.info.GetValue(o)!); break;
                    case DataNames.FullName_Single: writer.Add((float)prop.info.GetValue(o)!); break;

                    // 8
                    case DataNames.FullName_Double: writer.Add((double)prop.info.GetValue(o)!); break;
                    case DataNames.FullName_Int64: writer.Add((long)prop.info.GetValue(o)!); break;

                    // 16
                    case DataNames.FullName_Decimal: writer.Add((decimal)prop.info.GetValue(o)!); break;

                    // ref
                    case DataNames.FullName_String: writer.Add((string?)prop.info.GetValue(o)!); break;
                    case DataNames.FullName_DateTime: writer.Add((DateTime?)prop.info.GetValue(o)!); break;
                    case DataNames.FullName_Guid: writer.Add((Guid?)prop.info.GetValue(o)!); break;

                    default: break;
                }
            }

            return writer.ToBytes();
        }

        public T ToClass<T>(byte[] bytes) where T : class, new()
        {
            var result = new T();
            var props = DataTypes.Instance.CheckProps<T>();

            var reader = new DataReader(bytes);
            foreach (var prop in props)
            {
                switch (prop.typeFullname)
                {
                    // 1
                    case DataNames.FullName_Boolean: prop.info.SetValue(result, reader.ReadBoolean()); break;
                    case DataNames.FullName_Byte: prop.info.SetValue(result, reader.ReadByte()); break;
                    case DataNames.FullName_SByte: prop.info.SetValue(result, reader.ReadSByte()); break;
                    
                    // 2
                    case DataNames.FullName_Char: prop.info.SetValue(result, reader.ReadChar()); break;
                    case DataNames.FullName_Int16: prop.info.SetValue(result, reader.ReadShort()); break;
                    case DataNames.FullName_UInt16: prop.info.SetValue(result, reader.ReadUShort()); break;
                    
                    // 4
                    case DataNames.FullName_Int32: prop.info.SetValue(result, reader.ReadInt()); break;
                    case DataNames.FullName_UInt32: prop.info.SetValue(result, reader.ReadUInt()); break;
                    case DataNames.FullName_Single: prop.info.SetValue(result, reader.ReadFloat()); break;
                    
                    // 8
                    case DataNames.FullName_Double: prop.info.SetValue(result, reader.ReadDouble()); break;
                    case DataNames.FullName_Int64: prop.info.SetValue(result, reader.ReadLong()); break;
                    
                    // 16
                    case DataNames.FullName_Decimal: prop.info.SetValue(result, reader.ReadDecimal()); break;
                    
                    // ref
                    case DataNames.FullName_String: prop.info.SetValue(result, reader.ReadString()); break;
                    case DataNames.FullName_DateTime: prop.info.SetValue(result, reader.ReadDateTime()); break;
                    case DataNames.FullName_Guid: prop.info.SetValue(result, reader.ReadGuid()); break;

                    default: break;
                }
            }

            return result;
        }
    }
}
