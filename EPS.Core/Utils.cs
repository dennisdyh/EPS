using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Framework.Core
{
    public class Utils
    {
        public static T Dereference<T>(T source)
        {
            var formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
            object obj = null;
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, source);
                stream.Position = 0;
                obj = formatter.Deserialize(stream);
                stream.Flush();
                stream.Close();
            }

            var result = default(T);

            result = (T)Convert.ChangeType(obj, source.GetType());

            return result;
        }

        public static string RemoveLastStr(StringBuilder sb, string removeStr)
        {
            var str1 = sb.ToString();
            if (string.IsNullOrEmpty(str1))
            {
                return string.Empty;
            }
            var i = str1.LastIndexOf(removeStr, System.StringComparison.Ordinal);
            if (i > 0)
            {
                return str1.Substring(0, i);
            }
            else
            {
                return sb.ToString();
            }
        }
        public static string RemoveLastStr(string str, string removeStr)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            var i = str.LastIndexOf(removeStr, System.StringComparison.Ordinal);
            if (i > 0)
            {
                return str.Substring(0, i);
            }
            else
            {
                return str;
            }
        }
    }
}
