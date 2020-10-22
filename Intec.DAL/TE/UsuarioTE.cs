using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class UsuarioTE
    {
        public List<LogIn> ObtenerUsuario(string Usuario, string Pass)
        {
            List<LogIn> res = new List<LogIn>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.LogIn.Where(c => c.User.Equals(Usuario) && c.Password.Equals(Pass)).ToList();
            }
            return res;
        }
    }
}
