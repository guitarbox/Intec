﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intec.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
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
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<SolicitudesProgramacionVisitas> SolicitudesProgramacionVisitas { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<SolicitudContactenos> SolicitudContactenos { get; set; }
        public virtual DbSet<LogIn> LogIn { get; set; }
    }
}
