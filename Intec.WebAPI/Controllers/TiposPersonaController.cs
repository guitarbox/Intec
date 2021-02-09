using Intec.BL.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Intec.WebApi.Controllers
{
    public class TiposPersonaController : DefaultController
    {
        // GET: api/TiposPersona
        public List<TiposPersona> Get()
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerTiposPersona();
        }

        // GET: api/TiposPersona/5
        public TiposPersona Get(int id)
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerTipoPersona(id);
        }

        //OK

        // POST: api/TiposPersona
        public JObject Post([FromBody] Intec.BL.DTO.TiposPersona TipoPersona)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().CrearTipoPersona(TipoPersona);
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

        // PUT: api/TiposPersona/5
        public JObject Put(int id, [FromBody] JObject TipoPersonaEditarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EditarTipoPersona(TipoPersonaEditarJO["TipoPersona"].ToObject<Intec.BL.DTO.TiposPersona>(), int.Parse(TipoPersonaEditarJO["IdUsuarioModificacion"].ToString()));
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

        // DELETE: api/TiposPersona/5
        public JObject Delete(int id, [FromBody] JObject TipoPersonaEliminarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EliminarTipoPersona(int.Parse(TipoPersonaEliminarJO["IdTipoPersona"].ToString()), int.Parse(TipoPersonaEliminarJO["IdUsuarioModificacion"].ToString()));
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
    }
}
