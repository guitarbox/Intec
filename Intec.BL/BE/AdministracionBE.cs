using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class AdministracionBE : _beDefault
    {
        #region Admin
        public List<DTO.Roles> ObtenerRoles()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.Roles>>(new DAL.TE.AdministracionTE().ObtenerRoles());
        }

        public List<DTO.TiposVisita> ObtenerTiposVisita()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.TiposVisita>>(new DAL.TE.AdministracionTE().ObtenerTiposVisita());
        }
        #endregion

        #region Paises

        //Crear

        public void CrearPais(DTO.Paises PaisCrear)
        {
            try
            {
                new DAL.TE.AdministracionTE().CrearPais(MapperConfig.Config.MapperAdministracion.Map<DAL.Paises>(PaisCrear));
            }
            catch(Exception ex)
            {
                throw new Exception("Hubo un error al intentar crear el recurso. Valide que los datos ingresados sean correctos y que los identificadares no se repitan.");
            }
        }

        //Obtener

        public List<DTO.Paises> ObtenerPaises()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.Paises>>(new DAL.TE.AdministracionTE().ObtenerPaises());
        }
        
        public List<DTO.Paises> ObtenerPaisesActivos()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.Paises>>(new DAL.TE.AdministracionTE().ObtenerPaisesActivos());
        }

        public DTO.Paises ObtenerPais(int IdPais)
        {
            return MapperConfig.Config.MapperAdministracion.Map<DTO.Paises>(new DAL.TE.AdministracionTE().ObtenerPais(IdPais));
        }

        //Editar

        public void EditarPais(DTO.Paises Pais, int IdUsuariomodificacion)
        {
            if(Pais.CodigoPais.Length <= 5){
                new DAL.TE.AdministracionTE().EditarPais(MapperConfig.Config.MapperAdministracion.Map<DAL.Paises>(Pais), IdUsuariomodificacion);
            }
            else
            {
                throw new Exception("El codigo país debe contar con maximo 5 carácteres");
            }          
            
        }

        //Eliminar

        public void EliminarPais(int IdPais, int IdUsuarioModificacion)
        {
            new DAL.TE.AdministracionTE().EliminarPais(IdPais, IdUsuarioModificacion);
        }

        #endregion

        #region Departamentos

        //Crear
        public void CrearDepartamento(DTO.Departamentos DepartamentoCrear)
        {
            new DAL.TE.AdministracionTE().CrearDepartamento(MapperConfig.Config.MapperAdministracion.Map<DAL.Departamentos>(DepartamentoCrear));
        }

        //Obtener departamentos por país
        public List<DTO.Departamentos> ObtenerDepartamentos(int IdPais)
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.Departamentos>>(new DAL.TE.AdministracionTE().ObtenerDepartamentos(IdPais));
        }
        
        public List<DTO.Departamentos> ObtenerDepartamentosActivos(int IdPais)
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.Departamentos>>(new DAL.TE.AdministracionTE().ObtenerDepartamentosActivos(IdPais));
        }

        //obtener departamento por id
        public DTO.Departamentos ObtenerDepartamento(string IdDepartamento)
        {
            return MapperConfig.Config.MapperAdministracion.Map<DTO.Departamentos>(new DAL.TE.AdministracionTE().ObtenerDepartamento(IdDepartamento));
        }

        //Editar

        public void EditarDepartamento(DTO.Departamentos Departamento, int IdUsuariomodificacion)
        {
            new DAL.TE.AdministracionTE().EditarDepartamento(MapperConfig.Config.MapperAdministracion.Map<DAL.Departamentos>(Departamento), IdUsuariomodificacion);
        }

        //Eliminar

        public void EliminarDepartamento(string IdDepartamento, int IdUsuarioModificacion)
        {
            new DAL.TE.AdministracionTE().EliminarDepartamento(IdDepartamento, IdUsuarioModificacion);
        }

        #endregion

        #region Ciudades

        //Crear

        public void CrearCiudad(DTO.Ciudades CiudadCrear)
        {
            new DAL.TE.AdministracionTE().CrearCiudad(MapperConfig.Config.MapperAdministracion.Map<DAL.Ciudades>(CiudadCrear));
        }

        //Obtener

        public List<DTO.Ciudades> ObtenerCiudades(string IdDepartamento)
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.Ciudades>>(new DAL.TE.AdministracionTE().ObtenerCiudades(IdDepartamento));
        }
        
        public List<DTO.Ciudades> ObtenerCiudadesActivos(string IdDepartamento)
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.Ciudades>>(new DAL.TE.AdministracionTE().ObtenerCiudadesActivos(IdDepartamento));
        }

        public DTO.Ciudades ObtenerCiudad(string IdCiudad)
        {
            return MapperConfig.Config.MapperAdministracion.Map<DTO.Ciudades>(new DAL.TE.AdministracionTE().ObtenerCiudad(IdCiudad));
        }

        //Editar

        public void EditarCiudad(DTO.Ciudades Ciudad, int IdUsuariomodificacion)
        {
            new DAL.TE.AdministracionTE().EditarCiudad(MapperConfig.Config.MapperAdministracion.Map<DAL.Ciudades>(Ciudad), IdUsuariomodificacion);
        }

        //Eliminar

        public void EliminarCiudad(string IdCiudad, int IdUsuarioModificacion)
        {
            new DAL.TE.AdministracionTE().EliminarCiudad(IdCiudad, IdUsuarioModificacion);
        }

        #endregion

        #region TiposIdentificacion

        //Crear

        public void CrearTipoIdentificacion(DTO.TiposIdentificacion TipoIdentificacionCrear)
        {
            new DAL.TE.AdministracionTE().CrearTipoIdentificacion(MapperConfig.Config.MapperAdministracion.Map<DAL.TiposIdentificacion>(TipoIdentificacionCrear));
        }

        //Obtener

        public List<DTO.TiposIdentificacion> ObtenerTiposIdentificacion()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.TiposIdentificacion>>(new DAL.TE.AdministracionTE().ObtenerTiposIdentificacion());
        }
        
        public List<DTO.TiposIdentificacion> ObtenerTiposIdentificacionActivos()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.TiposIdentificacion>>(new DAL.TE.AdministracionTE().ObtenerTiposIdentificacionActivos());
        }

        public DTO.TiposIdentificacion ObtenerTipoIdentificacion(int IdTipoIdentificacion)
        {
            return MapperConfig.Config.MapperAdministracion.Map<DTO.TiposIdentificacion>(new DAL.TE.AdministracionTE().ObtenerTipoIdentificacion(IdTipoIdentificacion));
        }

        //Editar

        public void EditarTipoIdentificacion(DTO.TiposIdentificacion TipoIdentificacion, int IdUsuariomodificacion)
        {
            new DAL.TE.AdministracionTE().EditarTipoIdentificacion(MapperConfig.Config.MapperAdministracion.Map<DAL.TiposIdentificacion>(TipoIdentificacion), IdUsuariomodificacion);
        }

        //Eliminar

        public void EliminarTipoIdentificacion(int IdTipoIdentificacion, int IdUsuarioModificacion)
        {
            new DAL.TE.AdministracionTE().EliminarTipoIdentificacion(IdTipoIdentificacion, IdUsuarioModificacion);
        }

        #endregion

        #region MarcasEquipos

        //Crear

        public void CrearMarcaEquipo(DTO.MarcasEquipos MarcaEquipo)
        {
            new DAL.TE.AdministracionTE().CrearMarcaEquipos(MapperConfig.Config.MapperAdministracion.Map<DAL.MarcasEquipos>(MarcaEquipo));
        }

        //Obtener

        public List<DTO.MarcasEquipos> ObtenerMarcasEquipos()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.MarcasEquipos>>(new DAL.TE.AdministracionTE().ObtenerMarcasEquipos());
        }
        
        public List<DTO.MarcasEquipos> ObtenerMarcasEquiposActivos()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.MarcasEquipos>>(new DAL.TE.AdministracionTE().ObtenerMarcasEquiposActivos());
        }

        public DTO.MarcasEquipos ObtenerMarcaEquipo(int IdMarcaEquipo)
        {
            return MapperConfig.Config.MapperAdministracion.Map<DTO.MarcasEquipos>(new DAL.TE.AdministracionTE().ObtenerMarcaEquipo(IdMarcaEquipo));
        }
        //Editar

        public void EditarMarcaEquipo(DTO.MarcasEquipos MarcaEquipo, int IdUsuariomodificacion)
        {
            new DAL.TE.AdministracionTE().EditarMarcaEquipo(MapperConfig.Config.MapperAdministracion.Map<DAL.MarcasEquipos>(MarcaEquipo), IdUsuariomodificacion);
        }

        //Eliminar

        public void EliminarMarcaEquipo(int IdMarcaEquipo, int IdUsuarioModificacion)
        {
            new DAL.TE.AdministracionTE().EliminarMarcaEquipo(IdMarcaEquipo, IdUsuarioModificacion);
        }

        #endregion

        #region TiposEquipo


        //Crear

        public void CrearTipoEquipo(DTO.TiposEquipo TipoEquipo)
        {
            new DAL.TE.AdministracionTE().CrearTipoEquipo(MapperConfig.Config.MapperAdministracion.Map<DAL.TiposEquipo>(TipoEquipo));
        }

        //Obtener

        public List<DTO.TiposEquipo> ObtenerTiposEquipos()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.TiposEquipo>>(new DAL.TE.AdministracionTE().ObtenerTiposEquipo());
        }
        
        public List<DTO.TiposEquipo> ObtenerTiposEquiposActivos()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.TiposEquipo>>(new DAL.TE.AdministracionTE().ObtenerTiposEquipoActivos());
        }

        public DTO.TiposEquipo ObtenerTipoEquipo(int IdTipoEquipo)
        {
            return MapperConfig.Config.MapperAdministracion.Map<DTO.TiposEquipo>(new DAL.TE.AdministracionTE().ObtenerTipoEquipo(IdTipoEquipo));
        }
        //Editar

        public void EditarTipoEquipo(DTO.TiposEquipo TipoEquipo, int IdUsuariomodificacion)
        {
            new DAL.TE.AdministracionTE().EditarTipoEquipo(MapperConfig.Config.MapperAdministracion.Map<DAL.TiposEquipo>(TipoEquipo), IdUsuariomodificacion);
        }

        //Eliminar

        public void EliminarTipoEquipo(int IdTipoEquipo, int IdUsuarioModificacion)
        {
            new DAL.TE.AdministracionTE().EliminarTipoEquipo(IdTipoEquipo, IdUsuarioModificacion);
        }

        #endregion

        #region TiposPersona

        //Crear

        public void CrearTipoPersona(DTO.TiposPersona TipoPersona)
        {
            new DAL.TE.AdministracionTE().CrearTipoPersona(MapperConfig.Config.MapperAdministracion.Map<DAL.TiposPersona>(TipoPersona));
        }

        //Obtener

        public List<DTO.TiposPersona> ObtenerTiposPersona()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.TiposPersona>>(new DAL.TE.AdministracionTE().ObtenerTiposPersona());
        }
        
        public List<DTO.TiposPersona> ObtenerTiposPersonaActivos()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.TiposPersona>>(new DAL.TE.AdministracionTE().ObtenerTiposPersonaActivos());
        }

        public DTO.TiposPersona ObtenerTipoPersona(int IdTipoPersona)
        {
            return MapperConfig.Config.MapperAdministracion.Map<DTO.TiposPersona>(new DAL.TE.AdministracionTE().ObtenerTipoPersona(IdTipoPersona));
        }
        //Editar

        public void EditarTipoPersona(DTO.TiposPersona TipoPersona, int IdUsuariomodificacion)
        {
            new DAL.TE.AdministracionTE().EditarTipoPersona(MapperConfig.Config.MapperAdministracion.Map<DAL.TiposPersona>(TipoPersona), IdUsuariomodificacion);
        }

        //Eliminar

        public void EliminarTipoPersona(int IdTipoPersona, int IdUsuarioModificacion)
        {
            new DAL.TE.AdministracionTE().EliminarTipoPersona(IdTipoPersona, IdUsuarioModificacion);
        }

        #endregion

        #region TiposPropiedades


        //Crear

        public void CrearTipoPropiedad(DTO.TiposPropiedades TipoPropiedad)
        {
            new DAL.TE.AdministracionTE().CrearTipoPropiedad(MapperConfig.Config.MapperAdministracion.Map<DAL.TiposPropiedades>(TipoPropiedad));
        }

        //Obtener

        public List<DTO.TiposPropiedades> ObtenerTiposPropiedades()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.TiposPropiedades>>(new DAL.TE.AdministracionTE().ObtenerTiposPropiedades());
        }
        
        public List<DTO.TiposPropiedades> ObtenerTiposPropiedadesActivos()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.TiposPropiedades>>(new DAL.TE.AdministracionTE().ObtenerTiposPropiedadesActivos());
        }

        public DTO.TiposPropiedades ObtenerTipoPropiedad(int IdTipoPropiedad)
        {
            return MapperConfig.Config.MapperAdministracion.Map<DTO.TiposPropiedades>(new DAL.TE.AdministracionTE().ObtenerTipoPropiedad(IdTipoPropiedad));
        }

        //Editar

        public void EditarTipoPropiedad(DTO.TiposPropiedades TipoPropiedad, int IdUsuariomodificacion)
        {
            new DAL.TE.AdministracionTE().EditarTipoPropiedad(MapperConfig.Config.MapperAdministracion.Map<DAL.TiposPropiedades>(TipoPropiedad), IdUsuariomodificacion);
        }

        //Eliminar

        public void EliminarTipoPropiedad(int IdTipoPropiedad, int IdUsuarioModificacion)
        {
            new DAL.TE.AdministracionTE().EliminarTipoPropiedad(IdTipoPropiedad, IdUsuarioModificacion);
        }


        #endregion

        #region UsosPropiedades

        //Crear

        public void CrearUsoPropiedad(DTO.UsosPropiedades UsoPropiedad)
        {
            new DAL.TE.AdministracionTE().CrearUsoPropiedad(MapperConfig.Config.MapperAdministracion.Map<DAL.UsosPropiedades>(UsoPropiedad));
        }

        //Obtener

        public List<DTO.UsosPropiedades> ObtenerUsosPropiedades()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.UsosPropiedades>>(new DAL.TE.AdministracionTE().ObtenerUsosPropiedades());
        }
        
        public List<DTO.UsosPropiedades> ObtenerUsosPropiedadesActivos()
        {
            return MapperConfig.Config.MapperAdministracion.Map<List<DTO.UsosPropiedades>>(new DAL.TE.AdministracionTE().ObtenerUsosPropiedadesActivos());
        }

        public DTO.UsosPropiedades ObtenerUsoPropiedad(int IdUsoPropiedad)
        {
            return MapperConfig.Config.MapperAdministracion.Map<DTO.UsosPropiedades>(new DAL.TE.AdministracionTE().ObtenerUsoPropieadad(IdUsoPropiedad));
        }

        //Editar

        public void EditarUsoPropiedad(DTO.UsosPropiedades UsoPropiedad, int IdUsuariomodificacion)
        {
            new DAL.TE.AdministracionTE().EditarUsoPropiedad(MapperConfig.Config.MapperAdministracion.Map<DAL.UsosPropiedades>(UsoPropiedad), IdUsuariomodificacion);
        }

        //Eliminar

        public void EliminarUsoPropiedad(int IdUsoPropiedad, int IdUsuarioModificacion)
        {
            new DAL.TE.AdministracionTE().EliminarUsoPropiedad(IdUsoPropiedad, IdUsuarioModificacion);
        }

        #endregion
    }
}
