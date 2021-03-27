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
    
    public partial class Equipos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipos()
        {
            this.CalibracionesEquipos = new HashSet<CalibracionesEquipos>();
            this.TramitesEquipo = new HashSet<TramitesEquipo>();
            this.VerificacionesLabEquipos = new HashSet<VerificacionesLabEquipos>();
            this.UsuariosEquipos = new HashSet<UsuariosEquipos>();
            this.EquiposVisita = new HashSet<EquiposVisita>();
        }
    
        public int IdEquipo { get; set; }
        public string Area { get; set; }
        public string SerieIDInterno { get; set; }
        public int IdTipoEquipo { get; set; }
        public int IdMarcaEquipo { get; set; }
        public string Modelo { get; set; }
        public string RangoMedicion { get; set; }
        public string Tolerancia { get; set; }
        public bool Calibrado { get; set; }
        public Nullable<System.DateTime> FechaUltimaCalibracion { get; set; }
        public Nullable<System.DateTime> FechaProximaCalibracion { get; set; }
        public Nullable<System.DateTime> FechaUltimaVerificacionLaboratorio { get; set; }
        public string PeriodoCalibracion { get; set; }
        public string PeriodoVerificacion { get; set; }
        public Nullable<System.DateTime> FechaProximoMantenimiento { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public bool Activo { get; set; }
        public Nullable<int> IdTipoVisitaAplica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CalibracionesEquipos> CalibracionesEquipos { get; set; }
        public virtual MarcasEquipos MarcasEquipos { get; set; }
        public virtual TiposEquipo TiposEquipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TramitesEquipo> TramitesEquipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VerificacionesLabEquipos> VerificacionesLabEquipos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosEquipos> UsuariosEquipos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquiposVisita> EquiposVisita { get; set; }
    }
}
