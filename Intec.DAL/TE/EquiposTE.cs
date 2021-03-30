using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common.EntitySql;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class EquiposTE
    {
        //1. Consultar Equipos
        public List<Equipos> ObtenerEquipos(int IdMarca, int IdTipoEquipo, string filtro)
        {
            List<Equipos> res = new List<Equipos>();
            using(var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Equipos.Where(e=>(e.SerieIDInterno.Contains(filtro) || e.Modelo.Contains(filtro)) && (IdMarca == -1 || e.IdMarcaEquipo == IdMarca) && (IdTipoEquipo == -1 || e.IdTipoEquipo == IdTipoEquipo)).ToList();
                foreach(Equipos e in res)
                {
                    ctx.Entry(e).Reference(r => r.MarcasEquipos).Load();
                    ctx.Entry(e).Reference(r => r.TiposEquipo).Load();
                }
            }
            return res;
        }

        //1.1 ObtenerUnEquipo
        public Equipos ObtenerEquipo(int IdEquipo)
        {
            Equipos res = new Equipos();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Equipos.Where(e => e.IdEquipo == IdEquipo).FirstOrDefault();
                res.CalibracionesEquipos.ToList();
                res.TramitesEquipo.ToList();
                res.VerificacionesLabEquipos.ToList();
                ctx.Entry(res).Reference(r => r.MarcasEquipos).Load();
                ctx.Entry(res).Reference(r => r.TiposEquipo).Load();
                res.UsuariosEquipos.ToList();
            }
            return res;
        }

        //2. Agregar Equipo
        public void AgregarEquipo(Equipos Equipo)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                int us = ctx.Equipos.Where(u => u.SerieIDInterno == Equipo.SerieIDInterno).ToList().Count;
                if (us == 0)
                {
                    Equipo.FechaCreacion = DateTime.Now;
                    ctx.Equipos.Add(Equipo);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"Ya existe un equipo con Id interno {Equipo.SerieIDInterno}");
                }
                    
            }
        }

        //3. Eliminar Equipo
        public void EliminarEquipo(int IdEquipo)
        {
            using(var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                if (ctx.UsuariosEquipos.Where(ue => ue.IdEquipo == IdEquipo).FirstOrDefault() == null)
                {
                    ctx.Equipos.Where(e => e.IdEquipo == IdEquipo).FirstOrDefault().Activo = false;
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No se puede eliminar el equipo, está asignado a un inspector.");
            }
        }

        //4. Tramitar Equipo a Inspector
        public void TramitarEquipoInspector(int IdEquipo, int? IdInspector, int IdUsuarioTramita, string Tramite, string Observaciones)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                DateTime now = DateTime.Now;
                int sec = 0;
                try { sec = ctx.TramitesEquipo.Where(t => t.IdEquipo == IdEquipo).Count(); } catch { }
                sec += 1;

                UsuariosEquipos ue;
                switch (Tramite) {
                    case "ASIGNACION": 
                        ctx.UsuariosEquipos.Add(new UsuariosEquipos() { IdEquipo = IdEquipo, IdInspector = IdInspector.Value, IdUsuarioAsigna = IdUsuarioTramita, FechaAsignacion = now, Estado = "P" }); 
                        break;
                    case "ACEP_ASIGNACION":
                        ue = ctx.UsuariosEquipos.Where(e=>e.IdEquipo == IdEquipo && e.IdInspector == IdInspector && e.Estado == "P").FirstOrDefault(); 
                        if(ue != null) ue.Estado = "A";
                        else throw new Exception("No se puede aceptar la asignación.");
                        break;
                    case "DEVOLUCION":
                        ue = ctx.UsuariosEquipos.Where(e => e.IdEquipo == IdEquipo && e.IdInspector == IdInspector && e.Estado == "A").FirstOrDefault();
                        if (ue != null) ue.Estado = "D"; 
                        else throw new Exception("No se puede devolver el equipo.");
                        break;
                    case "ACEP_DEVOLUCION":
                        ue = ctx.UsuariosEquipos.Where(e => e.IdEquipo == IdEquipo && e.IdInspector == IdInspector && e.Estado == "D").FirstOrDefault();
                        if (ue != null) ctx.UsuariosEquipos.Remove(ue);
                        else throw new Exception("No se puede aceptar la devolución del equipo.");
                        break;
                    case "RECHAZO":
                        ue = ctx.UsuariosEquipos.Where(e => e.IdEquipo == IdEquipo && e.IdInspector == IdInspector && e.Estado == "P").FirstOrDefault();
                        if (ue != null) ctx.UsuariosEquipos.Remove(ue);
                        else throw new Exception("No se puede rechazar la asignación del equipo.");
                        break;
                    case "ENV_CALIBRACION":
                        if (ctx.UsuariosEquipos.Where(e => e.IdEquipo == IdEquipo).FirstOrDefault() != null) throw new Exception("No se puede enviar a Calibración el equipo. Está asignado");
                        break;
                    case "REC_CALIBRACION":
                        if (!ctx.TramitesEquipo.Where(t => t.IdEquipo == IdEquipo).OrderByDescending(d => d.Secuencia).FirstOrDefault().Tramite.Equals("ENV_CALIBRACION"))
                            throw new Exception("No se puede recibir ya que no fue enviada a Calibración.");
                        break;
                }

                ctx.TramitesEquipo.Add(new TramitesEquipo()
                {
                    IdEquipo = IdEquipo,
                    IdInspector = IdInspector,
                    FechaCreacion = now,
                    IdUsuarioCreacion = IdUsuarioTramita,
                    Observaciones = Observaciones,
                    Secuencia = sec,
                    Tramite = Tramite
                });

                ctx.SaveChanges();
            }
        }

        //5. Ingresar Verificaciones LAB
        public void IngresarVerificacionLAB(VerificacionesLabEquipos Verificacion)
        {
            using(var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                int sec = 0;
                try { sec = ctx.VerificacionesLabEquipos.Where(v=>v.IdEquipo == Verificacion.IdEquipo).Count(); } catch { }
                sec += 1;

                Verificacion.FechaCreacion = DateTime.Now;
                Verificacion.Secuencia = sec;
                ctx.VerificacionesLabEquipos.Add(Verificacion);
                ctx.SaveChanges();
            }
        }

        //6. Ingresar Calibraciones Equipos
        public void IngresarCalibracionEq(CalibracionesEquipos Calibracion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                int sec = 0;
                try { sec = ctx.CalibracionesEquipos.Where(v => v.IdEquipo == Calibracion.IdEquipo).Count(); } catch { }
                sec += 1;

                Calibracion.FechaCreacion = DateTime.Now;
                Calibracion.Secuencia = sec;
                ctx.CalibracionesEquipos.Add(Calibracion);
                ctx.SaveChanges();
            }
        }

        public void ActualizarEquipo(Equipos equipos, int idUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Equipos equipoAModificar = ctx.Equipos.Where(e => e.IdEquipo == equipos.IdEquipo).FirstOrDefault();
                equipoAModificar.Activo = equipos.Activo;
                equipoAModificar.Area = equipos.Area;
                equipoAModificar.Calibrado = equipos.Calibrado;
                equipoAModificar.FechaProximaCalibracion = equipos.FechaProximaCalibracion;
                equipoAModificar.FechaProximoMantenimiento = equipos.FechaProximoMantenimiento;
                equipoAModificar.IdMarcaEquipo = equipos.IdMarcaEquipo;
                equipoAModificar.IdTipoEquipo = equipos.IdTipoEquipo;
                equipoAModificar.Modelo = equipos.Modelo;
                equipoAModificar.PeriodoCalibracion = equipos.PeriodoCalibracion;
                equipoAModificar.PeriodoVerificacion = equipos.PeriodoVerificacion;
                equipoAModificar.SerieIDInterno = equipos.SerieIDInterno;
                equipoAModificar.Tolerancia = equipos.Tolerancia;
                equipoAModificar.IdTipoVisitaAplica = equipos.IdTipoVisitaAplica;
                
                equipoAModificar.IdUsuarioModificacion = idUsuarioModificacion;
                equipoAModificar.FechaModificacion = DateTime.Now;
                ctx.SaveChanges();
            }
        }

        public List<UsuariosEquipos> ObtenerEquiposUsuario(int IdInspector)
        {
            List<UsuariosEquipos> res = new List<UsuariosEquipos>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.UsuariosEquipos.Where(u => u.IdInspector == IdInspector).ToList();
                foreach (UsuariosEquipos ue in res)
                {
                    ctx.Entry(ue).Reference(r => r.Equipos).Load();
                    ctx.Entry(ue).Reference(r => r.Usuarios).Load();
                }
            }
            return res;
        }

        /*Indica si un equipo está pendiente de trámite por el admin*/
        public bool PendTramiteAdmin(int IdEquipo)
        {
            bool res = false;
            using(var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                TramitesEquipo t = ctx.TramitesEquipo.Where(e => e.IdEquipo == IdEquipo).OrderByDescending(d => d.Secuencia).FirstOrDefault();
                if(t != null)
                {
                    res = t.Tramite.Equals("DEVOLUCION");
                }
            }
            return res;
        }
    }
}
