using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class UsuariosTE
    {
        
        public List<Usuarios> ObtenerUsuarios()
        {
            List<Usuarios> res = new List<Usuarios>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Usuarios.ToList();
            }
            return res;
        }        

        public int CrearUsuario(Usuarios UsuarioCrear)
        {
            int res = -1;
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                int us = ctx.Usuarios.Where(u => u.NumeroIdentificacion.Equals(UsuarioCrear.NumeroIdentificacion)).ToList().Count;
                if (us == 0)
                {
                    UsuarioCrear.FechaCreacion = DateTime.Now;
                    UsuarioCrear.Activo = true;
                    UsuarioCrear.Password = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(UsuarioCrear.NumeroIdentificacion));
                    UsuarioCrear.DebeCambiarContrasena = true;
                    ctx.Usuarios.Add(UsuarioCrear);
                    ctx.SaveChanges();
                    res = UsuarioCrear.IdUsuario;
                }
                else
                {
                    throw new Exception($"Ya existe un Usuario con Número de Identificación {UsuarioCrear.NumeroIdentificacion}");
                }

            }
            return res;
        }
        
        public void InactivarUsuario(int IdUsuario)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                ctx.Usuarios.Where(u => u.IdUsuario == IdUsuario).FirstOrDefault().Activo = false;
                ctx.SaveChanges();
            }
        }

        public Usuarios IniciarSesion(string NumeroIdentificacion, string Pass)
        {
            Usuarios res = null;
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                string pass = Convert.ToBase64String(Encoding.UTF8.GetBytes(Pass));
                string tokenSesion = $"{DateTime.Now.Ticks}{Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(NumeroIdentificacion))}";
                res = ctx.Usuarios.Where(c => c.NumeroIdentificacion.Equals(NumeroIdentificacion) && c.Password.Equals(pass) && c.Activo).FirstOrDefault();
                if(res != null)
                {
                    res.FechaUltimoInicioSesion = DateTime.Now;
                    res.tokenSesion = tokenSesion;
                    res.horaTokenSesion = DateTime.Now;
                    ctx.SaveChanges();                    
                    ctx.Entry(res).Reference(u=>u.Roles).Load();
                    res.Roles.Menus.ToList();
                    ctx.Entry(res).Reference(u=>u.TiposIdentificacion).Load();
                    ctx.Entry(res).Reference(u=>u.Ciudades).Load();                    
                }
            }
            return res;
        }

        public void ActualizarUsuario(Usuarios Usuario, int IdUsuarioModifica)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Usuarios usuarioModificar = ctx.Usuarios.Where(u => u.IdUsuario == Usuario.IdUsuario).FirstOrDefault();
                if (usuarioModificar != null)
                {
                    usuarioModificar.Nombres = Usuario.Nombres;
                    usuarioModificar.Apellidos = Usuario.Apellidos;
                    usuarioModificar.Direccion = Usuario.Direccion;
                    usuarioModificar.Telefono = Usuario.Telefono;
                    usuarioModificar.IdCiudadDomicilio = Usuario.IdCiudadDomicilio;
                    usuarioModificar.IdTipoIdentificacion = Usuario.IdTipoIdentificacion;
                    usuarioModificar.NumeroIdentificacion = Usuario.NumeroIdentificacion;
                    usuarioModificar.FechaUltimoInicioSesion = Usuario.FechaUltimoInicioSesion;
                    usuarioModificar.IdRol = Usuario.IdRol;
                    usuarioModificar.Activo = Usuario.Activo;
                    usuarioModificar.Foto = Usuario.Foto;
                    usuarioModificar.DebeCambiarContrasena = Usuario.DebeCambiarContrasena;
                    usuarioModificar.IdPaisOrigen = Usuario.IdPaisOrigen;

                    usuarioModificar.FechaModificacion = DateTime.Now;
                    usuarioModificar.IdUsuarioModificacion = IdUsuarioModifica;
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No existe el usuario");
            }
        }

        public void ActualizarContrasena(int IdUsuario, string Contrasena)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Usuarios usuarioModificar = ctx.Usuarios.Where(u => u.IdUsuario == IdUsuario).FirstOrDefault();
                if (usuarioModificar != null)
                {
                    usuarioModificar.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Contrasena));

                    usuarioModificar.FechaCreacion = DateTime.Now;
                    usuarioModificar.IdUsuarioModificacion = IdUsuario;
                    usuarioModificar.DebeCambiarContrasena = false;
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No existe el usuario");
            }
        }
        
        public bool ActualizarContrasena(string tokenModPass, string Contrasena)
        {
            bool res = false;
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                string token = Encoding.UTF8.GetString(Convert.FromBase64String(tokenModPass));
                Usuarios usuarioModificar = ctx.Usuarios.Where(u => u.tokenCambioContrasena.Equals(token)).FirstOrDefault();
                if (usuarioModificar != null)
                {
                    usuarioModificar.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Contrasena));

                    usuarioModificar.FechaCreacion = DateTime.Now;
                    usuarioModificar.IdUsuarioModificacion = usuarioModificar.IdUsuario;
                    usuarioModificar.DebeCambiarContrasena = false;
                    ctx.SaveChanges();
                    res = true;
                }
                else
                    throw new Exception("Token No válido");
            }
            return res;
        }
    
        public List<Usuarios> GetUsuariosByIdRol(int IdRol)
        {
            List<Usuarios> res = new List<Usuarios>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Usuarios.Where(u => u.IdRol == IdRol).ToList();
            }
            return res;
        }

        public Usuarios ConsultarUsuarioParaCambioContrasena(string numeroIdentificacion, string email)
        {
            Usuarios res = null;
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Usuarios.Where(u => u.NumeroIdentificacion.Equals(numeroIdentificacion) && u.Email.Equals(email)).FirstOrDefault();
                if (res != null)
                {
                    res.tokenCambioContrasena = $"{res.NumeroIdentificacion}_{DateTime.Now.Ticks}_{res.Email}_{DateTime.Now.Ticks}";
                    res.horaTokenCambioContrasena = DateTime.Now;
                    ctx.SaveChanges();
                    //ctx.Entry(res).Reference(u => u.Roles).Load();
                    //res.Roles.Menus.ToList();
                    //ctx.Entry(res).Reference(u => u.TiposIdentificacion).Load();
                    //ctx.Entry(res).Reference(u => u.Ciudades).Load();
                }
            }
            return res;
        }

        public Usuarios ConsultarUsuario(int IdUsuario)
        {
            Usuarios res = null;
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Usuarios.Where(u => u.IdUsuario == IdUsuario).FirstOrDefault();
                if (res != null)
                {
                    ctx.Entry(res).Reference(u => u.Roles).Load();
                    res.Roles.Menus.ToList();
                    ctx.Entry(res).Reference(u => u.TiposIdentificacion).Load();
                    ctx.Entry(res).Reference(u => u.Ciudades).Load();
                }
            }
            return res;
        }

        public bool ValidarTokenModPass(string tokenModPass)
        {
            bool res = false;
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                string token = Encoding.UTF8.GetString(Convert.FromBase64String(tokenModPass));
                Usuarios us = ctx.Usuarios.Where(u => u.tokenCambioContrasena.Equals(token)).FirstOrDefault();
                if(us != null)
                {
                    res = true;
                }
            }
            return res;
        }

        public bool ValidarSessionToken(string sessionToken)
        {
            bool res = false;
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                string token = Encoding.UTF8.GetString(Convert.FromBase64String(sessionToken));
                Usuarios us = ctx.Usuarios.Where(u => u.tokenSesion.Equals(token)).FirstOrDefault();
                if (us != null)
                {
                    res = true;
                }
            }
            return res;
        }
    }
}