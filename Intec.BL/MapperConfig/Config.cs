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
                    cfg.CreateMap<DAL.TiposIdentificacion, DTO.TipoIdentificacion>()
                    .ForMember(dest => dest.TipoIdentificacionDescripcion, opt => opt.MapFrom(s => s.TipoIdentificacion));
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

        public static AutoMapper.IMapper MapperUsuario
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {                    
                    cfg.CreateMap<DAL.Usuarios, DTO.Usuarios>();
                    cfg.CreateMap<DAL.TiposIdentificacion, DTO.TipoIdentificacion>()
                    .ForMember(dest => dest.TipoIdentificacionDescripcion, opt => opt.MapFrom(s=>s.TipoIdentificacion));

                    //DAL
                    cfg.CreateMap<DTO.Usuarios, DAL.Usuarios>()
                    .ForMember(dest => dest.TiposIdentificacion, opt => opt.Ignore());                    
                });

                return config.CreateMapper();
            }

        }

    }
}
