using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intec.IntratecWeb.Controllers
{
    public class EquiposController : Controller
    {
        // GET: Equipos
        public ActionResult Administracion()
        {
            return View();
        }
        
        public ActionResult Administrar(int ie)
        {
            return View();
        }
        
        public ActionResult AcepDevRechazo()
        {
            return View();
        }
    }
}