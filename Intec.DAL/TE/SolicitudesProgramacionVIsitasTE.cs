﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class SolicitudesProgramacionVIsitasTE
    {
        public List<SolicitudesProgramacionVisitas> ConsultarSolicitudes()
        {
            List<SolicitudesProgramacionVisitas> res = new List<SolicitudesProgramacionVisitas>();
            //using (var ctx = new DB_A66D31_intratecPrbEntities1())
            //{
            //    res = ctx.SolicitudesProgramacionVisitas.Where(s=>s.IdPais == 1).ToList();
            //    foreach (SolicitudesProgramacionVisitas sol in res)
            //    {
            //        ctx.Entry(sol).Reference(r => r.Paises).Load();
            //    }
            //}

            return res;
        }

        public void CrearSolicitud(SolicitudesProgramacionVisitas Solicitud)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Solicitud.FechaCreacion = DateTime.Now;
                ctx.SolicitudesProgramacionVisitas.Add(Solicitud);
                ctx.SaveChanges();
            }
        }
    }
}
