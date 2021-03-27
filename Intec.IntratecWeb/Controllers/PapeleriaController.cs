using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intec.IntratecWeb.Controllers
{
    public class PapeleriaController : Controller
    {
        // GET: Papeleria
        public ActionResult Administracion()
        {
            return View();
        }
        
        public ActionResult Administrar(string iF)
        {
            return View();
        }
        
        public ActionResult AcepRechAnul()
        {
            return View();
        }
    }
}