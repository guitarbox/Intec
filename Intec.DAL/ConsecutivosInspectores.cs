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
    
    public partial class ConsecutivosInspectores
    {
        public int IdFormato { get; set; }
        public int IdInspector { get; set; }
        public int Consecutivo { get; set; }
        public string IdEstadoConsecutivoInspector { get; set; }
        public string IdVisita { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
    
        public virtual Formatos Formatos { get; set; }
        public virtual EstadosConsecutivosInspector EstadosConsecutivosInspector { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}