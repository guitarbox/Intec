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
    
    public partial class SolicitudesProgramacionVisitas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SolicitudesProgramacionVisitas()
        {
            this.Visitas = new HashSet<Visitas>();
        }
    
        public int IdSolicitudProgramacion { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string IdCiudad { get; set; }
        public string Uso { get; set; }
        public string NombreContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string ip { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitas> Visitas { get; set; }
        public virtual Ciudades Ciudades { get; set; }
    }
}
