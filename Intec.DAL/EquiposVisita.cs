//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class EquiposVisita
    {
        public int IdVisita { get; set; }
        public int Secuencia { get; set; }
        public int IdEquipo { get; set; }
    
        public virtual Equipos Equipos { get; set; }
        public virtual Visitas Visitas { get; set; }
    }
}
