using AutoMapper;
using Intec.BL.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class EquiposBE : _beDefault
    {
        #region Equipos

        //Crear

        public void AgregarEquipo(DTO.Equipos Equipo)
        {
            Equipo.FechaProximaCalibracion = string.IsNullOrEmpty(Equipo.FechaProximaCalibracionString) ? default : DateTime.Parse(Equipo.FechaProximaCalibracionString, new CultureInfo("es-Co"));
            Equipo.FechaProximoMantenimiento= string.IsNullOrEmpty(Equipo.FechaProximoMantenimientoString) ? default : DateTime.Parse(Equipo.FechaProximoMantenimientoString, new CultureInfo("es-Co"));
            Equipo.FechaUltimaCalibracion= string.IsNullOrEmpty(Equipo.FechaUltimaCalibracionString) ? default : DateTime.Parse(Equipo.FechaUltimaCalibracionString, new CultureInfo("es-Co"));
            Equipo.FechaUltimaVerificacionLaboratorio= string.IsNullOrEmpty(Equipo.FechaUltimaVerificacionLaboratorioString) ? default : DateTime.Parse(Equipo.FechaUltimaVerificacionLaboratorioString, new CultureInfo("es-Co"));            
            Equipo.FechaProximaVerificacion = string.IsNullOrEmpty(Equipo.FechaProximaVerificacionString) ? default : DateTime.Parse(Equipo.FechaProximaVerificacionString, new CultureInfo("es-Co"));

            if (!Equipo.RequiereCalibracion)
            {
                Equipo.Calibrado = false;
                Equipo.FechaUltimaCalibracion = default;
                Equipo.PeriodoCalibracion = string.Empty;
                Equipo.FechaProximaCalibracion = default;
            }
            new DAL.TE.EquiposTE().AgregarEquipo(MapperConfig.Config.MapperEquipos.Map<DAL.Equipos>(Equipo));
        }

        //Obtener

        public List<DTO.Equipos> ObtenerEquipos(int IdMarca, int IdTipoEquipo, string filtro)
        {
            List<DTO.Equipos> res = new List<Equipos>();
            res = MapperConfig.Config.MapperEquiposSimple.Map<List<DTO.Equipos>>(new DAL.TE.EquiposTE().ObtenerEquipos(IdMarca, IdTipoEquipo, filtro));
            foreach(DTO.Equipos equipo in res)
            {
                equipo.PendTramiteAdmin = new DAL.TE.EquiposTE().PendTramiteAdmin(equipo.IdEquipo);
            }
            return res;
        }

        public DTO.Equipos ObtenerEquipo(int IdEquipo)
        {
            DTO.Equipos equipo = MapperConfig.Config.MapperEquipos.Map<DTO.Equipos>(new DAL.TE.EquiposTE().ObtenerEquipo(IdEquipo));
            equipo.TramitesEquipo = equipo.TramitesEquipo.OrderByDescending(d => d.FechaCreacion).ToList();
            return equipo;
        }

        //Editar no hay


        //Eliminar

        public void EliminarEquipo(int IdEquipo)
        {
            new DAL.TE.EquiposTE().EliminarEquipo(IdEquipo);
        }

        //Tramitar Equipo a Inspector

        public void TramitarEquipoInspector(int IdEquipo, int? IdInspector, int IdUsuarioTramita, string Tramite, string Observaciones)
        {
            new DAL.TE.EquiposTE().TramitarEquipoInspector(IdEquipo, IdInspector, IdUsuarioTramita, Tramite, Observaciones);
        }

        //Ingresar Verificaciones LAB

        public void IngresarVerificacionLAB(DTO.VerificacionesLabEquipos Verificacion)
        {
            Verificacion.FechaVerificacion = DateTime.Parse(Verificacion.FechaVerificacionString, new CultureInfo("es-Co"));
            new DAL.TE.EquiposTE().IngresarVerificacionLAB(MapperConfig.Config.MapperEquipos.Map<DAL.VerificacionesLabEquipos>(Verificacion));
        }

        public void ActualizarEquipo(Equipos equipos, int IdUsuarioModificacion)
        {
            equipos.FechaProximaCalibracion = string.IsNullOrEmpty(equipos.FechaProximaCalibracionString) ? default : DateTime.Parse(equipos.FechaProximaCalibracionString, new CultureInfo("es-Co"));
            equipos.FechaProximoMantenimiento = string.IsNullOrEmpty(equipos.FechaProximoMantenimientoString) ? default : DateTime.Parse(equipos.FechaProximoMantenimientoString, new CultureInfo("es-Co"));
            new DAL.TE.EquiposTE().ActualizarEquipo(MapperConfig.Config.MapperEquipos.Map<DAL.Equipos>(equipos), IdUsuarioModificacion);

        }

        //Ingresar Calibraciones Equipos

        public void IngresarCalibracionEq(DTO.CalibracionesEquipos Calibracion)
        {
            File.Copy(Calibracion.Certificado, Calibracion.Certificado.Replace(@"tmp\", ""));
            Calibracion.Certificado = Calibracion.Certificado.Replace(@"tmp\", "");
            Calibracion.FechaCalibracion = DateTime.Parse(Calibracion.FechaCalibracionString, new CultureInfo("es-Co"));
            new DAL.TE.EquiposTE().IngresarCalibracionEq(MapperConfig.Config.MapperEquipos.Map<DAL.CalibracionesEquipos>(Calibracion));
        }

        public List<DTO.UsuariosEquipos> ObtenerEquiposUsuario(int IdInspector)
        {
            return MapperConfig.Config.MapperUsuariosEquipos.Map<List<DTO.UsuariosEquipos>>( new DAL.TE.EquiposTE().ObtenerEquiposUsuario(IdInspector));
        }
        #endregion
    }
}
