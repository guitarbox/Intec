using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Intec.DAL.TE
{
    public class ClientesTE
    {
        public List<uspConsultaGralCliente_Result> ConsultaGralClientes(string NumeroIdentificacion, string Nombres, string Direccion, string NroTelefonico, bool TieneVisitaProgramada)
        {
            List<uspConsultaGralCliente_Result> res = new List<uspConsultaGralCliente_Result>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.uspConsultaGralCliente(NumeroIdentificacion, Nombres, Direccion, NroTelefonico, TieneVisitaProgramada).ToList();
            }
            return res;
        }

        public List<Clientes> ConsultaDetalladaClientes(int IdCliente)
        {
            List<Clientes> res = new List<Clientes>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Clientes.Where(c => c.IdCliente == IdCliente).ToList();
            }
            return res;
        }

        public void EditarClientes()
        {
            
        }

        public void CrearPropiedad(Propiedades PropiedadCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                int us = ctx.Propiedades.Where(u => u.IdPropiedades.Equals(PropiedadCrear.IdPropiedades)).ToList().Count;
                if (us == 0)
                {
                    PropiedadCrear.FechaCreacion = DateTime.Now;
                    ctx.Propiedades.Add(PropiedadCrear);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"Ya existe una Propiedad con ID {PropiedadCrear.IdPropiedades}");
                }

            }
        }

        public void EditarPropiedad()
        {

        }

        public void EliminarPropiedad(Propiedades PropiedadEliminar)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                int us = ctx.Propiedades.Where(u => u.IdPropiedades.Equals(PropiedadEliminar.IdPropiedades)).ToList().Count;
                if (us == 1)
                {
                    PropiedadEliminar.FechaModificacion = DateTime.Now;
                    ctx.Propiedades.Remove(PropiedadEliminar);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"No existe una Propiedad con ID {PropiedadEliminar.IdPropiedades}");
                }

            }
        }

        public void CrearCliente(Clientes ClienteCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                int us = ctx.Clientes.Where(u => u.NumeroIdentificacion.Equals(ClienteCrear.NumeroIdentificacion)).ToList().Count;
                if (us == 0)
                {
                    ClienteCrear.FechaCreacion = DateTime.Now;
                    ctx.Clientes.Add(ClienteCrear);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"Ya existe un cliente con Número de Identificación {ClienteCrear.NumeroIdentificacion}");
                }

            }
        }
    }
}
