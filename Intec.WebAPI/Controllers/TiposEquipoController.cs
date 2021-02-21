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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TiposEquipoController : DefaultController
    {
        [HttpPost]
        [Route("api/TiposEquipo/ObtenerTiposEquipo")]
        public JObject ObtenerTiposEquipo([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.AdministracionBE().ObtenerTiposEquipos());
            return response;
        }
        
        [HttpPost]
        [Route("api/TiposEquipo/ObtenerTiposEquipoActivos")]
        public JObject ObtenerTiposEquipoActivos([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.AdministracionBE().ObtenerTiposEquiposActivos());
            return response;
        }

        [HttpPost]
        [Route("api/TiposEquipo/ObtenerTipoEquipo")]
        public JObject ObtenerTipoEquipo([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.AdministracionBE().ObtenerTipoEquipo(Token["idTipoEquipo"].ToObject<int>()));
            return response;
        }

        [HttpPost]
        [Route("api/TiposEquipo/CrearTipoEquipo")]
        public JObject CrearTipoEquipo([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().CrearTipoEquipo(Token["tipoEquipo"].ToObject<Intec.BL.DTO.TiposEquipo>());
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
        [Route("api/TiposEquipo/ActualizarTipoEquipo")]
        public JObject ActualizarTipoEquipo([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken) { 
                try
                {
                    new Intec.BL.BE.AdministracionBE().EditarTipoEquipo(Token["tipoEquipo"].ToObject<Intec.BL.DTO.TiposEquipo>(), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
        [Route("api/TiposEquipo/EliminarTipoEquipo")]
        public JObject EliminarTipoEquipo([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EliminarTipoEquipo(int.Parse(Token["idTipoEquipo"].ToString()), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
