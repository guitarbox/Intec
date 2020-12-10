﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_A66D31_intratecPrbEntities1 : DbContext
    {
        public DB_A66D31_intratecPrbEntities1()
            : base("name=DB_A66D31_intratecPrbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SolicitudContactenos> SolicitudContactenos { get; set; }
        public virtual DbSet<SolicitudesProgramacionVisitas> SolicitudesProgramacionVisitas { get; set; }
        public virtual DbSet<TiposIdentificacion> TiposIdentificacion { get; set; }
        public virtual DbSet<TiposPersona> TiposPersona { get; set; }
        public virtual DbSet<TiposPropiedades> TiposPropiedades { get; set; }
        public virtual DbSet<UsosPropiedades> UsosPropiedades { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Propiedades> Propiedades { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
    
        public virtual ObjectResult<uspConsultaGralCliente_Result> uspConsultaGralCliente(string numeroIdentificacion, string nombres, string direccion, string nroTelefonico, Nullable<bool> tieneVisitaProgramada)
        {
            var numeroIdentificacionParameter = numeroIdentificacion != null ?
                new ObjectParameter("NumeroIdentificacion", numeroIdentificacion) :
                new ObjectParameter("NumeroIdentificacion", typeof(string));
    
            var nombresParameter = nombres != null ?
                new ObjectParameter("Nombres", nombres) :
                new ObjectParameter("Nombres", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var nroTelefonicoParameter = nroTelefonico != null ?
                new ObjectParameter("NroTelefonico", nroTelefonico) :
                new ObjectParameter("NroTelefonico", typeof(string));
    
            var tieneVisitaProgramadaParameter = tieneVisitaProgramada.HasValue ?
                new ObjectParameter("TieneVisitaProgramada", tieneVisitaProgramada) :
                new ObjectParameter("TieneVisitaProgramada", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspConsultaGralCliente_Result>("uspConsultaGralCliente", numeroIdentificacionParameter, nombresParameter, direccionParameter, nroTelefonicoParameter, tieneVisitaProgramadaParameter);
        }
    }
}
