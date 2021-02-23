using Intec.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
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
        public string Password { get; set; }
        public Nullable<System.DateTime> FechaUltimoInicioSesion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<int> IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public int IdRol { get; set; }
        public bool Activo { get; set; }
        public string Foto { get; set; }
        public string Email { get; set; }
        public bool DebeCambiarContrasena { get; set; }
        public string tokenCambioContrasena { get; set; }
        public DateTime? horaTokenCambioContrasena { get; set; }
        public string tokenSesion { get; set; }
        public DateTime? horaTokenSesion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string FechaNacimientoString { get; set; }

        public DTO.Roles Roles { get; set; }
        public DTO.TiposIdentificacion TiposIdentificacion { get; set; }
    }
}
