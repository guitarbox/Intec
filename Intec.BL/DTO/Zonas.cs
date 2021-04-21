using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class Zonas
    {
        public int IdZona { get; set; }
        public string IdCiudad { get; set; }
        public string Descripcion { get; set; }
        public string pc_ia { get; set; }
        public string pc_da { get; set; }
        public string pc_iab { get; set; }
        public string pc_dab { get; set; }
        public Nullable<int> IdInspector { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public Usuarios Usuarios { get; set; }
        public Ciudades Ciudades { get; set; }
    }
}
