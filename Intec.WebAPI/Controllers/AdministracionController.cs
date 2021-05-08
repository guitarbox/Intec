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
    public class AdministracionController : DefaultController
    {
        [HttpPost]
        [Route("api/Administracion/ObtenerRoles")]
        public JObject ObtenerRoles([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerRoles());
            return response;
        }

        [HttpPost]
        [Route("api/Administracion/ObtenerTiposVisita")]
        public JObject ObtenerTiposVisita([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerTiposVisita());
            return response;
        }
        
        [HttpPost]
        [Route("api/Administracion/ObtenerFranjasHorario")]
        public JObject ObtenerFranjasHorario([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerFranjasHorario());
            return response;
        }
        
        [HttpPost]
        [Route("api/Administracion/ObtenerTiposFoto")]
        public JObject ObtenerTiposFoto([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerTiposFoto());
            return response;
        }
    }
}
