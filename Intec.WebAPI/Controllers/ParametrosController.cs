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
    public class ParametrosController : ApiController
    {
        [HttpGet]
        public List<Intec.BL.DTO.Parametros> Get()
        {
            return Intec.BL.BE.ParametrosBE.Parametros;
        }
        
        [HttpGet]     
        public Intec.BL.DTO.Parametros Get(int id)
        {
            return Intec.BL.BE.ParametrosBE.Parametros.Where(p=>p.IdParametro==id).FirstOrDefault();
        }
        
        //[HttpPost]
        ////Create
        //[HttpPut]
        ////update
    }
}
