using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbzExtractor.utils
{
    public static class AppDateUtils
    {

        public static DateTime? DateTimeFromUnix(string unix)
        {
            if (double.TryParse(unix, out double unixD))
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dt = dt.AddSeconds(unixD);

                return dt;
            }

            return null;
        }

    }
}
