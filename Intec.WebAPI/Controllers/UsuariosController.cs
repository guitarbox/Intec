using Intec.WebApi.Models;
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
    public class UsuariosController : DefaultController
    {
        [HttpPost]
        [Route("api/Usuarios/ObtenerUsuarios")]
        public JObject ObtenerUsuarios([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.UsuariosBE().ObtenerUsuarios());
            return response;
        }

        [HttpPost]
        [Route("api/Usuarios/ObtenerUsuario")]
        public JObject ObtenerUsuario([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.UsuariosBE().ConsultarUsuario(Token["idUsuario"].ToObject<int>()));

            return response;
        }

        [HttpPost]
        [Route("api/Usuarios/CrearUsuario")]
        public JObject CrearUsuario([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    int idUsuarioCreado = new Intec.BL.BE.UsuariosBE().CrearUsuario(Token["usuario"].ToObject<Intec.BL.DTO.Usuarios>());
                    SetDataResponse(idUsuarioCreado);
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
        [Route("api/Usuarios/ActualizarUsuario")]
        public JObject ActualizarUsuario([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.UsuariosBE().ActualizarUsuario(Token["usuario"].ToObject<Intec.BL.DTO.Usuarios>(), int.Parse(Token["idUsuarioModificacion"].ToString()));
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
        [Route("api/Usuarios/GetUsuariosByIdRol")]
        public JObject GetUsuariosByIdRol([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    SetDataResponse(new Intec.BL.BE.UsuariosBE().GetUsuariosByIdRol(int.Parse(Token["idRol"].ToString())));
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

        //Rutas adicionales
        [Route("api/Usuarios/LogIn")]
        [HttpPost]
        public JObject LogIn([FromBody] JObject Token)
        {
            try
            {
                SetDataResponse(new Intec.BL.BE.UsuariosBE().IniciarSesion(Token["NumeroIdentificacion"].ToString(), Token["Password"].ToString()));
            }
            catch (Exception ex)
            {
                error = true;
                msgError = ex.Message;
            }

            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);        

            return response;
        }

        [Route("api/Usuarios/RecuperarContrasena")]
        [HttpPost]
        public bool RecuperarContrasena([FromBody] JObject Token)
        {
            return new Intec.BL.BE.UsuariosBE().SolicitarCambioContrasena(Token["NumeroIdentificacion"].ToString(), Token["Email"].ToString());
        }
        
        [Route("api/Usuarios/ValidarTokenModPass")]
        [HttpPost]
        public bool ValidarTokenModPass([FromBody] JObject Token)
        {
            return new Intec.BL.BE.UsuariosBE().ValidarTokenModPass(Token["Token"].ToString());
        }
        
        [Route("api/Usuarios/ModificarContrasena")]
        [HttpPost]
        public bool ModificarContrasena([FromBody] JObject Token)
        {
            return new Intec.BL.BE.UsuariosBE().ActualizarContrasena(Token["token"].ToString(), Token["NuevaContrasena"].ToString());
        }

        [HttpPost]
        [Route("api/Usuarios/AgregarCertificadoCompetencias")]
        public JObject AgregarCertificadoCompetencias([FromBody]JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.UsuariosBE().AgregarCertificadoCompetencias(Token["CertificadoAgregar"].ToObject<Intec.BL.DTO.CertificadosCompetencias>());
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