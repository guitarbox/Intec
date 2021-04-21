using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class Clientes
    {
        public int IdCliente { get; set; }
        public string NumeroIdentificacion { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCel1 { get; set; }
        public string TelefonoCel2 { get; set; }
        public string Direccion { get; set; }
        public string IdCiudad { get; set; }
        public int IdUso { get; set; }
        public string Foto { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public int IdTipoPersona { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public TiposIdentificacion TiposIdentificacion { get; set; }
        public TiposPersona TiposPersona { get; set; }
        public List<Propiedades> Propiedades { get; set; }
        public List<Visitas> Visitas { get; set; }
        public Nullable<int> IdZona { get; set; }
    }
}
