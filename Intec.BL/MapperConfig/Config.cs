﻿using System;
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

                    cfg.CreateMap<DAL.Roles, DTO.Roles>()
                    .ForMember(dest => dest.Menus,opt => opt.Ignore());

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

                    cfg.CreateMap<DAL.Equipos, DTO.Equipos>()
                    .ForMember(dest => dest.FechaProximaCalibracionString, opt => opt.MapFrom(src => src.FechaProximaCalibracion == null ? "" : src.FechaProximaCalibracion.Value.ToShortDateString()))
                    .ForMember(dest => dest.FechaProximoMantenimientoString, opt => opt.MapFrom(src => src.FechaProximoMantenimiento == null ? "" : src.FechaProximoMantenimiento.Value.ToShortDateString()))
                    .ForMember(dest => dest.FechaUltimaCalibracionString, opt => opt.MapFrom(src => src.FechaUltimaCalibracion == null ? "" : src.FechaUltimaCalibracion.Value.ToShortDateString()))
                    .ForMember(dest => dest.FechaUltimaVerificacionLaboratorioString, opt => opt.MapFrom(src => src.FechaUltimaVerificacionLaboratorio == null ? "" : src.FechaUltimaVerificacionLaboratorio.Value.ToShortDateString()))
                    ;
                    cfg.CreateMap<DAL.CalibracionesEquipos, DTO.CalibracionesEquipos>();
                    cfg.CreateMap<DAL.VerificacionesLabEquipos, DTO.VerificacionesLabEquipos>();
                    cfg.CreateMap<DAL.MarcasEquipos, DTO.MarcasEquipos>();
                    cfg.CreateMap<DAL.TiposEquipo, DTO.TiposEquipo>();
                    cfg.CreateMap<DAL.TramitesEquipo, DTO.TramitesEquipo>();
                    cfg.CreateMap<DAL.UsuariosEquipos, DTO.UsuariosEquipos>()
                        .ForMember(dest => dest.Usuarios, opt => opt.Ignore())
                        .ForMember(dest => dest.Equipos, opt => opt.Ignore())
                    ;

                    cfg.CreateMap<DTO.VerificacionesLabEquipos, DAL.VerificacionesLabEquipos>();
                    cfg.CreateMap<DTO.Equipos, DAL.Equipos>()
                        .ForMember(dest=> dest.CalibracionesEquipos, opt => opt.Ignore())
                        .ForMember(dest => dest.MarcasEquipos, opt => opt.Ignore())
                        .ForMember(dest => dest.TiposEquipo, opt => opt.Ignore())
                        .ForMember(dest => dest.TramitesEquipo, opt => opt.Ignore())
                        .ForMember(dest => dest.VerificacionesLabEquipos, opt => opt.Ignore())
                        .ForMember(dest => dest.UsuariosEquipos, opt => opt.Ignore())
                        .ForMember(dest => dest.EquiposVisita, opt => opt.Ignore())
                    ;
                    cfg.CreateMap<DTO.CalibracionesEquipos, DAL.CalibracionesEquipos>();
                    cfg.CreateMap<DTO.MarcasEquipos, DAL.MarcasEquipos>();
                    cfg.CreateMap<DTO.TiposEquipo, DAL.TiposEquipo>();
                    cfg.CreateMap<DTO.TramitesEquipo, DAL.TramitesEquipo>();

                });

                return config.CreateMapper();
            }
        }
        
        public static AutoMapper.IMapper MapperEquiposSimple
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {

                    cfg.CreateMap<DAL.Equipos, DTO.Equipos>()
                        .ForMember(dest => dest.CalibracionesEquipos, opt => opt.Ignore())
                        .ForMember(dest => dest.VerificacionesLabEquipos, opt => opt.Ignore())                        
                        .ForMember(dest => dest.TramitesEquipo, opt => opt.Ignore())
                        .ForMember(dest => dest.UsuariosEquipos, opt => opt.Ignore())
                    ;

                    cfg.CreateMap<DAL.MarcasEquipos, DTO.MarcasEquipos>();
                    cfg.CreateMap<DAL.TiposEquipo, DTO.TiposEquipo>();

                });

                return config.CreateMapper();
            }
        }
        
        public static AutoMapper.IMapper MapperUsuariosEquipos
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {

                    cfg.CreateMap<DAL.UsuariosEquipos, DTO.UsuariosEquipos>();
                    cfg.CreateMap<DAL.Usuarios, DTO.Usuarios>()
                    .ForMember(dest => dest.Roles, opt => opt.Ignore())
                    .ForMember(dest => dest.TiposIdentificacion, opt => opt.Ignore())
                    ;
                    cfg.CreateMap<DAL.Equipos, DTO.Equipos>()
                    .ForMember(dest => dest.CalibracionesEquipos, opt => opt.Ignore())
                    .ForMember(dest => dest.MarcasEquipos, opt => opt.Ignore())
                    .ForMember(dest => dest.TiposEquipo, opt => opt.Ignore())
                    .ForMember(dest => dest.TramitesEquipo, opt => opt.Ignore())
                    .ForMember(dest => dest.VerificacionesLabEquipos, opt => opt.Ignore())
                    .ForMember(dest => dest.UsuariosEquipos, opt => opt.Ignore())
                    ;

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

                    cfg.CreateMap<DAL.Clientes, DTO.Clientes>();
                    cfg.CreateMap<DAL.Propiedades, DTO.Propiedades>();
                    cfg.CreateMap<DAL.Visitas, DTO.Visitas>()
                        .ForMember(dest => dest.Ciudades, opt => opt.Ignore())
                        .ForMember(dest => dest.EquiposVisita, opt => opt.Ignore())
                        .ForMember(dest => dest.EstadosVisita, opt => opt.Ignore())
                        .ForMember(dest => dest.FormatosVisita, opt => opt.Ignore())
                        .ForMember(dest => dest.FotosVisita, opt => opt.Ignore())
                        .ForMember(dest => dest.SolicitudesProgramacionVisitas, opt => opt.Ignore())
                        .ForMember(dest => dest.Propiedades, opt => opt.Ignore())                        
                    ;

                    cfg.CreateMap<DAL.TiposIdentificacion, DTO.TiposIdentificacion>();
                    cfg.CreateMap<DAL.TiposPersona, DTO.TiposPersona>();
                    cfg.CreateMap<DAL.TiposPropiedades, DTO.TiposPropiedades>();
                    cfg.CreateMap<DAL.UsosPropiedades, DTO.UsosPropiedades>();
                    cfg.CreateMap<DAL.Zonas, DTO.Zonas>();
                    cfg.CreateMap<DAL.Usuarios, DTO.Usuarios>()
                    .ForMember(dest => dest.TiposIdentificacion ,opt => opt.Ignore())
                    .ForMember(dest => dest.Roles,opt => opt.Ignore())
                    ;

                    cfg.CreateMap<DTO.Clientes, DAL.Clientes>()
                    .ForMember(dest => dest.Propiedades, opt => opt.Ignore())
                    .ForMember(dest => dest.Visitas, opt => opt.Ignore())
                    .ForMember(dest => dest.TiposIdentificacion, opt => opt.Ignore())
                    .ForMember(dest => dest.TiposPersona, opt => opt.Ignore())
                    ;
                    cfg.CreateMap<DTO.Propiedades, DAL.Propiedades>();
                    cfg.CreateMap<DTO.Visitas, DAL.Visitas>();                    
                    
                    


                    cfg.CreateMap<DAL.uspConsultaGralCliente_Result, DTO.uspConsultaGralCliente_Result>();

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
                    cfg.CreateMap<DAL.Usuarios, DTO.Usuarios>()
                    .ForMember(dest => dest.tokenSesion, opt => opt.MapFrom(src => Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(src.tokenSesion))));
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

        public static AutoMapper.IMapper MapperUsuariosSimple
        {
            get
            {
                var config = new AutoMapper.MapperConfiguration(cfg => {
                    cfg.CreateMap<DAL.Usuarios, DTO.Usuarios>()
                    .ForMember(dest => dest.Roles, opt => opt.Ignore())
                    .ForMember(dest => dest.TiposIdentificacion, opt => opt.Ignore())
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
