using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class uspConsultarVisitas_Result
    {
        public int IdVisita { get; set; }
        public Nullable<int> IdSolicitudProgramacion { get; set; }
        public int IdCliente { get; set; }
        public int IdPropiedad { get; set; }
        public string Direccion { get; set; }
        public int IdZona { get; set; }
        public string IdCiudad { get; set; }
        public System.DateTime FechaVisita { get; set; }
        public Nullable<int> IdInspector { get; set; }
        public string ObservacionesVisita { get; set; }
        public string IdEstadoVisitas { get; set; }
        public string OrigenVisita { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<int> IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
    }
}
