using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class ClientesTE
    {
        public List<uspConsultaGralCliente_Result> ConsultaGralClientes(string NumeroIdentificacion, string Nombres, string Direccion, string NroTelefonico, bool TieneVisitaProgramada)
        {
            List<uspConsultaGralCliente_Result> res = new List<uspConsultaGralCliente_Result>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.uspConsultaGralCliente(NumeroIdentificacion, Nombres, Direccion, NroTelefonico, TieneVisitaProgramada).ToList();
            }
            return res;
        }
    }
}
