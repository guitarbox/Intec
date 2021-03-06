﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class TiposIdentificacion
    {
        public int IdTipoIdentificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Abreviatura { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public Nullable<int> CodigoTipoIdFiscal { get; set; }
        public bool Activo { get; set; }
    }
}
