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
    public class CiudadesController : DefaultController
    {
        // GET: api/Ciudades
        //public List<Ciudades> Get(string id)
        //{
        //    return new Intec.BL.BE.AdministracionBE().ObtenerCiudades(id);
        //}

        // GET: api/Ciudades/5
        [HttpPost]
        [Route("api/Departamentos/ObtenerCiudad")]
        public JObject ObtenerCiudad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerCiudad(Token["idCiudad"].ToObject<string>()));
            return response;
        }

        // POST: api/Ciudades
        [HttpPost]
        [Route("api/Departamentos/CrearCiudad")]
        public JObject CrearCiudad([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().CrearCiudad(Token["ciudad"].ToObject<Intec.BL.DTO.Ciudades>());
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

        //Resultado OK

        // PUT: api/Ciudades/5
        [HttpPost]
        [Route("api/Departamentos/ActualizarCiudad")]
        public JObject ActualizarCiudad(int id, [FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EditarCiudad(Token["ciudad"].ToObject<Intec.BL.DTO.Ciudades>(), int.Parse(Token["idUsuarioModificacion"].ToString()));
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

        //Resultado OK

        // DELETE: api/Ciudades/5
        [HttpPost]
        [Route("api/Departamentos/EliminarCiudad")]
        public JObject EliminarCiudad(int id, [FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EliminarCiudad((Token["IdCiudad"].ToString()), int.Parse(Token["IdUsuarioModificacion"].ToString()));
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

        //Resultado OK
    }
}
