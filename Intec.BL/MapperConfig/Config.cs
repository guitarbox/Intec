using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.MapperConfig
{
    public class Config
    {
        #region Administracion
        public static AutoMapper.IMapper MapperAdministracion
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {
                    
                    cfg.CreateMap<DTO.Paises, DAL.Paises>();
                    cfg.CreateMap<DAL.Paises, DTO.Paises>();
                    
                    cfg.CreateMap<DTO.Departamentos, DAL.Departamentos>();
                    cfg.CreateMap<DAL.Departamentos, DTO.Departamentos>();
                    
                    cfg.CreateMap<DTO.Ciudades, DAL.Ciudades>();
                    cfg.CreateMap<DAL.Ciudades, DTO.Ciudades>();
                    
                    cfg.CreateMap<DTO.TiposIdentificacion, DAL.TiposIdentificacion>();
                    cfg.CreateMap<DAL.TiposIdentificacion, DTO.TiposIdentificacion>();

                    cfg.CreateMap<DTO.MarcasEquipos, DAL.MarcasEquipos>();
                    cfg.CreateMap<DAL.MarcasEquipos, DTO.MarcasEquipos>();

                    cfg.CreateMap<DTO.TiposEquipo, DAL.TiposEquipo>();
                    cfg.CreateMap<DAL.TiposEquipo, DTO.TiposEquipo>();

                    cfg.CreateMap<DTO.TiposPersona, DAL.TiposPersona>();
                    cfg.CreateMap<DAL.TiposPersona, DTO.TiposPersona>();

                    cfg.CreateMap<DTO.TiposPropiedades, DAL.TiposPropiedades>();
                    cfg.CreateMap<DAL.TiposPropiedades, DTO.TiposPropiedades>();

                    cfg.CreateMap<DTO.UsosPropiedades, DAL.UsosPropiedades>();
                    cfg.CreateMap<DAL.UsosPropiedades, DTO.UsosPropiedades>();

                });

                return config.CreateMapper();
            }
        }

        #endregion

        #region Equipos

        public static AutoMapper.IMapper MapperEquipos
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {

                    cfg.CreateMap<DTO.Equipos, DAL.Equipos>();
                    cfg.CreateMap<DAL.Equipos, DTO.Equipos>();

                    cfg.CreateMap<DTO.VerificacionesLabEquipos, DAL.VerificacionesLabEquipos>();
                    cfg.CreateMap<DTO.CalibracionesEquipos, DAL.CalibracionesEquipos>();

                });

                return config.CreateMapper();
            }
        }

        #endregion

        #region Papeleria

        public static AutoMapper.IMapper MapperPapeleria
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {

                    cfg.CreateMap<DTO.Formatos, DAL.Formatos>();
                    cfg.CreateMap<DAL.Formatos, DTO.Formatos>();

                });

                return config.CreateMapper();
            }
        }

        #endregion

        #region Clientes

        public static AutoMapper.IMapper MapperClientes
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {

                    cfg.CreateMap<DTO.Clientes, DAL.Clientes>();
                    cfg.CreateMap<DAL.Clientes, DTO.Clientes>();

                    cfg.CreateMap<DTO.Propiedades, DAL.Propiedades>();
                    cfg.CreateMap<DAL.Propiedades, DTO.Propiedades>();
                });

                return config.CreateMapper();
            }
        }

        #endregion

        #region Visitas
        public static AutoMapper.IMapper MapperVisitas
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {

                    cfg.CreateMap<DTO.Zonas, DAL.Zonas>();
                    cfg.CreateMap<DAL.Zonas, DTO.Zonas>();

                    cfg.CreateMap<DTO.Visitas, DAL.Visitas>();
                    cfg.CreateMap<DAL.Visitas, DTO.Visitas>();

                    cfg.CreateMap<DTO.FotosVisita, DAL.FotosVisita>();
                    cfg.CreateMap<DTO.FormatosVisita, DAL.FormatosVisita>();
                    cfg.CreateMap<DTO.EquiposVisita, DAL.EquiposVisita>();

                    cfg.CreateMap<DAL.uspConsultarVisitas_Result, DTO.uspConsultarVisitas_Result>();

                    cfg.CreateMap<DAL.SolicitudesProgramacionVisitas, DTO.SolicitudesProgramacionVisitas>();
                    //DAL
                    cfg.CreateMap<DTO.SolicitudesProgramacionVisitas, DAL.SolicitudesProgramacionVisitas>();
                });

                return config.CreateMapper();
            }
        }

        #endregion

        //No son parte de la tarea

        #region Contactenos

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

        #endregion

        #region Usuarios

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

        #endregion

        #region Parametros

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

        #endregion






    }
}
