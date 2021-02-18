using Intec.BL.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;

namespace Intec.WebApi.Controllers
{
    public class TiposPersonaController : DefaultController
    {
        [HttpPost]
        [Route("api/TiposPersona/ObtenerTiposPersona")]
        public JObject ObtenerTiposPersona([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerTiposPersona());
            return response;
        }

        [HttpPost]
        [Route("api/TiposPersona/ObtenerTipoPersona")]
        public JObject ObtenerTipoPersona([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.AdministracionBE().ObtenerTipoPersona(Token["idTipoPersona"].ToObject<int>()));
            return response;
        }

        [HttpPost]
        [Route("api/TiposPersona/CrearTipoPersona")]
        public JObject CrearTipoPersona([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().CrearTipoPersona(Token["tipoPersona"].ToObject<Intec.BL.DTO.TiposPersona>());
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
        [Route("api/TiposPersona/ActualizarTipoPersona")]
        public JObject ActualizarTipoPersona([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EditarTipoPersona(Token["TipoPersona"].ToObject<Intec.BL.DTO.TiposPersona>(), int.Parse(Token["IdUsuarioModificacion"].ToString()));
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
        [Route("api/TiposPersona/EliminarTipoPersona")]
        public JObject EliminarTipoPersona([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EliminarTipoPersona(int.Parse(Token["IdTipoPersona"].ToString()), int.Parse(Token["IdUsuarioModificacion"].ToString()));
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
