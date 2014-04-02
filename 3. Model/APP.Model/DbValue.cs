using System;
using System.Collections.Generic;
using System.Data;

namespace APP.Model
{
    public class DbValue
    {
        private static Dictionary<Type, DbType> DbTypeDictionary { get; set; }

        public DbType this[Type index]
        {
            get
            {
                return DbTypeDictionary[index];
            }
        }

        static DbValue()
        {
            DbTypeDictionary = new Dictionary<Type, DbType>();

            DbTypeDictionary[typeof(byte)] = DbType.Byte;
            DbTypeDictionary[typeof(sbyte)] = DbType.SByte;
            DbTypeDictionary[typeof(short)] = DbType.Int16;
            DbTypeDictionary[typeof(ushort)] = DbType.UInt16;
            DbTypeDictionary[typeof(int)] = DbType.Int32;
            DbTypeDictionary[typeof(uint)] = DbType.UInt32;
            DbTypeDictionary[typeof(long)] = DbType.Int64;
            DbTypeDictionary[typeof(ulong)] = DbType.UInt64;
            DbTypeDictionary[typeof(float)] = DbType.Single;
            DbTypeDictionary[typeof(double)] = DbType.Double;
            DbTypeDictionary[typeof(decimal)] = DbType.Decimal;
            DbTypeDictionary[typeof(bool)] = DbType.Boolean;
            DbTypeDictionary[typeof(string)] = DbType.String;
            DbTypeDictionary[typeof(char)] = DbType.StringFixedLength;
            DbTypeDictionary[typeof(Guid)] = DbType.Guid;
            DbTypeDictionary[typeof(DateTime)] = DbType.DateTime;
            DbTypeDictionary[typeof(DateTimeOffset)] = DbType.DateTimeOffset;
            DbTypeDictionary[typeof(byte[])] = DbType.Binary;
            DbTypeDictionary[typeof(byte?)] = DbType.Byte;
            DbTypeDictionary[typeof(sbyte?)] = DbType.SByte;
            DbTypeDictionary[typeof(short?)] = DbType.Int16;
            DbTypeDictionary[typeof(ushort?)] = DbType.UInt16;
            DbTypeDictionary[typeof(int?)] = DbType.Int32;
            DbTypeDictionary[typeof(uint?)] = DbType.UInt32;
            DbTypeDictionary[typeof(long?)] = DbType.Int64;
            DbTypeDictionary[typeof(ulong?)] = DbType.UInt64;
            DbTypeDictionary[typeof(float?)] = DbType.Single;
            DbTypeDictionary[typeof(double?)] = DbType.Double;
            DbTypeDictionary[typeof(decimal?)] = DbType.Decimal;
            DbTypeDictionary[typeof(bool?)] = DbType.Boolean;
            DbTypeDictionary[typeof(char?)] = DbType.StringFixedLength;
            DbTypeDictionary[typeof(Guid?)] = DbType.Guid;
            DbTypeDictionary[typeof(DateTime?)] = DbType.DateTime;
            DbTypeDictionary[typeof(DateTimeOffset?)] = DbType.DateTimeOffset;

            // DbTypeDictionary[typeof(System.Data.Linq.Binary)] = DbType.Binary;
        }
    }
}
