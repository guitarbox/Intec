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
    public class PaisesController : DefaultController
    {        
        [HttpPost]
        [Route("api/Paises/ObtenerPaises")]
        public JObject ObtenerPaises([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if(validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerPaises());
            return response;
        }
        
        [HttpPost]
        [Route("api/Paises/ObtenerPaisesActivos")]
        public JObject ObtenerPaisesActivos([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if(validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerPaisesActivos());
            return response;
        }

        //GET: api/Pais/5/Departamentos
        [HttpPost]
        [Route("api/Paises/ObtenerDepartamentos")]//Pregunta
        public JObject ObtenerDepartamentos([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if(validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerDepartamentos(Token["idPais"].ToObject<int>()));
            return response;
        }

        [HttpPost]
        [Route("api/Paises/ObtenerDepartamentosActivos")]//Pregunta
        public JObject ObtenerDepartamentosActivos([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerDepartamentosActivos(Token["idPais"].ToObject<int>()));
            return response;
        }

        // GET: api/Paises/5

        [HttpPost]
        [Route("api/Paises/ObtenerPais")]
        public JObject ObtenerPais([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if(validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerPais(Token["idPais"].ToObject<int>()));
            return response;
        }

        // POST: api/Paises
        [HttpPost]
        [Route("api/Paises/CrearPais")]
        public JObject CrearPais([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().CrearPais(Token["pais"].ToObject<Intec.BL.DTO.Paises>());
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

        //// PUT: api/Paises/5
        [HttpPost]
        [Route("api/Paises/ActualizarPais")]
        public JObject ActualizarPais([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EditarPais(Token["pais"].ToObject<Intec.BL.DTO.Paises>(), int.Parse(Token["idUsuarioModificacion"].ToString()));
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


        //// DELETE: api/Paises/5
        [HttpPost]
        [Route("api/Paises/EliminarPais")]
        public JObject EliminarPais([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EliminarPais(int.Parse(Token["idPais"].ToString()), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
