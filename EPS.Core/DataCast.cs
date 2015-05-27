using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public class DataCast
    {
        public static DataTable ListToDataTable<T>(IEnumerable<T> list)
        {
            var dt = new DataTable();

            var props = typeof(T).GetProperties();
            var cols = new List<PropertyInfo>();
            foreach (var item in props)
            {
                if (!item.Name.StartsWith("Non"))
                {
                    cols.Add(item);
                    if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        dt.Columns.Add(item.Name, item.PropertyType.GetGenericArguments()[0]);
                    }
                    else
                    {
                        dt.Columns.Add(item.Name, Type.GetType(item.PropertyType.ToString()));
                    }
                }
            }

            var len = cols.Count;
            foreach (T t in list)
            {
                var dr = dt.NewRow();
                for (var j = 0; j < len; j++)
                {
                    dr[j] = cols[j].GetValue(t, null) ?? DBNull.Value;
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        public static T Get<T>(object value)
        {
            if (Convert.IsDBNull(value) || value == null)
            {
                return default(T);
            }
            var typeCode = System.Type.GetTypeCode(typeof(T));
            var convertible = value as IConvertible;
            if (convertible == null)
                return default(T);

            switch (typeCode)
            {
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.DateTime:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    try
                    {
                        return (T) convertible.ToType(typeof (T), CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        return default(T);
                    }
            }

            return (T)value;
        }

        public static T? TryGet<T>(object value)
            where T : struct
        {
            if (Convert.IsDBNull(value) || value == null)
            {
                return null;
            }
            else
            {
                return Get<T>(value);
            }
        }

        public static bool IsNull(object value)
        {
            if (Equals(null, value))
            {
                return true;
            }
            if (Convert.IsDBNull(value))
            {
                return true;
            }

            return false;
        }
    }
}
