using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class SolicitudContactenosBE : _beDefault
    {
        public void IngresarSolicitudContactenos(DTO.SolicitudContactenos Solicitud)
        {
            Start();
            new DAL.TE.SolicitudContactenosTE().IngresarSolicitudContactenos(MapperConfig.Config.MapperContactenos.Map<DAL.SolicitudContactenos>( Solicitud));
            Finish();
        }
    }
}
