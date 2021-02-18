using Intec.BL.DTO;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Intec.WebApi.Controllers
{
    public class UsosPropiedadesController : DefaultController
    {
        public List<Intec.BL.DTO.UsosPropiedades> Get()
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerUsosPropiedades();
        }

        // GET: api/UsosPropiedades/5
        public UsosPropiedades Get(int id)
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerUsoPropiedad(id);
        }

        //OK

        // POST: api/UsosPropiedades
        public JObject Post([FromBody] Intec.BL.DTO.UsosPropiedades UsoPropiedad)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().CrearUsoPropiedad(UsoPropiedad);
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

        // PUT: api/UsosPropiedades/5
        public JObject Put(int id, [FromBody] JObject UsoPropiedadEditarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EditarUsoPropiedad(UsoPropiedadEditarJO["UsoPropiedad"].ToObject<Intec.BL.DTO.UsosPropiedades>(), int.Parse(UsoPropiedadEditarJO["IdUsuarioModificacion"].ToString()));
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

        // DELETE: api/UsosPropiedades/5
        public JObject Delete(int id, [FromBody] JObject UsoPropiedadEliminarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EliminarUsoPropiedad(int.Parse(UsoPropiedadEliminarJO["IdUsoPropiedad"].ToString()), int.Parse(UsoPropiedadEliminarJO["IdUsuarioModificacion"].ToString()));
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
