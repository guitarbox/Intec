using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class Administracion
    {
        public List<Paises> ObtenerPaises()
        {
            List<Paises> res = new List<Paises>();
            using(var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Paises.ToList();
            }
            return res;
        }

        public List<Departamentos> ObtenerDepartamentos(int IdPais)
        {
            List<Departamentos> res = new List<Departamentos>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Departamentos.Where(d => d.IdPais == IdPais).ToList();
            }
            return res;
        }

        public List<Ciudades> ObtenerCiudades(string IdDepartamento)
        {
            List<Ciudades> res = new List<Ciudades>();
            using(var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Ciudades.Where(c => c.IdDepartamento.Equals(IdDepartamento)).ToList();
            }
            return res;
        }
    }
}
