using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class UsuarioBE : _beDefault
    {
        public List<DTO.Usuario> ObtenerUsuario(string User, string Pass)
        {
            return MapperConfig.Config.MapperUsuario.Map<List<DTO.Usuario>>(new DAL.TE.UsuariosTE().ObtenerUsuario(User, Pass));
        }

        public void CrearUsuario(DTO.Usuario UsuarioCrear)
        {
            new DAL.TE.UsuariosTE().CrearUsuario(MapperConfig.Config.MapperUsuario.Map<DAL.Usuarios>(UsuarioCrear));
        }
    }
}