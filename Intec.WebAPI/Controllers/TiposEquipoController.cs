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
    public class TiposEquipoController : DefaultController
    {
        // GET: api/TiposEquipo
        public List<TiposEquipo> Get()
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerTiposEquipos();
        }

        //OK

        // GET: api/TiposEquipo/5
        public TiposEquipo Get(int id)
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerTipoEquipo(id);
        }

        //OK

        // POST: api/TiposEquipo
        public JObject Post([FromBody] Intec.BL.DTO.TiposEquipo TipoEquipo)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().CrearTipoEquipo(TipoEquipo);
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

        // PUT: api/TiposEquipo/5
        public JObject Put(int id, [FromBody] JObject TipoEquipoEditarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EditarTipoEquipo(TipoEquipoEditarJO["TipoEquipo"].ToObject<Intec.BL.DTO.TiposEquipo>(), int.Parse(TipoEquipoEditarJO["IdUsuarioModificacion"].ToString()));
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

        // DELETE: api/TiposEquipo/5
        public JObject Delete(int id, [FromBody] JObject TipoEquipoEliminarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EliminarTipoEquipo(int.Parse(TipoEquipoEliminarJO["IdTipoEquipo"].ToString()), int.Parse(TipoEquipoEliminarJO["IdUsuarioModificacion"].ToString()));
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

        //
    }
}
