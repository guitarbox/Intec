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
        public virtual DbSet<Propiedades> Propiedades { get; set; }
        public virtual DbSet<EstadosConsecutivosInspector> EstadosConsecutivosInspector { get; set; }
        public virtual DbSet<ConsecutivosFormatos> ConsecutivosFormatos { get; set; }
        public virtual DbSet<Formatos> Formatos { get; set; }
        public virtual DbSet<CalibracionesEquipos> CalibracionesEquipos { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<MarcasEquipos> MarcasEquipos { get; set; }
        public virtual DbSet<TiposEquipo> TiposEquipo { get; set; }
        public virtual DbSet<TramitesEquipo> TramitesEquipo { get; set; }
        public virtual DbSet<VerificacionesLabEquipos> VerificacionesLabEquipos { get; set; }
        public virtual DbSet<KardexPapeleria> KardexPapeleria { get; set; }
        public virtual DbSet<TiposMovimientoKardex> TiposMovimientoKardex { get; set; }
        public virtual DbSet<UsuariosEquipos> UsuariosEquipos { get; set; }
        public virtual DbSet<EquiposVisita> EquiposVisita { get; set; }
        public virtual DbSet<EstadosVisita> EstadosVisita { get; set; }
        public virtual DbSet<FormatosVisita> FormatosVisita { get; set; }
        public virtual DbSet<FotosVisita> FotosVisita { get; set; }
        public virtual DbSet<TramiteConsecutivoFormato> TramiteConsecutivoFormato { get; set; }
        public virtual DbSet<Visitas> Visitas { get; set; }
        public virtual DbSet<HistoricoAsignacionZona> HistoricoAsignacionZona { get; set; }
        public virtual DbSet<Zonas> Zonas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Parametros> Parametros { get; set; }
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Log> Log { get; set; }
    
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
    
        public virtual ObjectResult<uspConsultarVisitas_Result> uspConsultarVisitas(Nullable<System.DateTime> fechaInicial, Nullable<System.DateTime> fechaFinal, string numeroIdentificacionCliente, Nullable<int> idInspector, string idEstadoVisita)
        {
            var fechaInicialParameter = fechaInicial.HasValue ?
                new ObjectParameter("FechaInicial", fechaInicial) :
                new ObjectParameter("FechaInicial", typeof(System.DateTime));
    
            var fechaFinalParameter = fechaFinal.HasValue ?
                new ObjectParameter("FechaFinal", fechaFinal) :
                new ObjectParameter("FechaFinal", typeof(System.DateTime));
    
            var numeroIdentificacionClienteParameter = numeroIdentificacionCliente != null ?
                new ObjectParameter("NumeroIdentificacionCliente", numeroIdentificacionCliente) :
                new ObjectParameter("NumeroIdentificacionCliente", typeof(string));
    
            var idInspectorParameter = idInspector.HasValue ?
                new ObjectParameter("IdInspector", idInspector) :
                new ObjectParameter("IdInspector", typeof(int));
    
            var idEstadoVisitaParameter = idEstadoVisita != null ?
                new ObjectParameter("IdEstadoVisita", idEstadoVisita) :
                new ObjectParameter("IdEstadoVisita", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspConsultarVisitas_Result>("uspConsultarVisitas", fechaInicialParameter, fechaFinalParameter, numeroIdentificacionClienteParameter, idInspectorParameter, idEstadoVisitaParameter);
        }
    }
}
