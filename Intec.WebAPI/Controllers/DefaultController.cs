﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Intec.WebApi.Controllers
{
    public class DefaultController : ApiController
    {
        public bool error = false;
        public string msgError = string.Empty;
        public JObject response = new JObject();

        public void SetErrorResponse(bool Error)
        {
            if (response.ContainsKey("error"))
            {
                response["error"] = Error;
            }
            else
            {
                response.Add("error", JToken.FromObject(Error));
            }
        }

        public void SetMsgErrorResponse(string MsgError)
        {
            if (response.ContainsKey("msgError"))
            {
                response["msgError"] = MsgError;
            }
            else
            {
                response.Add("msgError", JToken.FromObject(MsgError));
            }
        }
    }
}