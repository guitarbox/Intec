﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class PapeleriaTE
    {
        //1. CRUD Formatos, pero el delete no debe permitir eliminar formatos que hayan sido asignados,
        public void CrearFormato(Formatos FormatoCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                FormatoCrear.FechaCreacion = DateTime.Now;
                FormatoCrear.Activo = true;
                ctx.Formatos.Add(FormatoCrear);
                ctx.SaveChanges();
            }
        }

        //2.

        public void EditarFormato(Formatos Formato, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Formatos FormatoModificar = ctx.Formatos.Where(c => c.IdFormato == Formato.IdFormato).FirstOrDefault();

                FormatoModificar.Formato = Formato.Formato;
                FormatoModificar.Separador  = Formato.Separador;
                FormatoModificar.Mascara = Formato.Mascara;
                FormatoModificar.Activo = Formato.Activo;

                FormatoModificar.FechaModificacion = DateTime.Now;
                FormatoModificar.IdUsuarioModificacion = IdUsuarioModificacion;

                ctx.SaveChanges();
            }

        }

        //3.
        public List<Formatos> ConsultarFormatos()
        {
            List<Formatos> res = new List<Formatos>();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Formatos.ToList();
            }

            return res;

        }
    
        //4.
        public Formatos ConsultarFormato(int IdFormato)
        {
            Formatos res = new Formatos();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Formatos.Where(f => f.IdFormato == IdFormato).FirstOrDefault();
                res.ConsecutivosFormatos.ToList();
                res.TramiteConsecutivoFormato.ToList();
            }

            return res;
        }

        //5.
        public void EliminarFormato(int IdFormato)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Formatos formatoAEliminar = ctx.Formatos.Where(f => f.IdFormato == IdFormato).FirstOrDefault();
                if (formatoAEliminar.ConsecutivosFormatos.Count == 0)
                {
                    formatoAEliminar.Activo = false;
                    ctx.SaveChanges();
                }
                else
                    throw new Exception($"No se puede eliminar el formato con ID {IdFormato}, tiene movimientos.");
            }
        }

        //6. Asignación de consecutivos a inspectores
        public void AsignarRangoConsecutivosFormatoInspector(int IdFormato, int IdInspector, int ConsecutivoInicial, int ConsecutivoFinal, int IdUsuarioAsigna)
        {
            string estadoConsecutivo = "P";
            string tramite = "ASIGNACION";

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {                
                //Acá validamos que todos los consecutivos estén disponibles, o sea, que no se los hayan asignado a ningún inspector
                for (int i = ConsecutivoInicial; i <= ConsecutivoFinal; i++)
                {
                    if (ctx.ConsecutivosFormatos.Where(c => c.IdFormato == IdFormato && c.Consecutivo == i && (!c.IdEstadoConsecutivoInspector.Equals("B") && !c.IdEstadoConsecutivoInspector.Equals("R")) ).FirstOrDefault() != null)
                    {
                        throw new Exception($"El consecutivo {i} del formato {IdFormato} ya ha sido asignado a un inspector");
                    }
                }
                
                for (int i = ConsecutivoInicial; i <= ConsecutivoFinal; i++)
                {
                    ConsecutivosFormatos con = ctx.ConsecutivosFormatos.Where(c =>c.IdFormato == IdFormato && c.Consecutivo == i).FirstOrDefault();
                    con.IdInspector = IdInspector;
                    con.IdEstadoConsecutivoInspector = estadoConsecutivo;
                    con.FechaModificacion = DateTime.Now;
                    con.IdUsuarioModificacion = IdUsuarioAsigna;                    

                    int sec = 0;
                    try
                    {
                        sec = ctx.TramiteConsecutivoFormato.Where(t => t.IdFormato == IdFormato && t.Consecutivo == i).Count();
                    }
                    catch { }
                    sec += 1;

                    ctx.TramiteConsecutivoFormato.Add(new TramiteConsecutivoFormato() {
                        IdFormato = IdFormato,
                        IdInspector = IdInspector,
                        Consecutivo = i,
                        Tramite = tramite,
                        FechaCreacion = DateTime.Now,
                        IdUsuarioCreacion = IdUsuarioAsigna, 
                        Secuencia = sec, 
                        Observaciones = "Asignación inicial de Consecutivo"
                    });
                    ctx.SaveChanges();
                }
            }
        }
    
        //7. Ingresar consecutivos a bodega
        public void IngresarConsecutivosFormatoBodega(int IdFormato, int ConsecutivoInicial, int ConsecutivoFinal, int IdUsuarioAsigna)
        {
            string estadoConsecutivo = "B";
            string tramite = "BODEGA";

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {                
                //Acá validamos que todos los consecutivos estén disponibles, o sea, que no se los hayan asignado a ningún inspector
                for (int i = ConsecutivoInicial; i <= ConsecutivoFinal; i++)
                {
                    if (ctx.ConsecutivosFormatos.Where(c => c.IdFormato == IdFormato && c.Consecutivo == i).FirstOrDefault() != null)
                    {
                        throw new Exception($"El consecutivo {i} del formato con Id {IdFormato} ya ha sido ingresado");
                    }
                }
                
                for (int i = ConsecutivoInicial; i <= ConsecutivoFinal; i++)
                {
                    ctx.ConsecutivosFormatos.Add(new ConsecutivosFormatos() { 
                        IdFormato = IdFormato,                        
                        Consecutivo = i,
                        IdEstadoConsecutivoInspector = estadoConsecutivo,
                        FechaCreacion = DateTime.Now,
                        IdUsuarioCreacion = IdUsuarioAsigna
                    });                    

                    int sec = 0;
                    try
                    {
                        sec = ctx.TramiteConsecutivoFormato.Where(t => t.IdFormato == IdFormato && t.Consecutivo == i).Count();
                    }
                    catch { }
                    sec += 1;

                    ctx.TramiteConsecutivoFormato.Add(new TramiteConsecutivoFormato() {
                        IdFormato = IdFormato,                        
                        Consecutivo = i,
                        Tramite = tramite,
                        FechaCreacion = DateTime.Now,
                        IdUsuarioCreacion = IdUsuarioAsigna, 
                        Secuencia = sec, 
                        Observaciones = "Ingreso a bodega del Consecutivo."
                    });
                    ctx.SaveChanges();
                }
            }
        }
    
        //8. Actualizar estado Consecutivo: Aplica para aceptación, rechazo y anulación. Permite actualizar más de un consecutivo.
        public void ActualizarEstadoConsecutivo(int IdFormato, List<int> Consecutivos, string IdEstado, int IdUsuarioActualiza, string Observaciones)
        {            
            string tramite = string.Empty;

            switch (IdEstado)
            {
                case "A": tramite = "ACEPTACION"; break;
                case "R": tramite = "RECHAZO"; break;
                case "X": tramite = "ANULACION"; break;
            }

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                foreach (int i in Consecutivos)                
                {
                    ConsecutivosFormatos con = ctx.ConsecutivosFormatos.Where(c=>c.IdFormato == IdFormato && c.Consecutivo == i).FirstOrDefault();
                    if (con != null)
                    {
                        //Si es rechazo el consecutivo se debe liberar
                        if (!IdEstado.Equals("R"))
                        {
                            con.IdEstadoConsecutivoInspector = IdEstado;
                            con.FechaModificacion = DateTime.Now;
                            con.IdUsuarioModificacion = IdUsuarioActualiza;
                        }
                        else
                        {
                            con.IdInspector = null;
                            con.IdEstadoConsecutivoInspector = IdEstado;
                            con.FechaModificacion = DateTime.Now;
                            con.IdUsuarioModificacion = IdUsuarioActualiza;
                        }

                        int sec = 0;
                        try
                        {
                            sec = ctx.TramiteConsecutivoFormato.Where(t => t.IdFormato == IdFormato && t.Consecutivo == i).Count();
                        }
                        catch { }
                        sec += 1;

                        ctx.TramiteConsecutivoFormato.Add(new TramiteConsecutivoFormato()
                        {
                            IdFormato = IdFormato,
                            IdInspector = IdUsuarioActualiza,
                            Consecutivo = i,
                            Tramite = tramite,
                            FechaCreacion = DateTime.Now,
                            IdUsuarioCreacion = IdUsuarioActualiza,
                            Secuencia = sec,
                            Observaciones = Observaciones
                        });
                        ctx.SaveChanges();                        
                    }
                    else
                        throw new Exception("Consecutivo no asignado aún");
                }
            }
        }

        public List<TramiteConsecutivoFormato> ConsultarTramiteConsecutivoFormato(int IdFormato, int Consecutivo)
        {
            List<TramiteConsecutivoFormato> res = new List<TramiteConsecutivoFormato>();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.TramiteConsecutivoFormato.Where(f => f.IdFormato == IdFormato && f.Consecutivo == Consecutivo).ToList();
                foreach(TramiteConsecutivoFormato t in res)
                {
                    ctx.Entry(t).Reference(r => r.Usuarios).Load();
                }
            }

            return res;
        }
    
        public List<ConsecutivosFormatos> ObtenerConsecutivosUsuario(int IdUsuario)
        {
            List<ConsecutivosFormatos> res = new List<ConsecutivosFormatos>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.ConsecutivosFormatos.Where(c => c.IdInspector == IdUsuario).ToList();
                foreach(ConsecutivosFormatos c in res)
                {
                    ctx.Entry(c).Reference(r => r.Formatos).Load();                    
                }
            }
            return res;
        }

        public void ActualizarEstadoConsecutivosUsuAplica(string idEstado, int idUsuarioActualiza, string observaciones)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                List<int> cons = new List<int>();
                foreach (Formatos formato in ctx.Formatos.ToList()) 
                {
                    cons = ctx.ConsecutivosFormatos.Where(c => c.IdFormato == formato.IdFormato && c.IdInspector == idUsuarioActualiza && c.IdEstadoConsecutivoInspector.Equals(idEstado.Equals("A") || idEstado.Equals("R") ? "P" : "A")).Select(f => f.Consecutivo).ToList();
                    if (cons.Count > 0) 
                    {
                        ActualizarEstadoConsecutivo(formato.IdFormato, cons, idEstado, idUsuarioActualiza, observaciones);
                    }
                }
                ctx.SaveChanges();
            }
        }
    }
}
