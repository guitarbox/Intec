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
        public List<Intec.BL.DTO.Usuarios> Get()
        {
            return new Intec.BL.BE.UsuariosBE().ObtenerUsuarios();
        }
        
        public Intec.BL.DTO.Usuarios Get(int id)
        {
            return new Intec.BL.BE.UsuariosBE().ConsultarUsuario(id);
        }

        public JObject Post([FromBody]Intec.BL.DTO.Usuarios Usuario)
        {
            try
            {
                new Intec.BL.BE.UsuariosBE().CrearUsuario(Usuario);
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

        public JObject Put([FromBody]JObject UsuarioActualizarJO)
        {
            try
            {
                new Intec.BL.BE.UsuariosBE().ActualizarUsuario(UsuarioActualizarJO["Usuario"].ToObject<Intec.BL.DTO.Usuarios>(), int.Parse(UsuarioActualizarJO["IdUsuarioModificacion"].ToString()));
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

        //Rutas adicionales
        [Route("api/Usuarios/LogIn")]
        [HttpPost]
        public Intec.BL.DTO.Usuarios LogIn([FromBody] TokenLogIn Token)
        {
            return new Intec.BL.BE.UsuariosBE().IniciarSesion(Token.NumeroIdentificacion, Token.Password);
        }

        [Route("api/Usuarios/RecuperarContrasena")]
        [HttpPost]
        public bool RecuperarContrasena([FromBody] TokenRecuperarContrasena Token)
        {
            return new Intec.BL.BE.UsuariosBE().SolicitarCambioContrasena(Token.NumeroIdentificacion, Token.Email);
        }
        
        [Route("api/Usuarios/ValidarTokenModPass")]
        [HttpPost]
        public bool ValidarTokenModPass([FromBody] TokenModPass Token)
        {
            return new Intec.BL.BE.UsuariosBE().ValidarTokenModPass(Token.Token);
        }
        
        [Route("api/Usuarios/ModificarContrasena")]
        [HttpPost]
        public bool ModificarContrasena([FromBody] JObject Token)
        {
            return new Intec.BL.BE.UsuariosBE().ActualizarContrasena(Token["token"].ToString(), Token["NuevaContrasena"].ToString());
        }
    }
}