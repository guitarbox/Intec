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
    public class PropiedadesController : DefaultController
    {
        // GET: No hay


        // GET: api/Propiedades/5
        public Propiedades Get(int id)
        {
            return new Intec.BL.BE.ClientesBE().ConsultaDetalladaPropiedad(id);
        }

        //OK

        // POST: api/Propiedades
        public JObject Post([FromBody] Intec.BL.DTO.Propiedades PropiedadCrear)
        {
            try
            {
                new Intec.BL.BE.ClientesBE().CrearPropiedad(PropiedadCrear);
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

        // PUT: api/Propiedades/5
        public JObject Put(int id, [FromBody] JObject PropiedadEditarJO)
        {
            try
            {
                new Intec.BL.BE.ClientesBE().EditarPropiedad(PropiedadEditarJO["Propiedad"].ToObject<Intec.BL.DTO.Propiedades>(), int.Parse(PropiedadEditarJO["IdUsuarioModificacion"].ToString()));
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

        // DELETE: api/Propiedades/5
        public void Delete(int id)
        {
            {
                new Intec.BL.BE.ClientesBE().EliminarPropiedad(id);
            }
        }
    }
}
