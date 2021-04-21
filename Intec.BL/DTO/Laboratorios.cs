using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class Laboratorios
    {
        public int IdLaboratorio { get; set; }
        public string Laboratorio { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public string Nit { get; set; }
        public int DV { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
