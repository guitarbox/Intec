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
    public class EquiposController : DefaultController
    {
        [HttpPost]
        [Route("api/Equipos/ObtenerEquipos")]
        public JObject ObtenerEquipos([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
                SetDataResponse(new Intec.BL.BE.EquiposBE().ObtenerEquipos(Token["idMarca"].ToObject<int>(), Token["idTipoEquipo"].ToObject<int>(), Token["filtro"].ToString()));
            return response;
        }


        [HttpPost]
        [Route("api/Equipos/CrearEquipo")]
        public JObject CrearEquipo([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.EquiposBE().AgregarEquipo(Token["equipo"].ToObject<Intec.BL.DTO.Equipos>());
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
        [Route("api/Equipos/EliminarEquipo")]
        public JObject EliminarEquipo([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.EquiposBE().EliminarEquipo(int.Parse(Token["idEquipo"].ToString()));
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
        [Route("api/Equipos/TramitarEquipoInspector")]
        public JObject TramitarEquipoInspector([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.EquiposBE().TramitarEquipoInspector(int.Parse(Token["idEquipo"].ToString()),
                                                                        int.Parse(Token["idInspector"].ToString()),
                                                                        int.Parse(Token["idUsuarioTramita"].ToString()),
                                                                        (Token["tramite"].ToString()),
                                                                        (Token["observaciones"].ToString()));
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
        [Route("api/Equipos/IngresarVerificacionALaboratorio")]
        public JObject IngresarVerificacionALaboratorio([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.EquiposBE().IngresarVerificacionLAB(Token["verificacion"].ToObject<Intec.BL.DTO.VerificacionesLabEquipos>());
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
        [Route("api/Equipos/IngresarACalibracionEquipo")]
        public JObject IngresarACalibracionEquipo([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.EquiposBE().IngresarCalibracionEq(Token["calibracion"].ToObject<Intec.BL.DTO.CalibracionesEquipos>());
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
