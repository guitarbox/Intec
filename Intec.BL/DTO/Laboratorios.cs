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
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> IdUsuarioCreacion { get; set; }
    }
}
