using Intec.BL.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebGrease.Configuration;

namespace Intec.WebApi.Controllers
{
    public class TiposIdentificacionController : DefaultController
    {
        [HttpPost]
        [Route("api/TiposIdentificacion/ObtenerTiposIdentificacion")]
        public JObject ObtenerTiposIdentificacion([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.AdministracionBE().ObtenerTiposIdentificacion());
            return response;
        }

        [HttpPost]
        [Route("api/TiposIdentificacion/ObtenerTipoIdentificacion")]
        public JObject ObtenerTipoIdentificacion([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerTipoIdentificacion(Token["idTipoIdentificacion"].ToObject<int>()));
            return response;
        }

        [HttpPost]
        [Route("api/TiposIdentificacion/CrearTipoIdentificacion")]
        public JObject CrearTipoIdentificacion([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().CrearTipoIdentificacion(Token["tipoIdentificacion"].ToObject< Intec.BL.DTO.TiposIdentificacion>());
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
        [Route("api/TiposIdentificacion/ActualizarTipoIdentificacion")]
        public JObject ActualizarTipoIdentificacion([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EditarTipoIdentificacion(Token["tipoIdentificacion"].ToObject<Intec.BL.DTO.TiposIdentificacion>(), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
        [Route("api/TiposIdentificacion/EliminarTipoIdentificacion")]
        public JObject EliminarTipoIdentificacion([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EliminarTipoIdentificacion(int.Parse(Token["idTipoIdentificacion"].ToString()), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
