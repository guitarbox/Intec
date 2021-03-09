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
    }
}
