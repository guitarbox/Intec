using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Intec.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VisitasController : DefaultController
    {
        //Zonas

        [HttpPost]
        [Route("api/Visitas/ObtenerZonas")]
        public JObject ObtenerZonas([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
                SetDataResponse(new Intec.BL.BE.VisitasBE().ObtenerZonas(Token["idCiudad"].ToString()));
            return response;
        }
        
        [HttpPost]
        [Route("api/Visitas/ObtenerZonasAll")]
        public JObject ObtenerZonasAll([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
                SetDataResponse(new Intec.BL.BE.VisitasBE().ObtenerZonasAll());
            return response;
        }


        [HttpPost]
        [Route("api/Visitas/ObtenerZona")]
        public JObject ObtenerZona([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
                SetDataResponse(new Intec.BL.BE.VisitasBE().ObtenerZona(Token["idZona"].ToObject<int>()));
            return response;
        }


        [HttpPost]
        [Route("api/Visitas/CrearZona")]
        public JObject CrearZona([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.VisitasBE().CrearZona(Token["zona"].ToObject<Intec.BL.DTO.Zonas>());
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


        //ASignación de zona a inspector, con manejo del histórico


        [HttpPost]
        [Route("api/Visitas/AsignarZonaInspector")]
        public JObject AsignarZonaInspector([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.VisitasBE().AsignarZonaInspector(int.Parse(Token["idZona"].ToString()),
                                                                        (Token["idCiudad"].ToString()),
                                                                        int.Parse(Token["idInspector"].ToString()),
                                                                        int.Parse(Token["idUsuarioAsigna"].ToString()));
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
        [Route("api/Visitas/ReAsignarZonaInspector")]
        public JObject ReAsignarZonaInspector([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.VisitasBE().ReAsignarZonaInspector(int.Parse(Token["idZona"].ToString()),
                                                                        (Token["idCiudad"].ToString()),
                                                                        int.Parse(Token["idNvoInspector"].ToString()),
                                                                        int.Parse(Token["idUsuarioReAsigna"].ToString()));
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


        //Programación Visita


        [HttpPost]
        [Route("api/Visitas/ProgramarVisita")]
        public JObject ProgramarVisita([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.VisitasBE().ProgramarVisita(Token["visita"].ToObject<Intec.BL.DTO.Visitas>(), Token["nroPoliza"].ToString());
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
        [Route("api/Visitas/ReasignacionVisita")]
        public JObject ReasignacionVisita([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.VisitasBE().ReasignacionVisita(int.Parse(Token["idVisita"].ToString()),
                                                                        int.Parse(Token["idInspector"].ToString()));
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
        [Route("api/Visitas/AgregarFotoVisita")]
        public JObject AgregarFotoVisita([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.VisitasBE().AgregarFotoVisita((Token["foto"].ToObject<Intec.BL.DTO.FotosVisita>()),
                                                                        int.Parse(Token["idVisita"].ToString()),
                                                                        int.Parse(Token["idInspector"].ToString()));
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
        [Route("api/Visitas/AgregarFormatoVisita")]
        public JObject AgregarFormatoVisita([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.VisitasBE().AgregarFormatoVisita((Token["formato"].ToObject<Intec.BL.DTO.FormatosVisita>()),
                                                                        int.Parse(Token["idVisita"].ToString()),
                                                                        int.Parse(Token["idInspector"].ToString()));
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
        [Route("api/Visitas/AgregarEquipoVisita")]
        public JObject AgregarEquipoVisita([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.VisitasBE().AgregarEquipoVisita((Token["equipo"].ToObject<Intec.BL.DTO.EquiposVisita>()),
                                                                        int.Parse(Token["idVisita"].ToString()));
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



        //Reporte ejecución visitas / Consulta detallada de una visita
    


        [HttpPost]
        [Route("api/Visitas/ConsultarVisita")]
        public JObject ConsultarVisita([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
                SetDataResponse(new Intec.BL.BE.VisitasBE().ConsultarVisita(int.Parse(Token["idVisita"].ToString())));
            return response;
        }



        [HttpPost]
        [Route("api/Visitas/ConsultarVisitas")]
        public JObject ConsultaVisitas([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
                SetDataResponse(new Intec.BL.BE.VisitasBE().ConsultaVisitas(DateTime.Parse(Token["fechaInicial"].ToString(), new CultureInfo("es-Co")),
                                                                        DateTime.Parse(Token["fechaFinal"].ToString(), new CultureInfo("es-Co")),
                                                                        Token["numeroIdentificacionCliente"].ToString(),
                                                                        int.Parse(Token["idInspector"].ToString()),
                                                                        Token["idEstadoVisita"].ToString()));
            return response;
        }
        
        [HttpPost]
        [Route("api/Visitas/ObtenerEstadosVisita")]
        public JObject ObtenerEstadosVisita([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
                SetDataResponse(new Intec.BL.BE.VisitasBE().ObtenerEstadosVisita());
            return response;
        }
        
        [HttpPost]
        [Route("api/Visitas/EjecutarVisita")]
        public JObject EjecutarVisita([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.VisitasBE().EjecutarVisita(Token["idVisita"].ToObject<int>(), Token["idInspector"].ToObject<int>());
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
        [Route("api/Visitas/CancelarVisita")]
        public JObject CancelarVisita([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.VisitasBE().CancelarVisita(Token["idVisita"].ToObject<int>(), Token["observacionCancelacion"].ToString(), Token["idUsuarioCancelacion"].ToObject<int>());
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
        [Route("api/Visitas/FinalizarVisita")]
        public JObject FinalizarVisita([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.VisitasBE().FinalizarVisita(Token["idVisita"].ToObject<int>(), Token["observacion"].ToString(), Token["idInspector"].ToObject<int>());
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
