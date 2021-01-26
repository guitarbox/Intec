using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.DTO
{
    public class uspConsultaGralCliente_Result
    {
        public int IdCliente { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Abreviatura { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCel1 { get; set; }
        public string TelefonoCel2 { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Uso { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string TipoPersona { get; set; }
    }
}
