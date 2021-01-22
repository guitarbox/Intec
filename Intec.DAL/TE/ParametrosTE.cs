using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class ParametrosTE
    {
        public List<Parametros> GetAll()
        {
            List<Parametros> res = new List<Parametros>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Parametros.ToList();
            }
            return res;
        }
    }
}
