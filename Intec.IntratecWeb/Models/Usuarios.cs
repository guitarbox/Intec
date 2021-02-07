﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intec.IntratecWeb.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string IdCiudadDomicilio { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public int IdPaisOrigen { get; set; }
        //public string Password { get; set; }
        //public Nullable<System.DateTime> FechaUltimoInicioSesion { get; set; }
        //public System.DateTime FechaCreacion { get; set; }
        //public Nullable<int> IdUsuarioCreacion { get; set; }
        //public Nullable<System.DateTime> FechaModificacion { get; set; }
        //public Nullable<int> IdUsuarioModificacion { get; set; }
        public int IdRol { get; set; }
        public bool Activo { get; set; }
        public string Foto { get; set; }
        public Roles Roles { get; set; }
        public TiposIdentificacion TiposIdentificacion { get; set; }
    }
}