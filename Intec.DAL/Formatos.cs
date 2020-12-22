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
    
    public partial class Formatos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Formatos()
        {
            this.ConsecutivosFormatos = new HashSet<ConsecutivosFormatos>();
            this.TramiteConsecutivoFormato = new HashSet<TramiteConsecutivoFormato>();
        }
    
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsecutivosFormatos> ConsecutivosFormatos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TramiteConsecutivoFormato> TramiteConsecutivoFormato { get; set; }
    }
}
