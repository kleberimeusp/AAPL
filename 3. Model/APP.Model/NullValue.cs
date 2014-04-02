using System;
using System.Collections.Generic;

namespace APP.Model
{
    public class NullValue
    {
        private static Dictionary<Type, object> DbTypeDictionary { get; set; }

        public object this[Type index]
        {
            get
            {
                return DbTypeDictionary[index];
            }
        }

        static NullValue()
        {
            DbTypeDictionary = new Dictionary<Type, object>();

            DbTypeDictionary[typeof(byte)] = Byte.MinValue;
            DbTypeDictionary[typeof(sbyte)] = SByte.MinValue;
            DbTypeDictionary[typeof(short)] = Int16.MinValue;
            DbTypeDictionary[typeof(ushort)] = UInt16.MinValue;
            DbTypeDictionary[typeof(int)] = Int32.MinValue;
            DbTypeDictionary[typeof(uint)] = UInt32.MinValue;
            DbTypeDictionary[typeof(long)] = Int64.MinValue;
            DbTypeDictionary[typeof(ulong)] = UInt64.MinValue;
            DbTypeDictionary[typeof(float)] = Single.MinValue;
            DbTypeDictionary[typeof(double)] = Double.MinValue;
            DbTypeDictionary[typeof(decimal)] = Decimal.MinValue;
            DbTypeDictionary[typeof(bool)] = false;
            DbTypeDictionary[typeof(string)] = String.Empty;
            DbTypeDictionary[typeof(char)] = Single.MinValue;
            DbTypeDictionary[typeof(Guid)] = Guid.Empty;
            DbTypeDictionary[typeof(DateTime)] = DateTime.MinValue;
            DbTypeDictionary[typeof(DateTimeOffset)] = DateTimeOffset.MinValue;
            DbTypeDictionary[typeof(byte[])] = Byte.MinValue;
            DbTypeDictionary[typeof(byte?)] = Byte.MinValue;
            DbTypeDictionary[typeof(sbyte?)] = SByte.MinValue;
            DbTypeDictionary[typeof(short?)] = Int16.MinValue;
            DbTypeDictionary[typeof(ushort?)] = UInt16.MinValue;
            DbTypeDictionary[typeof(int?)] = Int32.MinValue;
            DbTypeDictionary[typeof(uint?)] = UInt32.MinValue;
            DbTypeDictionary[typeof(long?)] = Int64.MinValue;
            DbTypeDictionary[typeof(ulong?)] = UInt64.MinValue;
            DbTypeDictionary[typeof(float?)] = Single.MinValue;
            DbTypeDictionary[typeof(double?)] = Double.MinValue;
            DbTypeDictionary[typeof(decimal?)] = Decimal.MinValue;
            DbTypeDictionary[typeof(bool?)] = false;
            DbTypeDictionary[typeof(char?)] = Char.MinValue;
            DbTypeDictionary[typeof(Guid?)] = Guid.Empty;
            DbTypeDictionary[typeof(DateTime?)] = DateTime.MinValue;
            DbTypeDictionary[typeof(DateTimeOffset?)] = DateTimeOffset.MinValue;

            // DbTypeDictionary[typeof(System.Data.Linq.Binary)] = Binary.MinValue;
        }

        public bool IsNull(object value)
        {
            return value.Equals(DbTypeDictionary[value.GetType()]);
        }
    }
}
