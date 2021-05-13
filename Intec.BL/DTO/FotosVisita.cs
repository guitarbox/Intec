using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class FotosVisita
    {
        public int IdVisita { get; set; }
        public int Secuencia { get; set; }
        public string Path { get; set; }
        public string WebPath { get; set; }
        public Nullable<int> IdTipoFoto { get; set; }
        public TiposFoto TiposFoto { get; set; }
    }
}
