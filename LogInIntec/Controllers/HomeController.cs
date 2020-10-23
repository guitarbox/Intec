using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LogInIntec.Controllers
{
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult ObtenerUsuario(string User, string Pass)
        {
            List<Intec.BL.DTO.Usuario> Usuario = new List<Intec.BL.DTO.Usuario>();
            bool error = false;
            string errorMessage = string.Empty;
            try
            {
                Usuario = new Intec.BL.BE.UsuarioBE().ObtenerUsuario(User, Pass);
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.Message;
            }

            SetDicRta(Usuario, Usuario.Count, error, errorMessage, Intec.BL.BE.UsuarioBE._duration);
            return Json(ansDic);
        }

    }
}