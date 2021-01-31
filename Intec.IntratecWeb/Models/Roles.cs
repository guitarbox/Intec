using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intec.IntratecWeb.Models
{
    public class Roles
    {
        public int IdRol { get; set; }
        public string Rol { get; set; }
        //public System.DateTime FechaCreacion { get; set; }
        //public Nullable<int> IdUsuarioCreacion { get; set; }
        //public Nullable<System.DateTime> FechaModificacion { get; set; }
        //public Nullable<int> IdUsuarioModificacion { get; set; }
        public List<Menus> Menus { get; set; }
    }
}