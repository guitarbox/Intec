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
        //ZONAS => Todo lo que tenga que ver con zonas
        //CRUD ZONAS
        public List<Zonas> ObtenerZonas()
        {
            List<Zonas> res = new List<Zonas>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Zonas.ToList();
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
        public void AsignarZonaInspector(int IdZona, int IdInspector)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Zonas zona = ctx.Zonas.Where(z => z.IdZona == IdZona).FirstOrDefault();
                if (zona != null)
                {
                    zona.IdInspector = IdInspector;
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No existe la zona");
            }
        }

        //Reporte zonas y presencia en visitas
        //TODO

        //VISITAS => Todo lo que tenga que ver con visitas
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
                    throw new Exception("No se encontró la visita");
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
                    visita.FotosVisita.Add(Foto);
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
                    visita.FormatosVisita.Add(Formato);
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
                    visita.EquiposVisita.Add(Equipo);
                }
                else
                    throw new Exception("No se encontró la visita");
            }
        }

        //Reporte ejecución visitas / Consultar una visita
        //TODO

        //Consulta de visitas (Varios parámetros)
        //TODO
    }
}