//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intec.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class KardexPapeleria
    {
        public int IdEntradaPapeleria { get; set; }
        public string IdTipoMovimiento { get; set; }
        public int IdFormato { get; set; }
        public Nullable<int> IdInspector { get; set; }
        public int ConsecutivoInicial { get; set; }
        public int ConsecutivoFinal { get; set; }
        public string Observaciones { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
    
        public virtual Formatos Formatos { get; set; }
        public virtual TiposMovimientoKardex TiposMovimientoKardex { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
