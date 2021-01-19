using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class UsuariosEquipos
    {
        public int IdInspector { get; set; }
        public int IdEquipo { get; set; }
        public string Estado { get; set; }
        public int IdUsuarioAsigna { get; set; }
        public System.DateTime FechaAsignacion { get; set; }
    }
}
