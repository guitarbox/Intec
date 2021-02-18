using Intec.BL.DTO;
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
    public class PropiedadesController : DefaultController
    {
        [HttpPost]
        [Route("api/Propiedades/ObtenerPropiedad")]
        public JObject ObtenerPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.ClientesBE().ConsultaDetalladaPropiedad(Token["idPropiedad"].ToObject<int>()));
            return response;
        }

        [HttpPost]
        [Route("api/Propiedades/CrearPropiedad")]
        public JObject CrearPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.ClientesBE().CrearPropiedad(Token["propiedad"].ToObject<Intec.BL.DTO.Propiedades>());
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }

                SetErrorResponse(error);
                SetMsgErrorResponse(msgError);
            }
            return response;
        }

        [HttpPost]
        [Route("api/Propiedades/ActualizarPropiedad")]
        public JObject ActualizarPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.ClientesBE().EditarPropiedad(Token["propiedad"].ToObject<Intec.BL.DTO.Propiedades>(), int.Parse(Token["idUsuarioModificacion"].ToString()));
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }

                SetErrorResponse(error);
                SetMsgErrorResponse(msgError);
            }
            return response;
        }
    }
}
