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
    
    public partial class Propiedades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Propiedades()
        {
            this.Visitas = new HashSet<Visitas>();
        }
    
        public int IdPropiedades { get; set; }
        public int IdCliente { get; set; }
        public string Direccion { get; set; }
        public int IdUso { get; set; }
        public string Telefono { get; set; }
        public string Foto { get; set; }
        public string Observaciones { get; set; }
        public int IdTipoPropiedad { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
    
        public virtual TiposPropiedades TiposPropiedades { get; set; }
        public virtual UsosPropiedades UsosPropiedades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitas> Visitas { get; set; }
        public virtual Clientes Clientes { get; set; }
    }
}
