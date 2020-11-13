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
        public List<Usuarios> ObtenerUsuario(string Usuario, string Pass)
        {
            List<Usuarios> res = new List<Usuarios>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Usuarios.Where(c => c.User.Equals(Usuario) && c.Password.Equals(Pass)).ToList();
            }
            return res;
        }

        public void CrearUsuario(Usuarios UsuarioCrear)
        {            
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                int us = ctx.Usuarios.Where(u => u.NumeroIdentificacion.Equals(UsuarioCrear.NumeroIdentificacion)).ToList().Count;
                if(us == 0)
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
    }

}
