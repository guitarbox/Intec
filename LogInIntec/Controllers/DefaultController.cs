using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogInIntec.Controllers
{
    public class DefaultController : Controller
    {
        public Dictionary<string, object> ansDic;
        public DefaultController()
        {
            ansDic = new Dictionary<string, object>
            {
                { "data", null },
                { "count", null },
                { "error", null },
                { "errorMessage", null }
            };
        }

        public void SetDicRta(object data, int count, bool error, string errorMessage, string duration)
        {
            ansDic["data"] = data;
            ansDic["count"] = count;
            ansDic["error"] = error;
            ansDic["errorMessage"] = errorMessage;
            ansDic["duration"] = duration;
        }
    }
}