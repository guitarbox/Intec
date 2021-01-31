using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.BL.BE
{
    public class ClientesBE : _beDefault
    {
        #region Clientes

        //Crear

        public void CrearCliente(DTO.Clientes ClienteCrear)
        {
            new DAL.TE.ClientesTE().CrearCliente(MapperConfig.Config.MapperClientes.Map<DAL.Clientes>(ClienteCrear));
        }

        //Obtener

        public List<DAL.uspConsultaGralCliente_Result> ConsultaGralClientes(string NumeroIdentificacion, string Nombres, string Direccion, string NroTelefonico, bool TieneVisitaProgramada)
        {
            return new DAL.TE.ClientesTE().ConsultaGralClientes(NumeroIdentificacion, Nombres, Direccion, NroTelefonico, TieneVisitaProgramada);
        }

        public DTO.Clientes ConsultaDetalladaClientes(int IdCliente)
        {
            return MapperConfig.Config.MapperClientes.Map<DTO.Clientes>(new DAL.TE.ClientesTE().ConsultaDetalladaClientes(IdCliente));
        }

        //Editar

        public void EditarClientes(DTO.Clientes Cliente, int IdUsuariomodificacion)
        {
            new DAL.TE.ClientesTE().EditarClientes(MapperConfig.Config.MapperClientes.Map<DAL.Clientes>(Cliente), IdUsuariomodificacion);
        }

        //Eliminar no hay


        #endregion

        #region Propiedades

        //Crear

        public void CrearPropiedad(DTO.Propiedades Propiedad)
        {
            new DAL.TE.ClientesTE().CrearPropiedad(MapperConfig.Config.MapperClientes.Map<DAL.Propiedades>(Propiedad));
        }

        //Obtener

        public DTO.Propiedades ConsultaDetalladaPropiedad(int IdPropiedad)
        {
            return MapperConfig.Config.MapperClientes.Map<DTO.Propiedades>(new DAL.TE.ClientesTE().ConsultaDetalladaPropiedad(IdPropiedad));
        }

        //Editar

        public void EditarPropiedad(DTO.Propiedades Propiedad, int IdUsuariomodificacion)
        {
            new DAL.TE.ClientesTE().EditarPropiedad(MapperConfig.Config.MapperClientes.Map<DAL.Propiedades>(Propiedad), IdUsuariomodificacion);
        }

        //Eliminar

        public void EliminarPropiedad(int IdPropiedad)
        {
            new DAL.TE.ClientesTE().EliminarPropiedad(IdPropiedad);
        }

        #endregion
    }
}
