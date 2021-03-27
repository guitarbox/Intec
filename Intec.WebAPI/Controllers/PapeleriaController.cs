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
    public class PapeleriaController : DefaultController
    {
        [HttpPost]
        [Route("api/Papeleria/ConsultarFormatos")]
        public JObject ConsultarFormatos([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    SetDataResponse(new Intec.BL.BE.PapeleriaBE().ConsultarFormatos());
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }
            }
            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);
            return response;
        }
        
        [HttpPost]
        [Route("api/Papeleria/EliminarFormato")]
        public JObject EliminarFormato([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.PapeleriaBE().EliminarFormato(Token["idFormato"].ToObject<int>());
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }
            }
            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);
            return response;
        }
        
        [HttpPost]
        [Route("api/Papeleria/CrearFormato")]
        public JObject CrearFormato([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                     new Intec.BL.BE.PapeleriaBE().CrearFormato(Token["formato"].ToObject<Intec.BL.DTO.Formatos>());
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }
            }
            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);
            return response;
        }
        
        [HttpPost]
        [Route("api/Papeleria/ActualizarFormato")]
        public JObject ActualizarFormato([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                     new Intec.BL.BE.PapeleriaBE().EditarFormato(Token["formato"].ToObject<Intec.BL.DTO.Formatos>(), Token["idUsuarioModificacion"].ToObject<int>());
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }
            }
            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);
            return response;
        }
        
        [HttpPost]
        [Route("api/Papeleria/ConsultarFormato")]
        public JObject ConsultarFormato([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    SetDataResponse( new Intec.BL.BE.PapeleriaBE().ConsultarFormato(Token["idFormato"].ToObject<int>()));
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }
            }
            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);
            return response;
        }
        
        [HttpPost]
        [Route("api/Papeleria/IngresarConsecutivosFormatoBodega")]
        public JObject IngresarConsecutivosFormatoBodega([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                     new Intec.BL.BE.PapeleriaBE().IngresarConsecutivosFormatoBodega(Token["idFormato"].ToObject<int>(), Token["consecutivoInicial"].ToObject<int>(), Token["consecutivoFinal"].ToObject<int>(), Token["idUsuarioAsigna"].ToObject<int>());
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }
            }
            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);
            return response;
        }
        
        [HttpPost]
        [Route("api/Papeleria/ActualizarEstadoConsecutivo")]
        public JObject ActualizarEstadoConsecutivo([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.PapeleriaBE().ActualizarEstadoConsecutivo(Token["idFormato"].ToObject<int>(), Token["consecutivoInicial"].ToObject<int>(), 
                        Token["consecutivoFinal"].ToObject<int>(), Token["idEstado"].ToString(), Token["idUsuarioActualiza"].ToObject<int>(), Token["observaciones"].ToString());
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }
            }
            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);
            return response;
        }
        
        [HttpPost]
        [Route("api/Papeleria/ActualizarEstadoConsecutivos")]
        public JObject ActualizarEstadoConsecutivos([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.PapeleriaBE().ActualizarEstadoConsecutivos(Token["idEstado"].ToString(), Token["idUsuarioActualiza"].ToObject<int>(), Token["observaciones"].ToString());
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }
            }
            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);
            return response;
        }
        
        [HttpPost]
        [Route("api/Papeleria/AsignarRangoConsecutivosFormatoInspector")]
        public JObject AsignarRangoConsecutivosFormatoInspector([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.PapeleriaBE().AsignarRangoConsecutivosFormatoInspector(Token["idFormato"].ToObject<int>(), Token["idInspector"].ToObject<int>(),
                        Token["consecutivoInicial"].ToObject<int>(), Token["consecutivoFinal"].ToObject<int>(), Token["idUsuarioAsigna"].ToObject<int>());
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }
            }
            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);
            return response;
        }
        
        [HttpPost]
        [Route("api/Papeleria/ConsultarTramiteConsecutivoFormato")]
        public JObject ConsultarTramiteConsecutivoFormato([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    SetDataResponse(new Intec.BL.BE.PapeleriaBE().ConsultarTramiteConsecutivoFormato(Token["idFormato"].ToObject<int>(), Token["consecutivo"].ToObject<int>()));
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }
            }
            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);
            return response;
        }
        
        [HttpPost]
        [Route("api/Papeleria/ObtenerConsecutivosUsuario")]
        public JObject ObtenerConsecutivosUsuario([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);
            if (validToken)
            {
                try
                {
                    SetDataResponse(new Intec.BL.BE.PapeleriaBE().ObtenerConsecutivosUsuario(Token["idUsuario"].ToObject<int>()));
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }
            }
            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);
            return response;
        }
    }
}
