using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class _beDefault
    {
        public static string _duration { 
            get =>  (_end - _start).ToString();
        }
        private static DateTime _start { get; set; }
        private static DateTime _end { get; set; }
        public void Start()
        {
            _start = DateTime.Now;
        }
        public void Finish()
        {
            _end = DateTime.Now;
        }
    }
}
