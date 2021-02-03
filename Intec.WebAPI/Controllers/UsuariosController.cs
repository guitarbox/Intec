using Intec.WebApi.Models;
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
    public class UsuariosController : ApiController
    {
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
    }
}