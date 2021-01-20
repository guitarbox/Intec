using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class Menus
    {
        public int IdMenu { get; set; }
        public Nullable<int> IdMenuPadre { get; set; }
        public string Descripcion { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public string Icono { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<int> IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
    }
}
