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
    public class MarcasEquiposController : DefaultController
    {
        [HttpPost]
        [Route("api/MarcasEquipos/ObtenerMarcasEquipos")]
        public JObject ObtenerMarcasEquipos([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.AdministracionBE().ObtenerMarcasEquipos());
            return response;
        }

        [HttpPost]
        [Route("api/MarcasEquipos/ObtenerMarcaEquipos")]
        public JObject ObtenerMarcaEquipos([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.AdministracionBE().ObtenerMarcaEquipo(Token["idMarcaEquipo"].ToObject<int>()));
            return response;
        }

        [HttpPost]
        [Route("api/MarcasEquipos/CrearMarcaEquipos")]
        public JObject CrearMarcaEquipos([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().CrearMarcaEquipo(Token["marcaEquipo"].ToObject<Intec.BL.DTO.MarcasEquipos>());
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
        [Route("api/MarcasEquipos/ActualizarMarcasEquipos")]
        public JObject ActualizarMarcasEquipos([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EditarMarcaEquipo(Token["marcaEquipo"].ToObject<Intec.BL.DTO.MarcasEquipos>(), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
        [Route("api/MarcasEquipos/EliminarMarcaEquipos")]
        public JObject EliminarMarcaEquipos([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EliminarMarcaEquipo(int.Parse(Token["idMarcaEquipo"].ToString()), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
