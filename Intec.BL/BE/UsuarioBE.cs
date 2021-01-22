using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class UsuarioBE : _beDefault
    {
        public int CrearUsuario(DTO.Usuarios UsuarioCrear)
        {
            return new DAL.TE.UsuariosTE().CrearUsuario(MapperConfig.Config.MapperUsuarios.Map<DAL.Usuarios>(UsuarioCrear));
        }

        public void NotificarCreacionUsuario(int IdUsuario)
        {
            //TODO: Acá se notifica al usuario de la creación de su usuario, indicándole qué contraseña tiene incialmente y que debe cambiarla
        }

        public void SolicitarCambioContrasena(string NumeroIdentificacion, string Email)
        {            
            DAL.Usuarios resDal = new DAL.TE.UsuariosTE().ConsultarUsuarioParaCambioContrasena(NumeroIdentificacion, Email);
            if(resDal != null)
            {
                string param = BE.ParametrosBE.Parametros.Where(p => p.IdParametro == (int)Common.Enums.Parametros.SEND_MAIL_CONF).FirstOrDefault().ValorParametro;
                //TODO: Acá se debe enviar el link para restaurar la contraseña.
            }
        }

        public DTO.Usuarios IniciarSesion(string NumeroIdentificacion, string Pass)
        {
            return MapperConfig.Config.MapperUsuarios.Map<DTO.Usuarios>(new DAL.TE.UsuariosTE().IniciarSesion(NumeroIdentificacion, Pass));
        }

        public void ActualizarContrasena(int IdUsuario, string Contrasena)
        {
            new DAL.TE.UsuariosTE().ActualizarContrasena(IdUsuario, Contrasena);
        }
    }
}