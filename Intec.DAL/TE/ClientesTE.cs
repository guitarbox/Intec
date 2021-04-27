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
        /**
         * 1) 
         */
        public List<uspConsultaGralCliente_Result> ConsultaGralClientes(string NumeroIdentificacion, string Nombres, string Direccion, string NroTelefonico, bool TieneVisitaProgramada)
        {
            List<uspConsultaGralCliente_Result> res = new List<uspConsultaGralCliente_Result>();
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.uspConsultaGralCliente(NumeroIdentificacion, Nombres, Direccion, NroTelefonico, TieneVisitaProgramada).ToList();
            }
            return res;
        }

        /**
         * 2) 
         */
        public Clientes ConsultaDetalladaClientes(int IdCliente, string NumeroIdentificacion)
        {
            Clientes res = null;
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                if(IdCliente != -1)
                    res = ctx.Clientes.Where(c => c.IdCliente == IdCliente).FirstOrDefault();
                else if(!string.IsNullOrEmpty(NumeroIdentificacion))
                    res = ctx.Clientes.Where(c => c.NumeroIdentificacion.Equals(NumeroIdentificacion)).FirstOrDefault();

                if (res != null)
                {
                    res.Propiedades.ToList();
                    foreach(Propiedades prop in res.Propiedades)
                    {
                        ctx.Entry(prop).Reference(r => r.TiposPropiedades).Load();
                        ctx.Entry(prop).Reference(r => r.UsosPropiedades).Load();
                    }
                    res.Visitas.ToList();
                    foreach (Visitas vis in res.Visitas)
                    {
                        ctx.Entry(vis).Reference(r => r.Zonas).Load();
                        ctx.Entry(vis).Reference(r => r.Usuarios).Load();
                    }
                    ctx.Entry(res).Reference(r => r.TiposIdentificacion).Load();
                    ctx.Entry(res).Reference(r => r.TiposPersona).Load();
                }
                else
                {
                    throw new Exception($"No existe cliente con ID {IdCliente}");
                }                
            }
            return res;
        }

        /**
         * 3) 
         */
        public void EditarClientes(Clientes Cliente, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Clientes clienteAModificar = ctx.Clientes.Where(c => c.IdCliente == Cliente.IdCliente).FirstOrDefault();

                if (clienteAModificar != null)
                {
                    clienteAModificar.Nombres = Cliente.Nombres;
                    clienteAModificar.Apellidos = Cliente.Apellidos;
                    clienteAModificar.TelefonoFijo = Cliente.TelefonoFijo;
                    clienteAModificar.TelefonoCel1 = Cliente.TelefonoCel1;
                    clienteAModificar.TelefonoCel2 = Cliente.TelefonoCel2;
                    clienteAModificar.Direccion = Cliente.Direccion;
                    clienteAModificar.IdCiudad = Cliente.IdCiudad;
                    clienteAModificar.IdUso = Cliente.IdUso;
                    clienteAModificar.Foto = Cliente.Foto;
                    clienteAModificar.Email1 = Cliente.Email1;
                    clienteAModificar.Email2 = Cliente.Email2;
                    clienteAModificar.IdTipoPersona = Cliente.IdTipoPersona;
                    clienteAModificar.IdZona = Cliente.IdZona;

                    clienteAModificar.FechaModificacion = DateTime.Now;
                    clienteAModificar.IdUsuarioModificacion = IdUsuarioModificacion;

                    ctx.SaveChanges();
                }
                else
                    throw new Exception("No existe cliente");
            }
        }

        /**
         * 4) 
         */
        public void CrearPropiedad(Propiedades PropiedadCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {                
                PropiedadCrear.FechaCreacion = DateTime.Now;

                ctx.Propiedades.Add(PropiedadCrear);
                ctx.SaveChanges();                
            }
        }

        /**
         * 5) 
         */
        public Propiedades ConsultaPropiedad(int IdPropiedades)
        {
            Propiedades res = null;
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Propiedades.Where(c => c.IdPropiedades == IdPropiedades).FirstOrDefault();
                ctx.Entry(res).Reference(r=>r.TiposPropiedades).Load();
                ctx.Entry(res).Reference(r=>r.UsosPropiedades).Load();
            }
            return res;
        }

        public Propiedades ConsultaDetalladaPropiedad(int IdPropiedades)
        {
            Propiedades res = null;
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                res = ctx.Propiedades.Where(c => c.IdPropiedades == IdPropiedades).FirstOrDefault();
                if (res != null)
                {
                    res.ToString();
                }
                else
                {
                    throw new Exception($"No existe una propiedad con ID {IdPropiedades}");
                }
            }
            return res;
        }
        public void EditarPropiedad(Propiedades propiedad, int IdUsuarioModificacion)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Propiedades PropiedadModificar = ctx.Propiedades.Where(c => c.IdPropiedades == propiedad.IdPropiedades).FirstOrDefault();

                PropiedadModificar.Direccion = propiedad.Direccion;
                PropiedadModificar.IdUso = propiedad.IdUso;
                PropiedadModificar.Telefono = propiedad.Telefono;
                PropiedadModificar.Foto = propiedad.Foto;
                PropiedadModificar.Observaciones = propiedad.Observaciones;
                PropiedadModificar.IdTipoPropiedad = propiedad.IdTipoPropiedad;

                PropiedadModificar.FechaModificacion = DateTime.Now;
                PropiedadModificar.IdUsuarioModificacion = IdUsuarioModificacion;

                ctx.SaveChanges();
            }
        }

        /**
         * 6) 
         */
        public void EliminarPropiedad(int IdPropiedad, int IdUsuarioElimina)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                Propiedades propEliminar = ctx.Propiedades.Where(u => u.IdPropiedades == IdPropiedad).FirstOrDefault();
                if (propEliminar != null)
                {
                    if (propEliminar.Visitas.Count() == 0)
                    {
                        ctx.Log.Add(new Log()
                        {
                            IdUsuario = IdUsuarioElimina,
                            FechaLog = DateTime.Now,
                            Observacion = $"Usuario {IdUsuarioElimina} elimina la propiedad: {Common.Util.ObjectToJson(new {propEliminar.IdPropiedades, propEliminar.Direccion, propEliminar.Telefono, propEliminar.IdUso, propEliminar.IdTipoPropiedad, propEliminar.IdCliente, propEliminar.IdUsuarioCreacion, propEliminar.FechaCreacion, propEliminar.IdUsuarioModificacion, propEliminar.FechaModificacion})}"
                        });
                        ctx.SaveChanges();
                        ctx.Propiedades.Remove(propEliminar);
                        ctx.SaveChanges();
                    }
                    else throw new Exception("No se puede eliminar propiedades a las que se les haya hecho visitas");
                }
                else
                {
                    throw new Exception($"No existe una Propiedad con ID {IdPropiedad}");
                }

            }
        }

        /**
         * 7) 
         */
        public void CrearCliente(Clientes ClienteCrear)
        {
            using (var ctx = new DB_A66D31_intratecPrbEntities1())
            {
                int us = ctx.Clientes.Where(u => u.IdTipoIdentificacion == ClienteCrear.IdTipoIdentificacion && u.NumeroIdentificacion.Equals(ClienteCrear.NumeroIdentificacion)).ToList().Count;
                if (us == 0)
                {
                    ClienteCrear.FechaCreacion = DateTime.Now;
                    ctx.Clientes.Add(ClienteCrear);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception($"Ya existe un cliente con TipoIdentificación {ClienteCrear.IdTipoIdentificacion} y Número de Identificación {ClienteCrear.NumeroIdentificacion}");
                }

            }
        }
    }
}
