using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class SolicitudContactenos
    {
        public int IdSolicitudContactenos { get; set; }
        public bool PQRA { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Mensaje { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string ip { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}
