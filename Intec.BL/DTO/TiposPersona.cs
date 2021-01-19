using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class TiposPersona
    {
        public int IdTipoPersona { get; set; }
        public string TipoPersona { get; set; }
        public string CodigoTipoPersona { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public bool Activo { get; set; }
    }
}
