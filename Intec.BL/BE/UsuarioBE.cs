using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class UsuarioBE : _beDefault
    {
        public List<DTO.Usuarios> ObtenerUsuario(string User, string Pass)
        {
            return MapperConfig.Config.MapperUsuario.Map<List<DTO.Usuarios>>(new DAL.TE.UsuariosTE().ObtenerUsuario(User, Pass));
        }

        public void IngresarUsuario(DTO.Usuarios UsuarioCrear)
        {
            Start();
            new DAL.TE.UsuariosTE().CrearUsuario(MapperConfig.Config.MapperUsuario.Map<DAL.Usuarios>(UsuarioCrear));
            Finish();
        }
    }
}