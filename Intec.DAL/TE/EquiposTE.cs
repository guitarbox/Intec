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
            }
            return res;
        }

        //1.1 ObtenerUnEquipo
        public Equipos ObtenerEquipos(int IdEquipo)
        {
            Equipos res = new Equipos();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Equipos.Where(e => e.IdEquipo == IdEquipo).FirstOrDefault();
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
                    ctx.Equipos.Remove(ctx.Equipos.Where(e => e.IdEquipo == IdEquipo).FirstOrDefault());
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No se puede eliminar el equipo, está asignado a un inspector.");
            }
        }

        //4. Tramitar Equipo a Inspector
        public void TramitarEquipoInspector(int IdEquipo, int IdInspector, int IdUsuarioTramita, string Tramite, string Observaciones)
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
                        ctx.UsuariosEquipos.Add(new UsuariosEquipos() { IdEquipo = IdEquipo, IdInspector = IdInspector, IdUsuarioAsigna = IdUsuarioTramita, FechaAsignacion = now, Estado = "P" }); 
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
                try { ctx.VerificacionesLabEquipos.Where(v=>v.IdEquipo == Verificacion.IdEquipo).Count(); } catch { }
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
                try { ctx.CalibracionesEquipos.Where(v => v.IdEquipo == Calibracion.IdEquipo).Count(); } catch { }
                sec += 1;

                Calibracion.FechaCreacion = DateTime.Now;
                Calibracion.Secuencia = sec;
                ctx.CalibracionesEquipos.Add(Calibracion);
                ctx.SaveChanges();
            }
        }
    }
}
