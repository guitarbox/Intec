using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intec.IntratecWeb.Controllers
{
    public class UsuariosController : Controller
    {        
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult ModificarContrasena(string token)
        {
            ViewBag.token = token;
            return View();
        }
        public ActionResult RecuperarContrasena()
        {
            return View();
        }
    }
}