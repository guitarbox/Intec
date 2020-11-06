using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class AdministracionBE : _beDefault
    {
        public List<DTO.Paises> ObtenerPaises()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.Paises>>(new DAL.TE.AdministracionTE().ObtenerPaises());
        }

        public List<DTO.Departamentos> ObtenerDepartamentos(int IdPais)
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.Departamentos>>(new DAL.TE.AdministracionTE().ObtenerDepartamentos(IdPais));
        }

        public List<DTO.Ciudades> ObtenerCiudades(string IdDepartamento)
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.Ciudades>>(new DAL.TE.AdministracionTE().ObtenerCiudades(IdDepartamento));
        }

        public List<DTO.TipoIdentificacion> ObtenerTiposIdentificacion()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.TipoIdentificacion>>(new DAL.TE.AdministracionTE().ObtenerTiposIdentificacion());
        }

    }
}
