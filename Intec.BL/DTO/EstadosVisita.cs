using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class EstadosVisita
    {
        public string IdEstadoVisita { get; set; }
        public string EstadoVisita { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    }
}
