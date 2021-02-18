using Intec.BL.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Intec.WebApi.Controllers
{
    public class TiposPropiedadesController : DefaultController
    {
        [HttpPost]
        [Route("api/TiposPropiedad/ObtenerTiposPropiedad")]
        public JObject ObtenerTiposPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.AdministracionBE().ObtenerTiposPropiedades());
            return response;
        }

        [HttpPost]
        [Route("api/TiposPropiedad/ObtenerTipoPropiedad")]
        public JObject ObtenerTipoPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.AdministracionBE().ObtenerTipoPropiedad(Token["idTipoPropiedad"].ToObject<int>()));
            return response;
        }

        [HttpPost]
        [Route("api/TiposPropiedad/CrearTipoPropiedad")]
        public JObject CrearTipoPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().CrearTipoPropiedad(Token["tipoPropiedad"].ToObject<Intec.BL.DTO.TiposPropiedades>());
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
        [Route("api/TiposPropiedad/ActualizarTipoPropiedad")]
        public JObject ActualizarTipoPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EditarTipoPropiedad(Token["tipoPropiedad"].ToObject<Intec.BL.DTO.TiposPropiedades>(), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
        [Route("api/TiposPropiedad/EliminarTipoPropiedad")]
        public JObject EliminarTipoPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EliminarTipoPropiedad(int.Parse(Token["idTipoPropiedad"].ToString()), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
