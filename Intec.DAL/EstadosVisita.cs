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
    
    public partial class EstadosVisita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstadosVisita()
        {
            this.Visitas = new HashSet<Visitas>();
        }
    
        public string IdEstadoVisita { get; set; }
        public string EstadoVisita { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitas> Visitas { get; set; }
    }
}
