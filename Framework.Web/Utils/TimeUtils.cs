using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Core;


namespace Framework.Web.Utils
{
    public class TimeUtils
    {
        public static DateTime LocalToUtc(DateTime dt)
        {
            var Minutes1 = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours * 60;
            var Minutes2 = (int)LocalTimeZoneToMins();

            if (Minutes1 == Minutes2)
            {
                return dt.ToUniversalTime();
            }
            else
            {
                if (dt == DateTime.MaxValue)
                {
                    return DateTime.Now.AddMinutes(Minutes1 - Minutes2).ToUniversalTime();
                }
                else
                {
                    return dt.AddMinutes(Minutes1 - Minutes2).ToUniversalTime();
                }
            }
        }

        public static DateTime UtcTimeToClientTime(DateTime? utcTime)
        {
            var dt = utcTime ?? DateTime.UtcNow;
            var datetime = GetClientDateTime(dt);
            return datetime;
        }

        public static string UtcToClient(DateTime? utcTime)
        {
            if (utcTime.HasValue)
            {
                var datetime = GetClientDateTime(utcTime.Value);
                return datetime.ToString("yyyy-MM-dd HH:mm");
            }
            else
            {
                return string.Empty;
            }
        }

        public static string UtcTimeToClientTime(DateTime? utcTime, string format)
        {
            if (utcTime.HasValue)
            {
                var datetime = GetClientDateTime(utcTime.Value);
                return datetime.ToString(format);
            }
            else
            {
                return string.Empty;
            }
        }

        public static string FormatDateTime(DateTime? datetime)
        {
            return FormatDateTime(datetime, null);
        }

        public static string FormatDateTime(DateTime? datetime, string formater)
        {
            if (string.IsNullOrEmpty(formater))
            {
                formater = "yyyy-MM-dd HH:mm";
            }
            if (datetime.HasValue)
            {
                return datetime.Value.ToString(formater);
            }
            else
            {
                return string.Empty;
            }
        }

        public static string UtcTimeToClientShortDate(DateTime? utcTime)
        {
            var strDate = string.Empty;
            if (utcTime.HasValue)
            {
                strDate = GetClientDateTime(utcTime.Value).ToString("yyyy-MM-dd");
            }
            return strDate;
        }

        public static string UtcTimeToClientShortTime(DateTime? utcTime)
        {
            var strDate = string.Empty;
            if (utcTime.HasValue)
            {
                strDate = GetClientDateTime(utcTime.Value).ToShortTimeString();
            }
            return strDate;
        }

        public static double LocalTimeZoneToMins()
        {
            var timeOffset = Utility.CurrentLoginModel.ClientTimeZone;
            var hour = (int)(DataCast.Get<int>(timeOffset) / 60);
            var minute = (int)(DataCast.Get<int>(timeOffset) % 60);

            var prefix = "-";
            if (hour < 0 || minute < 0)
            {
                prefix = "+";
                hour = -hour;
                if (minute < 0)
                {
                    minute = -minute;
                }
            }
            if (prefix == "-")
            {
                hour = -hour;
            }

            return hour * 60 + (hour > 0 ? minute : -minute);
        }

        private static DateTime GetClientDateTime(DateTime dt)
        {
            try
            {
                var timeOffset = Utility.CurrentLoginModel.ClientTimeZone;
                var hour = (int)(DataCast.Get<int>(timeOffset) / 60);
                var minute = (int)(DataCast.Get<int>(timeOffset) % 60);

                var prefix = "-";
                if (hour < 0 || minute < 0)
                {
                    prefix = "+";
                    hour = -hour;
                    if (minute < 0)
                    {
                        minute = -minute;
                    }
                }


                dt = dt.AddHours(DataCast.Get<int>(prefix + hour));
                dt = dt.AddMinutes(minute);

                return dt;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static DateTime GetLocalDate(string fromLocalTime)
        {
            DateTime time;
            DateTime.TryParse(fromLocalTime, out time);

            return time;
        }
    }
}
