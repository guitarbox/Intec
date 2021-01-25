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
                    cfg.CreateMap<DAL.TiposIdentificacion, DTO.TiposIdentificacion>();
                    //
                    cfg.CreateMap<DTO.Paises, DAL.Paises>();
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

        public static AutoMapper.IMapper MapperUsuarios
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {
                    cfg.CreateMap<DAL.Usuarios, DTO.Usuarios>();
                    cfg.CreateMap<DAL.Roles, DTO.Roles>();
                    cfg.CreateMap<DAL.Menus, DTO.Menus>();
                    cfg.CreateMap<DAL.TiposIdentificacion, DTO.TiposIdentificacion>();

                    //DAL
                    cfg.CreateMap<DTO.Usuarios, DAL.Usuarios>()
                        .ForMember(dest => dest.Ciudades, opt => opt.Ignore())
                        .ForMember(dest => dest.ConsecutivosFormatos, opt => opt.Ignore())
                        .ForMember(dest => dest.KardexPapeleria, opt => opt.Ignore())
                        .ForMember(dest => dest.Roles, opt => opt.Ignore())
                        .ForMember(dest => dest.TiposIdentificacion, opt => opt.Ignore())
                        .ForMember(dest => dest.TramiteConsecutivoFormato, opt => opt.Ignore())
                        .ForMember(dest => dest.TramitesEquipo, opt => opt.Ignore())
                        .ForMember(dest => dest.UsuariosEquipos, opt => opt.Ignore())
                        .ForMember(dest => dest.Visitas, opt => opt.Ignore())
                        .ForMember(dest => dest.Zonas, opt => opt.Ignore())
                    ;
                });

                return config.CreateMapper();
            }
        }
        
        public static AutoMapper.IMapper MapperParametros
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {
                    cfg.CreateMap<DAL.Parametros, DTO.Parametros>();
                });

                return config.CreateMapper();
            }
        }

    }
}
