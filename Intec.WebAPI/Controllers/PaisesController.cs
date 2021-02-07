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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PaisesController : DefaultController
    {
        // GET: api/Paises
        public List<Paises> Get()
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerPaises();
        }

        // GET: api/Paises/5
        public Paises Get(int id)
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerPais(id);
        }

        // POST: api/Paises
        public JObject Post([FromBody]Intec.BL.DTO.Paises Pais)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().CrearPais(Pais);
            }
            catch (Exception ex) {
                error = true;
                msgError = ex.Message;
            }

            SetErrorResponse(error);
            SetMsgErrorResponse(msgError);

            return response;
        }

        //// PUT: api/Paises/5
        public JObject Put(int id,[FromBody] JObject PaisEditarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EditarPais(PaisEditarJO ["Pais"].ToObject<Intec.BL.DTO.Paises>(), int.Parse(PaisEditarJO ["IdUsuarioModificacion"].ToString()));
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

        //// DELETE: api/Paises/5
        //public void Delete(int id)
        //{
        //}
    }
}
