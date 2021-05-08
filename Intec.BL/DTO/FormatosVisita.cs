using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class FormatosVisita
    {
        public int IdVisita { get; set; }
        public int Secuencia { get; set; }
        public int IdFormato { get; set; }
        public int Consecutivo { get; set; }
        public Formatos Formatos { get; set; }
    }
}
