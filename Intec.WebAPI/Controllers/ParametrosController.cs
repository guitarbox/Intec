using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Intec.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]    
    public class ParametrosController : DefaultController
    {
        [HttpPost]
        [Route("api/Parametros/ObtenerParametros")]
        public JObject ObtenerParametros([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(Intec.BL.BE.ParametrosBE.Parametros);
            return response;
        }
        

        [HttpPost]
        [Route("api/Parametros/ObtenerParametro")]
        public JObject ObtenerParametro([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(Intec.BL.BE.ParametrosBE.Parametros.Where(p => p.IdParametro == Token["idParametro"].ToObject<int>()).FirstOrDefault());
            return response;            
        }
        
        //[HttpPost]
        ////Create
        //[HttpPut]
        ////update
    }
}
