using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntecWebPage.Controllers
{
    public class DefaultController : Controller
    {
        public Dictionary<string, object> ansDic;
        public DefaultController()
        {
            ansDic = new Dictionary<string, object>();
            ansDic.Add("data", null);
            ansDic.Add("count", null);
            ansDic.Add("error", null);
            ansDic.Add("errorMessage", null);
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