using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class VisitasTE
    {
        ////**************************************************** ZONAS => Todo lo que tenga que ver con zonas
        //CRUD ZONAS
        public List<Zonas> ObtenerZonasAll()
        {
            List<Zonas> res = new List<Zonas>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Zonas.ToList();
                foreach(Zonas z in res)
                {
                    ctx.Entry(z).Reference(r => r.Ciudades).Load();
                    ctx.Entry(z).Reference(r => r.Usuarios).Load();
                }
            }
            return res;
        }
        
        public List<Zonas> ObtenerZonas(string idCiudad)
        {
            List<Zonas> res = new List<Zonas>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Zonas.Where(z=>z.IdCiudad.Equals(idCiudad)).ToList();
                foreach(Zonas z in res)
                {
                    ctx.Entry(z).Reference(r => r.Ciudades).Load();
                    ctx.Entry(z).Reference(r => r.Usuarios).Load();
                }
            }
            return res;
        }

        public Zonas ObtenerZona(int IdZona)
        {
            Zonas res = new Zonas();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Zonas.Where(z=>z.IdZona == IdZona).FirstOrDefault();
                ctx.Entry(res).Reference(z => z.Usuarios).Load();
            }
            return res;
        }

        public void CrearZona(Zonas Zona)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Zona.FechaCreacion = DateTime.Now;
                ctx.Zonas.Add(Zona);
                ctx.SaveChanges();
            }
        }

        //ASignación de zona a inspector, con manejo del histórico
        public void AsignarZonaInspector(int IdZona, string IdCiudad, int IdInspector, int IdUsuarioAsigna)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Zonas zona = ctx.Zonas.Where(z => z.IdZona == IdZona && z.IdCiudad.Equals(IdCiudad)).FirstOrDefault();
                if (zona != null)
                {
                    if (zona.IdInspector == null)
                    {
                        DateTime now = DateTime.Now;
                        zona.IdInspector = IdInspector;
                        zona.IdUsuarioModificacion = IdUsuarioAsigna;
                        zona.FechaModificacion = now;
                        ctx.SaveChanges();

                        int sec = ctx.HistoricoAsignacionZona.Where(h => h.IdZona == IdZona && zona.IdCiudad.Equals(IdCiudad)).Count();
                        sec += 1;

                        ctx.HistoricoAsignacionZona.Add(new HistoricoAsignacionZona()
                        {
                            IdZona = IdZona,
                            IdCiudad = IdCiudad,
                            IdInspector = IdInspector,
                            IdUsuarioCreacion = IdUsuarioAsigna,
                            FechaCreacion = now,
                            FechaInicio = now,
                            Secuencia = sec
                        });
                        ctx.SaveChanges();
                    }
                    else
                        throw new Exception("No se puede asignar inspector a zona, ésta ya tiene inspector. Intente reasignar inspector.");
                }
                else
                    throw new Exception($"No existe la zona con ID {IdZona} en la ciudad con ID {IdCiudad}");
            }
        }

        public void ReAsignarZonaInspector(int IdZona, string IdCiudad, int IdNvoInspector, int IdUsuarioReAsigna)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Zonas zona = ctx.Zonas.Where(z => z.IdZona == IdZona && z.IdCiudad.Equals(IdCiudad)).FirstOrDefault();
                if (zona != null)
                {
                    if (zona.IdInspector != null)
                    {
                        DateTime now = DateTime.Now;
                        zona.IdInspector = IdNvoInspector;
                        zona.IdUsuarioModificacion = IdUsuarioReAsigna;
                        zona.FechaModificacion = now;
                        ctx.SaveChanges();

                        HistoricoAsignacionZona hist = ctx.HistoricoAsignacionZona.Where(h => h.IdZona == IdZona && h.IdCiudad.Equals(IdCiudad) && h.FechaFin == null).FirstOrDefault();
                        hist.FechaFin = now;
                        hist.FechaModificacion = now;
                        hist.IdUsuarioModificacion = IdUsuarioReAsigna;
                        ctx.SaveChanges();

                        int sec = hist.Secuencia + 1;

                        ctx.HistoricoAsignacionZona.Add(new HistoricoAsignacionZona()
                        {
                            IdZona = IdZona,
                            IdCiudad = IdCiudad,
                            IdInspector = IdNvoInspector,
                            IdUsuarioCreacion = IdUsuarioReAsigna,
                            FechaCreacion = now,
                            FechaInicio = now,
                            Secuencia = sec
                        });
                        ctx.SaveChanges();
                    }
                    else
                        throw new Exception("No se puede reasignar zona, la zona no tiene inspector.");
                }
                else
                    throw new Exception("No existe la zona");
            }
        }

        //Reporte zonas y presencia en visitas
        //TODO => PENDIENTE

        //**************************************************** VISITAS => Todo lo que tenga que ver con visitas
        //Programación Visita
        public void ProgramarVisita(Visitas Visita)
        {
            using(var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Visita.FechaCreacion = DateTime.Now;
                ctx.Visitas.Add(Visita);
                ctx.SaveChanges();
            }
        }

        //Reasignación visita
        public void ReasignacionVisita(int IdVisita, int IdInspector)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Visitas visita = ctx.Visitas.Where(v => v.IdVisita == IdVisita).FirstOrDefault();
                if (visita != null)
                {
                    if (visita.IdEstadoVisitas.Equals("P"))
                    {
                        visita.IdInspector = IdInspector;
                        ctx.SaveChanges();
                    }
                    else
                        throw new Exception($"No se puede reasignar la visita en el estado {visita.IdEstadoVisitas}");
                }
                else
                    throw new Exception($"No se encontró la visita con ID {IdVisita}");
            }
        }

        //Agregar FotosVisita
        public void AgregarFotoVisita(FotosVisita Foto, int IdVisita)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Visitas visita = ctx.Visitas.Where(v => v.IdVisita == IdVisita).FirstOrDefault();
                if (visita != null)
                {
                    Foto.Secuencia = ctx.FotosVisita.Where(fv => fv.IdVisita == Foto.IdVisita).Count() + 1;
                    visita.FotosVisita.Add(Foto);
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No se encontró la visita");
            }
        }

        //Agregar FormatosVisita
        public void AgregarFormatoVisita(FormatosVisita Formato, int IdVisita)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Visitas visita = ctx.Visitas.Where(v => v.IdVisita == IdVisita).FirstOrDefault();
                if (visita != null)
                {
                    Formato.Secuencia = ctx.FormatosVisita.Where(fv => fv.IdVisita == Formato.IdVisita).Count() + 1;
                    visita.FormatosVisita.Add(Formato);
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No se encontró la visita");
            }
        }

        //Agregar EquiposVisita
        public void AgregarEquipoVisita(EquiposVisita Equipo, int IdVisita)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Visitas visita = ctx.Visitas.Where(v => v.IdVisita == IdVisita).FirstOrDefault();
                if (visita != null)
                {
                    Equipo.Secuencia = ctx.EquiposVisita.Where(fv => fv.IdVisita == Equipo.IdVisita).Count() + 1;
                    visita.EquiposVisita.Add(Equipo);
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No se encontró la visita");
            }
        }

        //Reporte ejecución visitas / Consulta detallada de una visita
        public Visitas ConsultarVisita(int IdVisita)
        {
            Visitas visita = null;
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                visita = ctx.Visitas.Where(v => v.IdVisita == IdVisita).FirstOrDefault();
                if (visita != null)
                {
                    visita.EquiposVisita.ToList();
                    visita.FotosVisita.ToList();
                    visita.FormatosVisita.ToList();
                    if (visita.IdSolicitudProgramacion != null)
                        ctx.Entry(visita).Reference(r => r.SolicitudesProgramacionVisitas).Load();
                    ctx.Entry(visita).Reference(r => r.Clientes).Load();                    
                    ctx.Entry(visita).Reference(r => r.Zonas).Load();
                    ctx.Entry(visita).Reference(r => r.Ciudades).Load();
                    ctx.Entry(visita).Reference(r => r.Usuarios).Load();
                    ctx.Entry(visita).Reference(r => r.EstadosVisita).Load();                    
                    ctx.Entry(visita).Reference(r => r.TiposVisita).Load();                    
                }
                else
                    throw new Exception($"No existe visita con ID {IdVisita}");
            }
            return visita;
        }

        //Consulta de visitas (Varios parámetros)
        public List<uspConsultarVisitas_Result> ConsultaVisitas(DateTime FechaInicial, DateTime FechaFinal, string NumeroIdentificacionCliente, int IdInspector, string IdEstadoVisita)
        {
            List<uspConsultarVisitas_Result> res = new List<uspConsultarVisitas_Result>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                FechaFinal = FechaFinal.AddDays(1);
                res = ctx.uspConsultarVisitas(FechaInicial, FechaFinal, NumeroIdentificacionCliente, IdInspector, IdEstadoVisita).ToList();
            }
            return res;
        }
    
        public List<EstadosVisita> ObtenerEstadosVisita()
        {
            List<EstadosVisita> res = new List<EstadosVisita>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.EstadosVisita.ToList();
            }
            return res;
        }
    }
}