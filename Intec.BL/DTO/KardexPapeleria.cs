using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class KardexPapeleria
    {
        public int IdEntradaPapeleria { get; set; }
        public string IdTipoMovimiento { get; set; }
        public int IdFormato { get; set; }
        public Nullable<int> IdInspector { get; set; }
        public int ConsecutivoInicial { get; set; }
        public int ConsecutivoFinal { get; set; }
        public string Observaciones { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
