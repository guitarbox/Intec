using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class PapeleriaTE
    {
        //CRUD Formatos, pero el delete no debe permitir eliminar formatos que hayan sido asignados,
        public void CrearFormato(Formatos FormatoCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                FormatoCrear.FechaCreacion = DateTime.Now;
                ctx.Formatos.Add(FormatoCrear);
                ctx.SaveChanges();
            }
        }

        public void EditarFormato(Formatos Formato, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Formatos FormatoModificar = ctx.Formatos.Where(c => c.IdFormato == Formato.IdFormato).FirstOrDefault();

                FormatoModificar.Formato = Formato.Formato;
                FormatoModificar.Mascara = Formato.Mascara;
                FormatoModificar.Activo = Formato.Activo;

                FormatoModificar.FechaModificacion = DateTime.Now;
                FormatoModificar.IdUsuarioModificacion = IdUsuarioModificacion;

                ctx.SaveChanges();
            }



        }

        public List<Formatos> ConsultarFormatos()
        {
            List<Formatos> res = new List<Formatos>();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Formatos.ToList();
            }

            return res;

        }

        public Formatos ConsultarFormatos(int IdFormato)
        {
            Formatos res = new Formatos();

            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Formatos.Where(f=>f.IdFormato == IdFormato).FirstOrDefault();
            }

            return res;
        }

        public void EliminarFormato(int IdFormato)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Formatos formatoAEliminar = ctx.Formatos.Where(f => f.IdFormato == IdFormato).FirstOrDefault();
                if (formatoAEliminar.ConsecutivosInspectores.Count == 0)
                {
                    ctx.Formatos.Remove(formatoAEliminar);
                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No se puede eliminar el formato, tiene movimientos.");
            }
        }
        
        //Kárdex, solo tendrá insert
    }
}
