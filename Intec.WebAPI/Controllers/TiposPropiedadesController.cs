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
    public class TiposPropiedadesController : DefaultController
    {
        // GET: api/TiposPropiedades
        public List<TiposPropiedades> Get()
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerTiposPropiedades();
        }

        // GET: api/TiposPropiedades/5
        public TiposPropiedades Get(int id)
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerTipoPropiedad(id);
        }

        // OK

        // POST: api/TiposPropiedades
        public JObject Post([FromBody] Intec.BL.DTO.TiposPropiedades TipoPropiedad)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().CrearTipoPropiedad(TipoPropiedad);
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

        // PUT: api/TiposPropiedades/5
        public JObject Put(int id, [FromBody] JObject TipoPropiedadEditarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EditarTipoPropiedad(TipoPropiedadEditarJO["TipoPropiedad"].ToObject<Intec.BL.DTO.TiposPropiedades>(), int.Parse(TipoPropiedadEditarJO["IdUsuarioModificacion"].ToString()));
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

        // DELETE: api/TiposPropiedades/5
        public JObject Delete(int id, [FromBody] JObject TipoPropiedadEliminarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EliminarTipoPropiedad(int.Parse(TipoPropiedadEliminarJO["IdTipoPropiedad"].ToString()), int.Parse(TipoPropiedadEliminarJO["IdUsuarioModificacion"].ToString()));
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
