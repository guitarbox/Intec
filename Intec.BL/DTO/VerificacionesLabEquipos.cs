using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class VerificacionesLabEquipos
    {
        public int IdEquipo { get; set; }
        public int Secuencia { get; set; }
        public System.DateTime FechaVerificacion { get; set; }
        public string FechaVerificacionString { get; set; }
        public string NroCertificado { get; set; }
        public int IdLaboratorio { get; set; }
        public string Observaciones { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
    }
}
