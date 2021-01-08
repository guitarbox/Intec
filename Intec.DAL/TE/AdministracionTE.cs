using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class AdministracionTE
    {
        public List<Paises> ObtenerPaises()
        {
            List<Paises> res = new List<Paises>();
            using(var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Paises.ToList();
            }
            return res;
        }

        public List<Departamentos> ObtenerDepartamentos(int IdPais)
        {
            List<Departamentos> res = new List<Departamentos>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Departamentos.Where(d => d.IdPais == IdPais).ToList();
            }
            return res;
        }

        #region CRUD Ciudades
        public List<Ciudades> ObtenerCiudades(string IdDepartamento)
        {
            List<Ciudades> res = new List<Ciudades>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Ciudades.Where(c => c.IdDepartamento.Equals(IdDepartamento)).ToList();
            }
            return res;
        }
        //Crear
        //Editar
        #endregion

        public List<TiposIdentificacion> ObtenerTiposIdentificacion()
        {
            List<TiposIdentificacion> res = new List<TiposIdentificacion>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposIdentificacion.ToList();
            }
            return res;
        }

        //Marcas

        //1.
        public void CrearMarca(MarcasEquipos MarcaCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                MarcaCrear.FechaCreacion = DateTime.Now;
                ctx.MarcasEquipos.Add(MarcaCrear);
                ctx.SaveChanges();
            }
        }

        //2.
        public void EliminarMarca(int IdMarca)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                MarcasEquipos MarcaEliminar = ctx.MarcasEquipos.Where(u => u.IdMarcaEquipo == IdMarca).FirstOrDefault();
                if (MarcaEliminar != null)
                {
                    ctx.MarcasEquipos.Remove(MarcaEliminar);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe una Marca con ID {IdMarca}");
                }

            }
        }

        //3.
        public List<MarcasEquipos> ConsultarMarcas()
        {
            List<MarcasEquipos> res = new List<MarcasEquipos>();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.MarcasEquipos.ToList();
            }

            return res;

        }


        //Tipos de Equipo

        //1.
        public void CrearTipoEquipo(TiposEquipo TipoEqupioCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TipoEqupioCrear.FechaCreacion = DateTime.Now;
                ctx.TiposEquipo.Add(TipoEqupioCrear);
                ctx.SaveChanges();
            }
        }

        //2.
        public void EliminarTipoEquipo(int IdTipoEquipo)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TiposEquipo TipoEquipoEliminar = ctx.TiposEquipo.Where(u => u.IdTipoEquipo == IdTipoEquipo).FirstOrDefault();
                if (TipoEquipoEliminar != null)
                {
                    ctx.TiposEquipo.Remove(TipoEquipoEliminar);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe una Tipo de equipo con ID {IdTipoEquipo}");
                }

            }
        }

        //3.
        public List<TiposEquipo> ConsultaTipoEquipo()
        {
            List<TiposEquipo> res = new List<TiposEquipo>();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TiposEquipo.ToList();
            }

            return res;

        }

        //Ciudades
        //Departamentos
        //Paises
        //TiposIdentificación
        //TiposPersona
        //TiposPropiedades
        //UsosPropiedades        
    }
}
