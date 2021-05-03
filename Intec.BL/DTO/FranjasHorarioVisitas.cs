using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class FranjasHorarioVisitas
    {
        public int IdFranja { get; set; }
        public string HoraInicioFranja { get; set; }
        public string HoraFinFranja { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
