using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.Common
{
    public class Util
    {
        static public string ObjectToJson(object Object)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(Object);
        }

        /**
         * Returns number of days to a specific date
         **/
        static public int? DaysToDate(DateTime? Date)
        {
            if (Date == null)
                return null;
            else
                return (Date.Value - DateTime.Now).Days;
        }
    }
}
