using Intec.BL.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Intec.WebApi.Controllers
{
    public class ClientesController : DefaultController
    {
        //GET: api/Clientes
        public List<Intec.BL.DTO.uspConsultaGralCliente_Result> Get(JObject ClienteConsultarJO)
        {
            return new Intec.BL.BE.ClientesBE().ConsultaGralClientes(ClienteConsultarJO["NumeroIdentificacion"].ToString(),
                ClienteConsultarJO["Nombres"].ToString(),
                ClienteConsultarJO["Direccion"].ToString(),
                ClienteConsultarJO["NroTelefonico"].ToString(),
                Boolean.Parse(ClienteConsultarJO["TieneVisitaProgramada"].ToString()));
        }

        //GET: api/Clientes/5
        public Clientes Get(int id)
        {
            return new Intec.BL.BE.ClientesBE().ConsultaDetalladaClientes(id);
        }

        //OK

        // POST: api/Clientes
        public JObject Post([FromBody] Intec.BL.DTO.Clientes ClienteCrear)
        {
            try
            {
                new Intec.BL.BE.ClientesBE().CrearCliente(ClienteCrear);
            }
            catch (Exception ex)
            {
                error = true;
                msgError = ex.Message;
            }

            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);

            return response;
        }

        //OK

        // PUT: api/Clientes/5
        public JObject Put(int id, [FromBody] JObject ClienteEditarJO)
        {
            try
            {
                new Intec.BL.BE.ClientesBE().EditarClientes(ClienteEditarJO["Cliente"].ToObject<Intec.BL.DTO.Clientes>(), int.Parse(ClienteEditarJO["IdUsuarioModificacion"].ToString()));
            }
            catch (Exception ex)
            {
                error = true;
                msgError = ex.Message;
            }

            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);

            return response;

        }

        //OK

        // DELETE: No hay Eliminar
        
    }
}
