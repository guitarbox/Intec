using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class VisitasBE : _beDefault
    {
        #region Zonas
        //Crear

        public void CrearZona(DTO.Zonas ZonaCrear)
        {
            new DAL.TE.VisitasTE().CrearZona(MapperConfig.Config.MapperVisitas.Map<DAL.Zonas>(ZonaCrear));
        }

        //Obtener

        public List<DTO.Zonas> ObtenerZonas(string idCiudad)
        {
            return MapperConfig.Config.MapperVisitas.Map<List<DTO.Zonas>>(new DAL.TE.VisitasTE().ObtenerZonas(idCiudad));
        }

        public List<DTO.Zonas> ObtenerZonasAll()
        {
            return MapperConfig.Config.MapperVisitas.Map<List<DTO.Zonas>>(new DAL.TE.VisitasTE().ObtenerZonasAll());
        }

        public DTO.Zonas ObtenerZona(int IdZona)
        {
            return MapperConfig.Config.MapperVisitas.Map<DTO.Zonas>(new DAL.TE.VisitasTE().ObtenerZona(IdZona));
        }

        #endregion

        #region Asignación zona a Inspector

        public void AsignarZonaInspector(int IdZona, string IdCiudad, int IdInspector, int IdUsuarioAsigna)
        {
            new DAL.TE.VisitasTE().AsignarZonaInspector(IdZona, IdCiudad, IdInspector, IdUsuarioAsigna);
        }

        public void ReAsignarZonaInspector(int IdZona, string IdCiudad, int IdNvoInspector, int IdUsuarioReAsigna)
        {
            new DAL.TE.VisitasTE().ReAsignarZonaInspector(IdZona, IdCiudad, IdNvoInspector, IdUsuarioReAsigna);
        }

        #endregion

        #region Visitas

        public void ProgramarVisita(DTO.Visitas Visita)
        {
            Visita.FechaVisita = DateTime.Parse(Visita.FechaVisitaString, new CultureInfo("es-Co"));
            new DAL.TE.VisitasTE().ProgramarVisita(MapperConfig.Config.MapperVisitas.Map<DAL.Visitas>(Visita));
        }
        
        public void ReasignacionVisita(int IdVisita, int IdInspector)
        {
            new DAL.TE.VisitasTE().ReasignacionVisita(IdVisita, IdInspector);
        }

        public void AgregarFotoVisita(DTO.FotosVisita Foto, int IdVisita)
        {
            new DAL.TE.VisitasTE().AgregarFotoVisita(MapperConfig.Config.MapperVisitas.Map<DAL.FotosVisita>(Foto), IdVisita);
        }
        
        public void AgregarFormatoVisita(DTO.FormatosVisita Formato, int IdVisita)
        {
            new DAL.TE.VisitasTE().AgregarFormatoVisita(MapperConfig.Config.MapperVisitas.Map<DAL.FormatosVisita>(Formato), IdVisita);
        }

        public void AgregarEquipoVisita(DTO.EquiposVisita Equipo, int IdVisita)
        {
            new DAL.TE.VisitasTE().AgregarEquipoVisita(MapperConfig.Config.MapperVisitas.Map<DAL.EquiposVisita>(Equipo), IdVisita);
        }

        public DTO.Visitas ConsultarVisita(int IdVisita)
        {
            DAL.Visitas visita = new DAL.TE.VisitasTE().ConsultarVisita(IdVisita);
            visita.Propiedades = new DAL.TE.ClientesTE().ConsultaPropiedad(visita.IdPropiedad);
            return MapperConfig.Config.MapperVisitas.Map<DTO.Visitas>(visita);
        }

        public List<DTO.uspConsultarVisitas_Result> ConsultaVisitas(DateTime FechaInicial, DateTime FechaFinal, string NumeroIdentificacionCliente, int IdInspector, string IdEstadoVisita)
        {
            return MapperConfig.Config.MapperVisitas.Map<List<DTO.uspConsultarVisitas_Result>>(new DAL.TE.VisitasTE().ConsultaVisitas(FechaInicial, FechaFinal, NumeroIdentificacionCliente, IdInspector, IdEstadoVisita));
        }

        public List<DTO.EstadosVisita> ObtenerEstadosVisita()
        {
            return MapperConfig.Config.MapperVisitas.Map<List<DTO.EstadosVisita>>(new DAL.TE.VisitasTE().ObtenerEstadosVisita());
        }

        #endregion
    }
}
