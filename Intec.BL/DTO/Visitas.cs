using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class Visitas
    {
        public int IdVisita { get; set; }
        public Nullable<int> IdSolicitudProgramacion { get; set; }
        public int IdCliente { get; set; }
        public string Direccion { get; set; }
        public int IdZona { get; set; }
        public string IdCiudad { get; set; }
        public System.DateTime FechaVisita { get; set; }
        public Nullable<int> IdInspector { get; set; }
        public string ObservacionesVisita { get; set; }
        public string IdEstadoVisitas { get; set; }
        public int IdPropiedad { get; set; }
        public string OrigenVisita { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<int> IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }

        public virtual Ciudades Ciudades { get; set; }
        public virtual Clientes Clientes { get; set; }
        public virtual ICollection<EquiposVisita> EquiposVisita { get; set; }
        public virtual EstadosVisita EstadosVisita { get; set; }
        public virtual ICollection<FormatosVisita> FormatosVisita { get; set; }
        public virtual ICollection<FotosVisita> FotosVisita { get; set; }
        public virtual SolicitudesProgramacionVisitas SolicitudesProgramacionVisitas { get; set; }
        public virtual Propiedades Propiedades { get; set; }
        public virtual Zonas Zonas { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
