using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntecWebPage.Controllers
{
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SuccessStories()
        {
            return View("Success-stories");
        }
        
        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult BlogSingle()
        {
            return View("Blog-single");
        }

        public ActionResult Programe()
        {
            return View();
        }

        public ActionResult OrgDeInspeccion()
        {
            return View();
        }

        public ActionResult UniDeProyectos()
        {
            return View();
        }
    
        public JsonResult ObtenerDepartamentos()
        {
            List<Intec.BL.DTO.Departamentos> deptos = new List<Intec.BL.DTO.Departamentos>();
            bool error = false;
            string errorMessage = string.Empty;
            try
            {
                deptos = new Intec.BL.BE.AdministracionBE().ObtenerDepartamentos(57);
            }
            catch (Exception ex) 
            {
                error = true;
                errorMessage = ex.Message;
            }

            SetDicRta(deptos, deptos.Count, error, errorMessage, Intec.BL.BE.AdministracionBE._duration);
            return Json(ansDic);
        }

        public JsonResult ObtenerCiudades(string IdDepartamento)
        {
            List<Intec.BL.DTO.Ciudades> ciudades = new List<Intec.BL.DTO.Ciudades>();
            bool error = false;
            string errorMessage = string.Empty;
            try
            {
                ciudades = new Intec.BL.BE.AdministracionBE().ObtenerCiudades(IdDepartamento);
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.Message;
            }

            SetDicRta(ciudades, ciudades.Count, error, errorMessage, Intec.BL.BE.AdministracionBE._duration);
            return Json(ansDic);
        }
    
        public JsonResult IngresarSolicitudVisita(Intec.BL.DTO.SolicitudesProgramacionVisitas Solicitud)
        {            
            new Intec.BL.BE.SolicitudesProgramacionVisitasBE().CrearSolicitud(Solicitud);
            SetDicRta("", 0, false, "", Intec.BL.BE.SolicitudesProgramacionVisitasBE._duration);
            return Json(ansDic);
        }

        public JsonResult IngresarSolicitudContactenos(Intec.BL.DTO.SolicitudContactenos Solicitud)
        {
            new Intec.BL.BE.SolicitudContactenosBE().IngresarSolicitudContactenos(Solicitud);
            SetDicRta("", 0, false, "", Intec.BL.BE.SolicitudContactenosBE._duration);
            return Json(ansDic);
        }
    }
}