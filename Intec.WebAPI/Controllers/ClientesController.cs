using Intec.BL.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Intec.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : DefaultController
    {
        [HttpPost]
        [Route("api/Clientes/ObtenerClientes")]
        public JObject ObtenerClientes([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                SetDataResponse( new Intec.BL.BE.ClientesBE().ConsultaGralClientes(Token["numeroIdentificacion"].ToString(),
                Token["nombres"].ToString(),
                Token["direccion"].ToString(),
                Token["nroTelefonico"].ToString(),
                Boolean.Parse(Token["tieneVisitaProgramada"].ToString())));
            }
            return response;
        }

        [HttpPost]
        [Route("api/Clientes/ObtenerCliente")]
        public JObject ObtenerCliente([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)            
                SetDataResponse( new Intec.BL.BE.ClientesBE().ConsultaDetalladaClientes(Token["idCliente"].ToObject<int>()));
            return response;
        }

        [HttpPost]
        [Route("api/Clientes/CrearCliente")]
        public JObject CrearCliente([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.ClientesBE().CrearCliente(Token["cliente"].ToObject<Intec.BL.DTO.Clientes>());
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
        [Route("api/Clientes/ActualizarCliente")]
        public JObject ActualizarCliente([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.ClientesBE().EditarClientes(Token["cliente"].ToObject<Intec.BL.DTO.Clientes>(), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
