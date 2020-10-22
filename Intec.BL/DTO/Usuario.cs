using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class IngresoUsuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    }
}
