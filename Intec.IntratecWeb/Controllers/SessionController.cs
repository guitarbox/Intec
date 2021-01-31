using Intec.IntratecWeb.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intec.IntratecWeb.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public JsonResult AddUsuarioSesion(Usuarios UsuarioSesion)
        {
            Session["UsuarioSesion"] = UsuarioSesion;
            return Json("");
        }
        public JsonResult GetUsuarioSesion()
        {
            if (Session.Count != 0)
            {
                Usuarios UsuarioSesion = (Usuarios)Session["UsuarioSesion"];
                return Json(UsuarioSesion, JsonRequestBehavior.AllowGet);
            }
            else 
                return Json("NO_SESSION", JsonRequestBehavior.AllowGet);
        }
        public JsonResult Abandon()
        {
            Session.Clear();
            Session.Abandon();
            return Json("");
        }
    }
}