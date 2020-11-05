using System;
using System.Collections.Generic;
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

        public List<Usuarios> CrearUsuario()
        {
            List<Usuarios> ans = new List<Usuarios>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                
                res2 = ctx.Usuarios.Where(c => c.NameReg.Equals(Usuario) && c.Password.Equals(Pass)).ToList();
                ctx.Usuarios.Add(res2);
                ctx.SaveChanges();
            }
            return ans;

        }
    }

}
