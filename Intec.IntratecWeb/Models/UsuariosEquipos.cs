using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intec.IntratecWeb.Models
{
    public class UsuariosEquipos
    {
        public int IdInspector { get; set; }
        public int IdEquipo { get; set; }
        public string Estado { get; set; }
        public int IdUsuarioAsigna { get; set; }
        public System.DateTime FechaAsignacion { get; set; }
        public Equipos Equipos { get; set; }
        //public Usuarios Usuarios { get; set; }
    }
}