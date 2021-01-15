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
    
    public partial class Visitas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visitas()
        {
            this.EquiposVisita = new HashSet<EquiposVisita>();
            this.FormatosVisita = new HashSet<FormatosVisita>();
            this.FotosVisita = new HashSet<FotosVisita>();
        }
    
        public int IdVisita { get; set; }
        public Nullable<int> IdSolicitudProgramacion { get; set; }
        public int IdCliente { get; set; }
        public string Direccion { get; set; }
        public int IdZona { get; set; }
        public string IdCiudad { get; set; }
        public System.DateTime FechaVisita { get; set; }
        public Nullable<int> IdInspector { get; set; }
        public string ObservacionesVisita { get; set; }
        public string IdEstadoVisitas { get; set; }
        public int IdPropiedad { get; set; }
        public string OrigenVisita { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<int> IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
    
        public virtual Ciudades Ciudades { get; set; }
        public virtual Clientes Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquiposVisita> EquiposVisita { get; set; }
        public virtual EstadosVisita EstadosVisita { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormatosVisita> FormatosVisita { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FotosVisita> FotosVisita { get; set; }
        public virtual SolicitudesProgramacionVisitas SolicitudesProgramacionVisitas { get; set; }
        public virtual Propiedades Propiedades { get; set; }
        public virtual Zonas Zonas { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
