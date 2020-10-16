using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class SolicitudesProgramacionVisitasBE : _beDefault
    {
        public void CrearSolicitud(DTO.SolicitudesProgramacionVisitas Solicitud)
        {
            Start();
            new DAL.TE.SolicitudesProgramacionVIsitasTE().CrearSolicitud(MapperConfig.Config.MapperVisitas.Map<DAL.SolicitudesProgramacionVisitas>(Solicitud));
            Finish();
        }
    }
}
