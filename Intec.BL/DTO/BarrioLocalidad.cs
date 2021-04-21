using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public partial class BarrioLocalidad
    {
        public int IdBarrioLocalidad { get; set; }
        public string BarrioLocalidad1 { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public string IdCiudad { get; set; }
        public int IdZona { get; set; }
    }
}
