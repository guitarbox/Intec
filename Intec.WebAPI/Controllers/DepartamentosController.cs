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
    public class DepartamentosController : DefaultController
    {
        //// GET: api/Departamentos
        //public List<Departamentos> Get(int id)
        //{
        //    return new Intec.BL.BE.AdministracionBE().ObtenerDepartamentos(id);
        //}

        // GET: api/Departamnetos/5/Ciudades
        [HttpPost]
        [Route("api/Departamentos/ObtenerCiudades")]
        public JObject ObtenerCiudades([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerCiudades(Token["idDepartamento"].ToObject<string>()));
            return response;
        }

        [HttpPost]
        [Route("api/Departamentos/ObtenerCiudadesActivos")]
        public JObject ObtenerCiudadesActivos([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerCiudadesActivos(Token["idDepartamento"].ToObject<string>()));
            return response;
        }

        
        // GET: api/Departamentos/5 
        //TODO
        [HttpPost]
        [Route("api/Departamentos/ObtenerDepartamento")]
        public JObject ObtenerDepartamento([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
                SetDataResponse(new Intec.BL.BE.AdministracionBE().ObtenerDepartamento(Token["idDepartamento"].ToObject<string>()));
            return response;
        }


        // POST: api/Departamentos
        [HttpPost]
        [Route("api/Departamentos/CrearDepartamento")]
        public JObject CrearDepartamento([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().CrearDepartamento(Token["departamento"].ToObject<Intec.BL.DTO.Departamentos>());
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }

                SetErrorResponse(error);
                SetMsgErrorResponse(msgError);
            }
            return response;
        }

        //Resultado OK, me permite generar IdPais 2

        //// PUT: api/Departamentos/5
        [HttpPost]
        [Route("api/Departamentos/ActualizarDepartamento")]
        public JObject ActualizarDepartamento([FromBody] JObject Token)
        {
            bool validToken = ValidateSessionToken(Token["sessionToken"].ToString());
            SetValidTokendResponse(validToken);

            if (validToken)
            {
                try
                {
                    new Intec.BL.BE.AdministracionBE().EditarDepartamento(Token["departamento"].ToObject<Intec.BL.DTO.Departamentos>(), int.Parse(Token["idUsuarioModificacion"].ToString()));
                }
                catch (Exception ex)
                {
                    error = true;
                    msgError = ex.Message;
                }

                SetErrorResponse(error);
                SetMsgErrorResponse(msgError);
            }
            return response;

        }

        //Resultado OK, Me permite cambiar otro registro al de la URL

        //// DELETE: api/Departamentos/5
        [HttpPost]
        [Route("api/Departamentos/EliminarDepartamento")]
        public JObject EliminarDepartamento([FromBody] JObject DepartamentoEliminarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EliminarDepartamento((DepartamentoEliminarJO["idDepartamento"].ToString()), int.Parse(DepartamentoEliminarJO["idUsuarioModificacion"].ToString()));
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

        //Resuktado OK
    }
}
