using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intec.IntratecWeb.Controllers
{
    public class AdministracionController : Controller
    {
        public ActionResult Parametros()
        {
            return View();
        }
        
        public ActionResult Paises()
        {
            return View();
        }
    }
}