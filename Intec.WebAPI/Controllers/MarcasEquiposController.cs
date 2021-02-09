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
    public class MarcasEquiposController : DefaultController
    {
        // GET: api/MarcasEquipos
        public List<MarcasEquipos> Get()
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerMarcasEquipos();
        }

        //OK

        // GET: api/MarcasEquipos/5
        public MarcasEquipos Get(int id)
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerMarcaEquipo(id);
        }

        //OK

        // POST: api/MarcasEquipos
        public JObject Post([FromBody] Intec.BL.DTO.MarcasEquipos MarcaEquipo)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().CrearMarcaEquipo(MarcaEquipo);
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

        // PUT: api/MarcasEquipos/5
        public JObject Put(int id, [FromBody] JObject MarcaEquipoEditarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EditarMarcaEquipo(MarcaEquipoEditarJO["MarcaEquipo"].ToObject<Intec.BL.DTO.MarcasEquipos>(), int.Parse(MarcaEquipoEditarJO["IdUsuarioModificacion"].ToString()));
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

        // DELETE: api/MarcasEquipos/5
        public JObject Delete(int id, [FromBody] JObject MarcaEquipoEliminarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EliminarMarcaEquipo(int.Parse(MarcaEquipoEliminarJO["IdMarcaEquipo"].ToString()), int.Parse(MarcaEquipoEliminarJO["IdUsuarioModificacion"].ToString()));
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
