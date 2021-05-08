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
        public string FechaVisitaString { get; set; }
        public Nullable<int> IdInspector { get; set; }
        public string ObservacionesVisita { get; set; }
        public string IdEstadoVisitas { get; set; }
        public int IdPropiedad { get; set; }
        public string OrigenVisita { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<int> IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public Nullable<int> IdTipoVisita { get; set; }
        public Nullable<int> IdFranja { get; set; }

        public Ciudades Ciudades { get; set; }
        //public virtual Clientes Clientes { get; set; }
        public List<EquiposVisita> EquiposVisita { get; set; }
        public EstadosVisita EstadosVisita { get; set; }
        public List<FormatosVisita> FormatosVisita { get; set; }
        public List<FotosVisita> FotosVisita { get; set; }
        public SolicitudesProgramacionVisitas SolicitudesProgramacionVisitas { get; set; }
        public Propiedades Propiedades { get; set; }
        public Zonas Zonas { get; set; }
        public Usuarios Usuarios { get; set; }
        public TiposVisita TiposVisita { get; set; }
        public Clientes Clientes { get; set; }
        public string ObservacionesInspector { get; set; }
        public string ObservacionesCancelacion { get; set; }
    }
}
