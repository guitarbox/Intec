using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class UsuariosTE
    {
        public void CrearUsuario(Usuarios UsuarioCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                int us = ctx.Usuarios.Where(u => u.NumeroIdentificacion.Equals(UsuarioCrear.NumeroIdentificacion)).ToList().Count;
                if (us == 0)
                {
                    UsuarioCrear.FechaCreacion = DateTime.Now;
                    ctx.Usuarios.Add(UsuarioCrear);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"Ya existe un Usuario con Número de Identificación {UsuarioCrear.NumeroIdentificacion}");
                }

            }
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
                res = ctx.Usuarios.Where(c => c.NumeroIdentificacion.Equals(NumeroIdentificacion) && c.Password.Equals(Pass) && c.Activo).FirstOrDefault();
                if(res != null)
                {
                    res.FechaUltimoInicioSesion = DateTime.Now;
                    ctx.SaveChanges();

                    ctx.Menus.ToList();
                    ctx.Entry(res).Reference(u=>u.Roles).Load();
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

                    usuarioModificar.FechaCreacion = DateTime.Now;
                    usuarioModificar.IdUsuarioModificacion = IdUsuarioModifica;
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No existe el usuario");
            }
        }
        
        public void ActualizarContrasena(int IdUssuario, string Contrasena)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Usuarios usuarioModificar = ctx.Usuarios.Where(u => u.IdUsuario == IdUssuario).FirstOrDefault();
                if (usuarioModificar != null)
                {
                    usuarioModificar.Password = Contrasena;

                    usuarioModificar.FechaCreacion = DateTime.Now;
                    usuarioModificar.IdUsuarioModificacion = IdUssuario;
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No existe el usuario");
            }
        }
    
        /**
         * 
         */
        public List<Usuarios> GetUsuariosByIdRol(int IdRol)
        {
            List<Usuarios> res = new List<Usuarios>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Usuarios.Where(u => u.IdRol == IdRol).ToList();
            }
            return res;
        }
    }

}
