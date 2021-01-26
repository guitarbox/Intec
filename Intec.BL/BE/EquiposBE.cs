using System;
using System.Collections.Generic;
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
            new DAL.TE.EquiposTE().AgregarEquipo(MapperConfig.Config.MapperEquipos.Map<DAL.Equipos>(Equipo));
        }

        //Obtener

        public List<DAL.Equipos> ObtenerEquipos(int IdMarca, int IdTipoEquipo, string filtro)
        {
            return new DAL.TE.EquiposTE().ObtenerEquipos(IdMarca, IdTipoEquipo, filtro);
        }

        public DTO.Equipos ObtenerEquipo(int IdEquipo)
        {
            return MapperConfig.Config.MapperEquipos.Map<DTO.Equipos>(new DAL.TE.EquiposTE().ObtenerEquipos(IdEquipo));
        }

        //Editar no hay


        //Eliminar

        public void EliminarEquipo(int IdEquipo)
        {
            new DAL.TE.EquiposTE().EliminarEquipo(IdEquipo);
        }

        //Tramitar Equipo a Inspector

        public void TramitarEquipoInspector(int IdEquipo, int IdInspector, int IdUsuarioTramita, string Tramite, string Observaciones)
        {
            new DAL.TE.EquiposTE().TramitarEquipoInspector(IdEquipo, IdInspector, IdUsuarioTramita, Tramite, Observaciones);
        }

        //Ingresar Verificaciones LAB

        public void IngresarVerificacionLAB(DTO.VerificacionesLabEquipos Verificacion)
        {
            new DAL.TE.EquiposTE().IngresarVerificacionLAB(MapperConfig.Config.MapperEquipos.Map<DAL.VerificacionesLabEquipos>(Verificacion));
        }

        //Ingresar Calibraciones Equipos

        public void IngresarCalibracionEq(DTO.CalibracionesEquipos Calibracion)
        {
            new DAL.TE.EquiposTE().IngresarCalibracionEq(MapperConfig.Config.MapperEquipos.Map<DAL.CalibracionesEquipos>(Calibracion));
        }

        #endregion
    }
}
