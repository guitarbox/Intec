using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.MapperConfig
{
    public class Config
    {
        public static AutoMapper.IMapper MapperAdministracion
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {
                    cfg.CreateMap<DAL.Paises, DTO.Paises>();
                    cfg.CreateMap<DAL.Departamentos, DTO.Departamentos>();
                    cfg.CreateMap<DAL.Ciudades, DTO.Ciudades>();
                });

                return config.CreateMapper();
            }
        }

        public static AutoMapper.IMapper MapperVisitas
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {

                    //DAL
                    cfg.CreateMap<DTO.SolicitudesProgramacionVisitas, DAL.SolicitudesProgramacionVisitas>();
                });

                return config.CreateMapper();
            }
        }

        public static AutoMapper.IMapper MapperContactenos
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {

                    //DAL
                    cfg.CreateMap<DTO.SolicitudContactenos, DAL.SolicitudContactenos>();
                });

                return config.CreateMapper();
            }
        }

    }
}
