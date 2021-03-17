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
    }
}
