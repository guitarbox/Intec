using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class TramiteConsecutivoFormato
    {
        public int IdFormato { get; set; }
        public Nullable<int> IdInspector { get; set; }
        public int Consecutivo { get; set; }
        public int Secuencia { get; set; }
        public string Tramite { get; set; }
        public string Observaciones { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
