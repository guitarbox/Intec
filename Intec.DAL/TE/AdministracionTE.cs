using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class AdministracionTE
    {
        #region Admin
        public List<Roles> ObtenerRoles()
        {
            List<Roles> res = new List<Roles>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Roles.ToList();
            }
            return res;
        }
        #endregion

        #region  CRUD Paises

        //Crear

        public void CrearPais(Paises PaisCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                PaisCrear.FechaCreacion = DateTime.Now;
                PaisCrear.Activo = true;
                ctx.Paises.Add(PaisCrear);
                ctx.SaveChanges();
            }
        }

        //Obtener

        public List<Paises> ObtenerPaises()
        {
            List<Paises> res = new List<Paises>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Paises.ToList();
            }
            return res;
        }
        
        public List<Paises> ObtenerPaisesActivos()
        {
            List<Paises> res = new List<Paises>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Paises.Where(p=>p.Activo).ToList();
            }
            return res;
        }

        public Paises ObtenerPais(int IdPais)
        {
            Paises res = new Paises();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Paises.Where(p => p.IdPais == IdPais).FirstOrDefault();
            }

            return res;
        }


        //Editar

        public void EditarPais(Paises Pais, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Paises PaisEditar = ctx.Paises.Where(c => c.IdPais == Pais.IdPais).FirstOrDefault();

                if(PaisEditar != null)
                {
                    PaisEditar.CodigoPais = Pais.CodigoPais;
                    PaisEditar.Pais = Pais.Pais;
                    PaisEditar.Activo = Pais.Activo;

                    PaisEditar.FechaModificacion = DateTime.Now;
                    PaisEditar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                {
                  
                }
               
            }

        }

        //Eliminar

        public void EliminarPais(int IdPais, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Paises PaisEliminar = ctx.Paises.Where(u => u.IdPais == IdPais).FirstOrDefault();
                if (PaisEliminar != null)
                {
                    PaisEliminar.Activo = false;

                    PaisEliminar.FechaModificacion = DateTime.Now;
                    PaisEliminar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe un País con ID {IdPais}");
                }

            }
        }

        #endregion

        #region CRUD Departamentos

        //Crear

        public void CrearDepartamento(Departamentos DepartamentoCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                DepartamentoCrear.FechaCreacion = DateTime.Now;
                DepartamentoCrear.Activo = true;
                ctx.Departamentos.Add(DepartamentoCrear);
                ctx.SaveChanges();
            }
        }

        //Obtener

        public List<Departamentos> ObtenerDepartamentos(int IdPais)
        {
            List<Departamentos> res = new List<Departamentos>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Departamentos.Where(d => d.IdPais == IdPais).ToList();
            }
            return res;
        }
        
        public List<Departamentos> ObtenerDepartamentosActivos(int IdPais)
        {
            List<Departamentos> res = new List<Departamentos>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Departamentos.Where(d => d.IdPais == IdPais && d.Activo).ToList();
            }
            return res;
        }

        public Departamentos ObtenerDepartamento(string IdDepartamento)
        {
            Departamentos res = new Departamentos();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Departamentos.Where(d => d.IdDepartamento == IdDepartamento).FirstOrDefault();
            }

            return res;
        }

        //Editar

        public void EditarDepartamento(Departamentos Departamento, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Departamentos DepartamentoEditar = ctx.Departamentos.Where(c => c.IdDepartamento == Departamento.IdDepartamento).FirstOrDefault();

                DepartamentoEditar.Departamento = Departamento.Departamento;
                DepartamentoEditar.Activo = Departamento.Activo;

                DepartamentoEditar.FechaModificacion = DateTime.Now;
                DepartamentoEditar.IdUsuarioModificacion = IdUsuarioModificacion;

                ctx.SaveChanges();
            }

        }

        //Eliminar

        public void EliminarDepartamento(string IdDepartamento, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Departamentos DepartamentoEliminar = ctx.Departamentos.Where(u => u.IdDepartamento == IdDepartamento).FirstOrDefault();
                if (DepartamentoEliminar != null)
                {
                    DepartamentoEliminar.Activo = false;

                    DepartamentoEliminar.FechaModificacion = DateTime.Now;
                    DepartamentoEliminar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe un Depatamento con ID {IdDepartamento}");
                }

            }
        }

        #endregion

        #region CRUD Ciudades

        //Crear

        public void CrearCiudad(Ciudades CiudadCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                CiudadCrear.FechaCreacion = DateTime.Now;
                CiudadCrear.Activo = true;
                ctx.Ciudades.Add(CiudadCrear);
                ctx.SaveChanges();
            }
        }

        //Obtener

        public List<Ciudades> ObtenerCiudades(string IdDepartamento)
        {
            List<Ciudades> res = new List<Ciudades>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Ciudades.Where(c => string.IsNullOrEmpty(IdDepartamento) || c.IdDepartamento.Equals(IdDepartamento)).ToList();
            }
            return res;
        }
        
        public List<Ciudades> ObtenerCiudadesActivos(string IdDepartamento)
        {
            List<Ciudades> res = new List<Ciudades>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Ciudades.Where(c => string.IsNullOrEmpty(IdDepartamento) || c.IdDepartamento.Equals(IdDepartamento) && c.Activo).ToList();
            }
            return res;
        }

        public Ciudades ObtenerCiudad(string IdCiudad)
        {
            Ciudades res = new Ciudades();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Ciudades.Where(c => c.IdCiudad == IdCiudad).FirstOrDefault();
            }

            return res;
        }

        //Editar

        public void EditarCiudad(Ciudades Ciudad, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Ciudades CiudadEditar = ctx.Ciudades.Where(c => c.IdCiudad == Ciudad.IdCiudad).FirstOrDefault();

                CiudadEditar.Ciudad = Ciudad.Ciudad ;
                CiudadEditar.Activo = Ciudad.Activo;

                CiudadEditar.FechaModificacion = DateTime.Now;
                CiudadEditar.IdUsuarioModificacion = IdUsuarioModificacion;

                ctx.SaveChanges();
            }

        }

        //Eliminar

        public void EliminarCiudad(string IdCiudad, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Ciudades CiudadEliminar = ctx.Ciudades.Where(u => u.IdCiudad == IdCiudad).FirstOrDefault();
                if (CiudadEliminar != null)
                {
                    CiudadEliminar.Activo = false;

                    CiudadEliminar.FechaModificacion = DateTime.Now;
                    CiudadEliminar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe una Ciudad con ID {IdCiudad}");
                }

            }
        }

        #endregion

        #region CRUD TiposIdentificacion

        //Crear

        public void CrearTipoIdentificacion(TiposIdentificacion TipoIdentificacionCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                if (ctx.TiposIdentificacion.Where(ti => ti.Abreviatura.Equals(TipoIdentificacionCrear.Abreviatura)).FirstOrDefault() == null)
                {
                    TipoIdentificacionCrear.FechaCreacion = DateTime.Now;
                    TipoIdentificacionCrear.Activo = true;
                    ctx.TiposIdentificacion.Add(TipoIdentificacionCrear);
                    ctx.SaveChanges();
                }
                else
                    throw new Exception($"Ya existe un Tipo de Identificación con abreviatura {TipoIdentificacionCrear.Abreviatura}");
            }
        }

        //Obtener

        public List<TiposIdentificacion> ObtenerTiposIdentificacion()
        {
            List<TiposIdentificacion> res = new List<TiposIdentificacion>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposIdentificacion.ToList();
            }
            return res;
        }
        
        public List<TiposIdentificacion> ObtenerTiposIdentificacionActivos()
        {
            List<TiposIdentificacion> res = new List<TiposIdentificacion>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposIdentificacion.Where(t=>t.Activo).ToList();
            }
            return res;
        }

        public TiposIdentificacion ObtenerTipoIdentificacion(int IdTipoIdentificacion)
        {
            TiposIdentificacion res = new TiposIdentificacion();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposIdentificacion.Where(t => t.IdTipoIdentificacion == IdTipoIdentificacion).FirstOrDefault();
            }

            return res;
        }

        //Editar

        public void EditarTipoIdentificacion(TiposIdentificacion TipoIdentificacion, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TiposIdentificacion TipoIdentificacionEditar = ctx.TiposIdentificacion.Where(c => c.IdTipoIdentificacion == TipoIdentificacion.IdTipoIdentificacion).FirstOrDefault();
                if (ctx.TiposIdentificacion.Where(ti => ti.Abreviatura.Equals(TipoIdentificacion.Abreviatura) && ti.IdTipoIdentificacion != TipoIdentificacion.IdTipoIdentificacion).FirstOrDefault() == null)
                {
                    TipoIdentificacionEditar.Abreviatura = TipoIdentificacion.Abreviatura;
                    TipoIdentificacionEditar.TipoIdentificacion = TipoIdentificacion.TipoIdentificacion;
                    TipoIdentificacionEditar.Activo = TipoIdentificacion.Activo;

                    TipoIdentificacionEditar.FechaModificacion = DateTime.Now;
                    TipoIdentificacionEditar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                    throw new Exception($"Ya existe un Tipo de Identificación con abreviatura {TipoIdentificacion.Abreviatura}");
            }

        }

        //Eliminar

        public void EliminarTipoIdentificacion(int IdTipoIdentificacion, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TiposIdentificacion TipoIdentificacionEliminar = ctx.TiposIdentificacion.Where(u => u.IdTipoIdentificacion == IdTipoIdentificacion).FirstOrDefault();
                if (TipoIdentificacionEliminar != null)
                {
                    TipoIdentificacionEliminar.Activo = false;

                    TipoIdentificacionEliminar.FechaModificacion = DateTime.Now;
                    TipoIdentificacionEliminar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe un tipo de identificación con ID {IdTipoIdentificacion}");
                }

            }
        }

        #endregion

        #region CRUD MarcasEquipos

        //Crear
        public void CrearMarcaEquipos(MarcasEquipos MarcaCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                MarcaCrear.FechaCreacion = DateTime.Now;
                MarcaCrear.Activo = true;
                ctx.MarcasEquipos.Add(MarcaCrear);
                ctx.SaveChanges();
            }
        }

        //Obtener
        public List<MarcasEquipos> ObtenerMarcasEquipos()
        {
            List<MarcasEquipos> res = new List<MarcasEquipos>();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.MarcasEquipos.ToList();
            }

            return res;
        }
        
        public List<MarcasEquipos> ObtenerMarcasEquiposActivos()
        {
            List<MarcasEquipos> res = new List<MarcasEquipos>();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.MarcasEquipos.Where(m=>m.Activo).ToList();
            }

            return res;
        }

        public MarcasEquipos ObtenerMarcaEquipo(int IdMarcaEquipo)
        {
            MarcasEquipos res = new MarcasEquipos();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.MarcasEquipos.Where(m => m.IdMarcaEquipo == IdMarcaEquipo).FirstOrDefault();
            }

            return res;
        }

        //Editar

        public void EditarMarcaEquipo(MarcasEquipos MarcaEquipo, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                MarcasEquipos MarcaEquipoEditar = ctx.MarcasEquipos.Where(c => c.IdMarcaEquipo == MarcaEquipo.IdMarcaEquipo).FirstOrDefault();

                MarcaEquipoEditar.MarcaEquipo = MarcaEquipo.MarcaEquipo;
                MarcaEquipoEditar.Activo = MarcaEquipo.Activo;

                MarcaEquipoEditar.FechaModificacion = DateTime.Now;
                MarcaEquipoEditar.IdUsuarioModificacion = IdUsuarioModificacion;

                ctx.SaveChanges();
            }

        }

        //Eliminar
        public void EliminarMarcaEquipo(int IdMarca, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                MarcasEquipos MarcaEliminar = ctx.MarcasEquipos.Where(u => u.IdMarcaEquipo == IdMarca).FirstOrDefault();
                if (MarcaEliminar != null)
                {
                    MarcaEliminar.Activo = false;

                    MarcaEliminar.FechaModificacion = DateTime.Now;
                    MarcaEliminar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe una Marca con ID {IdMarca}");
                }

            }
        }

        #endregion

        #region CRUD TiposEquipo

        //Crear
        public void CrearTipoEquipo(TiposEquipo TipoEqupioCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TipoEqupioCrear.FechaCreacion = DateTime.Now;
                TipoEqupioCrear.Activo = true;
                ctx.TiposEquipo.Add(TipoEqupioCrear);
                ctx.SaveChanges();
            }
        }

        //Obtener
        public List<TiposEquipo> ObtenerTiposEquipo()
        {
            List<TiposEquipo> res = new List<TiposEquipo>();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposEquipo.ToList();
            }

            return res;
        }
        
        public List<TiposEquipo> ObtenerTiposEquipoActivos()
        {
            List<TiposEquipo> res = new List<TiposEquipo>();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposEquipo.Where(t=>t.Activo).ToList();
            }

            return res;
        }

        public TiposEquipo ObtenerTipoEquipo(int IdTipoEquipo)
        {
            TiposEquipo res = new TiposEquipo();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposEquipo.Where(t => t.IdTipoEquipo == IdTipoEquipo).FirstOrDefault();
            }

            return res;
        }

        //Editar

        public void EditarTipoEquipo(TiposEquipo TipoEquipo, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TiposEquipo TipoEquipoEditar = ctx.TiposEquipo.Where(c => c.IdTipoEquipo == TipoEquipo.IdTipoEquipo).FirstOrDefault();

                TipoEquipoEditar.TipoEquipo = TipoEquipo.TipoEquipo;
                TipoEquipoEditar.Activo = TipoEquipo.Activo;

                TipoEquipoEditar.FechaModificacion = DateTime.Now;
                TipoEquipoEditar.IdUsuarioModificacion = IdUsuarioModificacion;

                ctx.SaveChanges();
            }

        }

        //Eliminar
        public void EliminarTipoEquipo(int IdTipoEquipo, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TiposEquipo TipoEquipoEliminar = ctx.TiposEquipo.Where(u => u.IdTipoEquipo == IdTipoEquipo).FirstOrDefault();
                if (TipoEquipoEliminar != null)
                {
                    TipoEquipoEliminar.Activo = false;

                    TipoEquipoEliminar.FechaModificacion = DateTime.Now;
                    TipoEquipoEliminar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe un tipo de equipo con ID {IdTipoEquipo}");
                }

            }
        }

        #endregion

        #region CRUD TiposPersona

        //Crear

        public void CrearTipoPersona(TiposPersona TipoPersonaCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TipoPersonaCrear.FechaCreacion = DateTime.Now;
                TipoPersonaCrear.Activo = true;
                ctx.TiposPersona.Add(TipoPersonaCrear);
                ctx.SaveChanges();
            }
        }

        //Obtener

        public List<TiposPersona> ObtenerTiposPersona()
        {
            List<TiposPersona> res = new List<TiposPersona>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposPersona.ToList();
            }
            return res;
        }
        
        public List<TiposPersona> ObtenerTiposPersonaActivos()
        {
            List<TiposPersona> res = new List<TiposPersona>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposPersona.Where(t=>t.Activo).ToList();
            }
            return res;
        }

        public TiposPersona ObtenerTipoPersona(int IdTipoPersona)
        {
            TiposPersona res = new TiposPersona();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposPersona.Where(t => t.IdTipoPersona == IdTipoPersona).FirstOrDefault();
            }

            return res;
        }


        //Editar

        public void EditarTipoPersona(TiposPersona TipoPersona, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TiposPersona TipoPersonaEditar = ctx.TiposPersona.Where(c => c.IdTipoPersona == TipoPersona.IdTipoPersona).FirstOrDefault();

                TipoPersonaEditar.TipoPersona = TipoPersona.TipoPersona;
                TipoPersonaEditar.CodigoTipoPersona = TipoPersona.CodigoTipoPersona;
                TipoPersonaEditar.Activo = TipoPersona.Activo;

                TipoPersonaEditar.FechaModificacion = DateTime.Now;
                TipoPersonaEditar.IdUsuarioModificacion = IdUsuarioModificacion;

                ctx.SaveChanges();
            }

        }

        //Eliminar

        public void EliminarTipoPersona(int IdTipoPersona, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TiposPersona TipoPersonaEliminar = ctx.TiposPersona.Where(u => u.IdTipoPersona == IdTipoPersona).FirstOrDefault();
                if (TipoPersonaEliminar != null)
                {
                    TipoPersonaEliminar.Activo = false;

                    TipoPersonaEliminar.FechaModificacion = DateTime.Now;
                    TipoPersonaEliminar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe un tipo de persona con ID {IdTipoPersona}");
                }

            }
        }

        #endregion

        #region CRUD TiposPropiedades

        //Crear

        public void CrearTipoPropiedad(TiposPropiedades TipoPropieadaCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TipoPropieadaCrear.FechaCreacion = DateTime.Now;
                TipoPropieadaCrear.Activo = true;
                ctx.TiposPropiedades.Add(TipoPropieadaCrear);
                ctx.SaveChanges();
            }
        }

        //Obtener

        public List<TiposPropiedades> ObtenerTiposPropiedades()
        {
            List<TiposPropiedades> res = new List<TiposPropiedades>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposPropiedades.ToList();
            }
            return res;
        }
        
        public List<TiposPropiedades> ObtenerTiposPropiedadesActivos()
        {
            List<TiposPropiedades> res = new List<TiposPropiedades>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposPropiedades.Where(t=>t.Activo).ToList();
            }
            return res;
        }

        public TiposPropiedades ObtenerTipoPropiedad(int IdTipoPropiedad)
        {
            TiposPropiedades res = new TiposPropiedades();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposPropiedades.Where(t => t.IdTipoPropiedad == IdTipoPropiedad).FirstOrDefault();
            }

            return res;
        }

        //Editar

        public void EditarTipoPropiedad(TiposPropiedades TipoPropiedad, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TiposPropiedades TipoPropiedadEditar = ctx.TiposPropiedades.Where(c => c.IdTipoPropiedad == TipoPropiedad.IdTipoPropiedad).FirstOrDefault();

                TipoPropiedadEditar.TipoPropiedad = TipoPropiedad.TipoPropiedad;
                TipoPropiedadEditar.Activo = TipoPropiedad.Activo;
                TipoPropiedadEditar.FechaModificacion = DateTime.Now;
                TipoPropiedadEditar.IdUsuarioModificacion = IdUsuarioModificacion;

                ctx.SaveChanges();
            }

        }

        //Eliminar

        public void EliminarTipoPropiedad(int IdTipoPropiedad, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TiposPropiedades TipoPropiedadEliminar = ctx.TiposPropiedades.Where(u => u.IdTipoPropiedad == IdTipoPropiedad).FirstOrDefault();
                if (TipoPropiedadEliminar != null)
                {
                    TipoPropiedadEliminar.Activo = false;

                    TipoPropiedadEliminar.FechaModificacion = DateTime.Now;
                    TipoPropiedadEliminar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe un tipo de propiedad con ID {IdTipoPropiedad}");
                }

            }
        }

        #endregion

        #region CRUD UsosPropiedades

        //Crear

        public void CrearUsoPropiedad(UsosPropiedades UsoPropiedadCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                UsoPropiedadCrear.FechaCreacion = DateTime.Now;
                UsoPropiedadCrear.Activo = true;
                ctx.UsosPropiedades.Add(UsoPropiedadCrear);
                ctx.SaveChanges();
            }
        }

        //Obtener

        public List<UsosPropiedades> ObtenerUsosPropiedades()
        {
            List<UsosPropiedades> res = new List<UsosPropiedades>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.UsosPropiedades.ToList();
            }
            return res;
        }
        
        public List<UsosPropiedades> ObtenerUsosPropiedadesActivos()
        {
            List<UsosPropiedades> res = new List<UsosPropiedades>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.UsosPropiedades.Where(u=>u.Activo).ToList();
            }
            return res;
        }

        public UsosPropiedades ObtenerUsoPropieadad(int IdUso)
        {
            UsosPropiedades res = new UsosPropiedades();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.UsosPropiedades.Where(u => u.IdUso == IdUso).FirstOrDefault();
            }

            return res;
        }

        //Editar

        public void EditarUsoPropiedad(UsosPropiedades UsoPropiedad, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                UsosPropiedades UsoPropiedadEditar = ctx.UsosPropiedades.Where(c => c.IdUso == UsoPropiedad.IdUso).FirstOrDefault();

                UsoPropiedadEditar.Uso = UsoPropiedad.Uso;
                UsoPropiedadEditar.Activo = UsoPropiedad.Activo;
                UsoPropiedadEditar.FechaModificacion = DateTime.Now;
                UsoPropiedadEditar.IdUsuarioModificacion = IdUsuarioModificacion;

                ctx.SaveChanges();
            }

        }

        //Eliminar

        public void EliminarUsoPropiedad(int IdUso, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                UsosPropiedades UsoPropiedadEliminar = ctx.UsosPropiedades.Where(u => u.IdUso == IdUso).FirstOrDefault();
                if (UsoPropiedadEliminar != null)
                {
                    UsoPropiedadEliminar.Activo = false;

                    UsoPropiedadEliminar.FechaModificacion = DateTime.Now;
                    UsoPropiedadEliminar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe un uso de propiedad con ID {IdUso}");
                }

            }
        }

        #endregion

    }
}
