using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class Propiedades
    {
        public int IdPropiedades { get; set; }
        public int IdCliente { get; set; }
        public string Direccion { get; set; }
        public int IdUso { get; set; }
        public string Telefono { get; set; }
        public string Foto { get; set; }
        public string Observaciones { get; set; }
        public int IdTipoPropiedad { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
    }
}
