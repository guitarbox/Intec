using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class Equipos
    {
        public int IdEquipo { get; set; }
        public string Area { get; set; }
        public string SerieIDInterno { get; set; }
        public int IdTipoEquipo { get; set; }
        public int IdMarcaEquipo { get; set; }
        public string Modelo { get; set; }
        public string RangoMedicion { get; set; }
        public string Tolerancia { get; set; }
        public bool Calibrado { get; set; }
        public Nullable<System.DateTime> FechaUltimaCalibracion { get; set; }
        public string FechaUltimaCalibracionString { get; set; }
        public Nullable<System.DateTime> FechaProximaCalibracion { get; set; }
        public string FechaProximaCalibracionString { get; set; }
        public Nullable<System.DateTime> FechaUltimaVerificacionLaboratorio { get; set; }
        public string FechaUltimaVerificacionLaboratorioString { get; set; }
        public string PeriodoCalibracion { get; set; }
        public string PeriodoVerificacion { get; set; }
        public Nullable<System.DateTime> FechaProximoMantenimiento { get; set; }
        public string FechaProximoMantenimientoString { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public List<CalibracionesEquipos> CalibracionesEquipos { get; set; }
        public MarcasEquipos MarcasEquipos { get; set; }
        public TiposEquipo TiposEquipo { get; set; }
        public List<TramitesEquipo> TramitesEquipo { get; set; }
        public List<VerificacionesLabEquipos> VerificacionesLabEquipos { get; set; }
    }
}
