using Intec.BL.DTO;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Intec.WebApi.Controllers
{
    public class UsosPropiedadesController : DefaultController
    {
        [HttpPost]
        [Route("api/UsosPropiedades/ObtenerUsosPropiedades")]
        public JObject ObtenerUsosPropiedades([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.AdministracionBE().ObtenerUsosPropiedades());
            return response;
        }

        [HttpPost]
        [Route("api/UsosPropiedades/ObtenerUsoPropiedad")]
        public JObject ObtenerUsoPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse( new Intec.BL.BE.AdministracionBE().ObtenerUsoPropiedad(Token["idUsoPropiedad"].ToObject<int>()));
            return response;
        }

        [HttpPost]
        [Route("api/UsosPropiedades/CrearUsoPropiedad")]
        public JObject CrearUsoPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().CrearUsoPropiedad(Token["usoPropiedad"].ToObject<Intec.BL.DTO.UsosPropiedades>());
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
        [Route("api/UsosPropiedades/ActualizarUsoPropiedad")]
        public JObject ActualizarUsoPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken) { 
                try
                {
                    new Intec.BL.BE.AdministracionBE().EditarUsoPropiedad(Token["usoPropiedad"].ToObject<Intec.BL.DTO.UsosPropiedades>(), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
        [Route("api/UsosPropiedades/EliminarUsoPropiedad")]
        public JObject EliminarUsoPropiedad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EliminarUsoPropiedad(int.Parse(Token["idUsoPropiedad"].ToString()), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
