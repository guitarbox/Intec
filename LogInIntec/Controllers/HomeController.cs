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

        public ActionResult NuevoRegistro()
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
            List<Intec.BL.DTO.Usuarios> Usuario = new List<Intec.BL.DTO.Usuarios>();
            bool error = false;
            string errorMessage = string.Empty;
            try
            {
                //Usuario = new Intec.BL.BE.UsuarioBE().ObtenerUsuario(User, Pass);
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.Message;
            }

            SetDicRta(Usuario, Usuario.Count, error, errorMessage, Intec.BL.BE.UsuarioBE._duration);
            return Json(ansDic);
        }
        
        public JsonResult CrearUsuario(Intec.BL.DTO.Usuarios UsuarioCrear)
        {            
            //new Intec.BL.BE.UsuarioBE().IngresarUsuario(UsuarioCrear);   
            SetDicRta("", 0, false, "", Intec.BL.BE.UsuarioBE._duration);
            return Json(ansDic);
        }

        public JsonResult ObtenerTiposIdentificacion()
        {
            List<Intec.BL.DTO.TiposIdentificacion> tiposId = new List<Intec.BL.DTO.TiposIdentificacion>();
            bool error = false;
            string errorMessage = string.Empty;
            try
            {
                //tiposId = new Intec.BL.BE.AdministracionBE().ObtenerTiposIdentificacion();
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.Message;
            }

            SetDicRta(tiposId, tiposId.Count, error, errorMessage, Intec.BL.BE.AdministracionBE._duration);
            return Json(ansDic);
        }

        public JsonResult ObtenerPaises()
        {
            List<Intec.BL.DTO.Paises> paises = new List<Intec.BL.DTO.Paises>();
            bool error = false;
            string errorMessage = string.Empty;
            try
            {
                paises = new Intec.BL.BE.AdministracionBE().ObtenerPaises();
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.Message;
            }

            SetDicRta(paises, paises.Count, error, errorMessage, Intec.BL.BE.AdministracionBE._duration);
            return Json(ansDic);
        }

    }
}