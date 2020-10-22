using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class UsuarioBE : _beDefault
    {
        public List<DTO.IngresoUsuario> ObtenerUsuario(string User, string Pass)

        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.IngresoUsuario>>(new DAL.TE.UsuarioTE().ObtenerUsuario(User, Pass));
        }
    }
}