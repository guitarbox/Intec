using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class Formatos
    {
        public int IdFormato { get; set; }
        public string NroFormato { get; set; }
        public string Formato { get; set; }
        public string Separador { get; set; }
        public int Mascara { get; set; }
        public bool Activo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public List<ConsecutivosFormatos> ConsecutivosFormatos { get; set; }
        
        public List<TramiteConsecutivoFormato> TramiteConsecutivoFormato { get; set; }
    }
}
