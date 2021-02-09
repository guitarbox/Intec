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
    public class CiudadesController : DefaultController
    {
        // GET: api/Ciudades
        //public List<Ciudades> Get(string id)
        //{
        //    return new Intec.BL.BE.AdministracionBE().ObtenerCiudades(id);
        //}

        // GET: api/Ciudades/5
        public Ciudades Get(string id)
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerCiudad(id);
        }

        // POST: api/Ciudades
        public JObject Post([FromBody] Intec.BL.DTO.Ciudades Ciudad)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().CrearCiudad(Ciudad);
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

        // PUT: api/Ciudades/5
        public JObject Put(int id, [FromBody] JObject CiudadEditarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EditarCiudad(CiudadEditarJO["Ciudad"].ToObject<Intec.BL.DTO.Ciudades>(), int.Parse(CiudadEditarJO["IdUsuarioModificacion"].ToString()));
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

        // DELETE: api/Ciudades/5
        public JObject Delete(int id, [FromBody] JObject CiudadEliminarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EliminarCiudad((CiudadEliminarJO["IdCiudad"].ToString()), int.Parse(CiudadEliminarJO["IdUsuarioModificacion"].ToString()));
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
    }
}
