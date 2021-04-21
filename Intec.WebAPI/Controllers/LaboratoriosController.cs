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
    public class LaboratoriosController : DefaultController
    {
        [HttpPost]
        [Route("api/Laboratorios/ObtenerLaboratorios")]
        public JObject ObtenerLaboratorios([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerLaboratorios());
            return response;
        }
        
        [HttpPost]
        [Route("api/Laboratorios/CrearLaboratorio")]
        public JObject CrearLaboratorio([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                new Intec.BL.BE.AdministracionBE().CrearLaboratorio(Token["laboratorio"].ToObject<BL.DTO.Laboratorios>());
            return response;
        }
    }
}
