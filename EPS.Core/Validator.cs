using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Framework.Core
{
    public class Validator
    {
        public static bool IsEmail(string source)
        {
            return Regex.IsMatch(source,

            @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@" +

            @"([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$",

            RegexOptions.IgnoreCase);
        }

        public static bool HasEmail(string source)
        {
            return Regex.IsMatch(source,

            @"[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@" +

            @"([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})",

            RegexOptions.IgnoreCase);
        }

        public static bool IsUrl(string source)
        {
            return Regex.IsMatch(source,

            @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)" +

            @"|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]" +

            @"{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$",

            RegexOptions.IgnoreCase);
        }

        public static bool HasUrl(string source)
        {
            return Regex.IsMatch(source,

            @"(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)" +

            @"|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]" +

            @"{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?",

            RegexOptions.IgnoreCase);
        }

        public static bool IsDateTime(string source)
        {
            try
            {
                Convert.ToDateTime(source);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsIP(string source)
        {
            return Regex.IsMatch(source,

            @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])" +

            @"\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]" +

            @"|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]" +

            @"|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$",

            RegexOptions.IgnoreCase);
        }

        public static bool HasIP(string source)
        {
            return Regex.IsMatch(source,

            @"(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])" +

            @"\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]" +

            @"|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]" +

            @"|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])",

            RegexOptions.IgnoreCase);
        }
        public static bool IsNormalChar(string source)
        {
            return Regex.IsMatch(source, @"[\w\d_]+", RegexOptions.IgnoreCase);
        }

        public static bool IsNumber(string inputData)
        {
            var RegNumber = new Regex("^[0-9]+$");
            var m = RegNumber.Match(inputData);
            return m.Success;
        }
    }
}
