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
    public class TiposIdentificacionController : DefaultController
    {
        // GET: api/TiposIdentificacion
        public List<TiposIdentificacion> Get()
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerTiposIdentificacion();
        }

        //Resultado OK

        // GET: api/TiposIdentificacion/5
        public TiposIdentificacion Get(int id)
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerTipoIdentificacion(id);
        }

        //Resultado OK

        // POST: api/TiposIdentificacion
        public JObject Post([FromBody] Intec.BL.DTO.TiposIdentificacion TipoIdentificacion)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().CrearTipoIdentificacion(TipoIdentificacion);
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

        //Resultado OK

        // PUT: api/TiposIdentificacion/5
        public JObject Put(int id, [FromBody] JObject TipoIdentificacionEditarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EditarTipoIdentificacion(TipoIdentificacionEditarJO["TipoIdentificacion"].ToObject<Intec.BL.DTO.TiposIdentificacion>(), int.Parse(TipoIdentificacionEditarJO["IdUsuarioModificacion"].ToString()));
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

        //Resultado OK

        // DELETE: api/TiposIdentificacion/5
        public JObject Delete(int id, [FromBody] JObject TipoIdentificacionEliminarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EliminarTipoIdentificacion(int.Parse(TipoIdentificacionEliminarJO["IdTipoIdentificacion"].ToString()), int.Parse(TipoIdentificacionEliminarJO["IdUsuarioModificacion"].ToString()));
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

        //Resultado OK, URL
    }
}
