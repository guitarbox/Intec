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
    public class DepartamentosController : DefaultController
    {
        //// GET: api/Departamentos
        //public List<Departamentos> Get(int id)
        //{
        //    return new Intec.BL.BE.AdministracionBE().ObtenerDepartamentos(id);
        //}


        // GET: api/Departamentos/5 
        //TODO
        public Departamentos Get(string id)
        {
            return new Intec.BL.BE.AdministracionBE().ObtenerDepartamento(id);
        }


        // POST: api/Departamentos
        public JObject Post([FromBody] Intec.BL.DTO.Departamentos Departamento)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().CrearDepartamento(Departamento);
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

        //Resultado OK, me permite generar IdPais 2

        //// PUT: api/Departamentos/5
        public JObject Put(int id, [FromBody] JObject DepartamentoEditarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EditarDepartamento(DepartamentoEditarJO["Departamento"].ToObject<Intec.BL.DTO.Departamentos>(), int.Parse(DepartamentoEditarJO["IdUsuarioModificacion"].ToString()));
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

        //Resultado OK, Me permite cambiar otro registro al de la URL

        //// DELETE: api/Departamentos/5
        public JObject Delete(int id, [FromBody] JObject DepartamentoEliminarJO)
        {
            try
            {
                new Intec.BL.BE.AdministracionBE().EliminarDepartamento((DepartamentoEliminarJO["IdDepartamento"].ToString()), int.Parse(DepartamentoEliminarJO["IdUsuarioModificacion"].ToString()));
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
