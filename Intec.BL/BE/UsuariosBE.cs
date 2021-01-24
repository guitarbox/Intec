using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class UsuariosBE : _beDefault
    {
        public int CrearUsuario(DTO.Usuarios UsuarioCrear)
        {
            return new DAL.TE.UsuariosTE().CrearUsuario(MapperConfig.Config.MapperUsuarios.Map<DAL.Usuarios>(UsuarioCrear));
        }

        public void NotificarCreacionUsuario(int IdUsuario)
        {
            DAL.Usuarios resDal = new DAL.TE.UsuariosTE().ConsultarUsuario(IdUsuario);
            if (resDal != null)
            {
                string[] param = BE.ParametrosBE.Parametros.Where(p => p.IdParametro == (int)Common.Enums.Parametros.SEND_MAIL_CONF).FirstOrDefault().ValorParametro.Split(';');
                //intratec@intecsas.com.co;intr4t3c@;mail.intecsas.com.co;465
                new Common.Mail().SendEmail(new List<string>() { resDal.Email }, "Creación Usuario - Intratec - IntecSAS",
                    "", //string Body, //TODO: Acá se notifica al usuario de la creación de su usuario, indicándole qué contraseña tiene incialmente y que debe cambiarla
                    new List<string>(),
                    param[0], param[1], param[2], int.Parse(param[3]), out string msjError);
            }
        }

        public void SolicitarCambioContrasena(string NumeroIdentificacion, string Email)
        {            
            DAL.Usuarios resDal = new DAL.TE.UsuariosTE().ConsultarUsuarioParaCambioContrasena(NumeroIdentificacion, Email);
            if(resDal != null)
            {
                string[] param = BE.ParametrosBE.Parametros.Where(p => p.IdParametro == (int)Common.Enums.Parametros.SEND_MAIL_CONF).FirstOrDefault().ValorParametro.Split(';');
                //intratec@intecsas.com.co;intr4t3c@;mail.intecsas.com.co;465
                new Common.Mail().SendEmail(new List<string>() { resDal.Email }, "Cambio de Contraseña - Intratec - IntecSAS", 
                    "", //string Body, //TODO: Acá se debe enviar el link para restaurar la contraseña.
                    new List<string> (),
                    param[0], param[1], param[2], int.Parse(param[3]), out string msjError);
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