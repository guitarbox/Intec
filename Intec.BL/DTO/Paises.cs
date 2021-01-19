using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class Paises
    {
        public int IdPais { get; set; }
        public string Pais { get; set; }
        public string CodigoPais { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public bool Activo { get; set; }
    }
}
