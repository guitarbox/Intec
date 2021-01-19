using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class ConsecutivosFormatos
    {
        public int IdFormato { get; set; }
        public int Consecutivo { get; set; }
        public Nullable<int> IdInspector { get; set; }
        public string IdEstadoConsecutivoInspector { get; set; }
        public string IdVisita { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }

    }
}
