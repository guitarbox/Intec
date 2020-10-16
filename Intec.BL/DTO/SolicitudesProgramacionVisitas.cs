using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class SolicitudesProgramacionVisitas
    {
        public int IdSolicitudProgramacion { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string IdCiudad { get; set; }
        public string Uso { get; set; }
        public string NombreContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string ip { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}
