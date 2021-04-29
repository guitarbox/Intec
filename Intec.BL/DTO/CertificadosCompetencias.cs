using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class CertificadosCompetencias
    {
        public int IdCertificadosCompetencia { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public string UbicacionArchivo { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public string Observaciones { get; set; }
        public int IdInspector { get; set; }
        public System.DateTime FechaExpedicion { get; set; }
    }
}
