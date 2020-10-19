using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class SolicitudContactenosTE
    {
        public void IngresarSolicitudContactenos(SolicitudContactenos Solicitud)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Solicitud.FechaCreacion = DateTime.Now;
                ctx.SolicitudContactenos.Add(Solicitud);
                ctx.SaveChanges();
            }
        }
    }
}
