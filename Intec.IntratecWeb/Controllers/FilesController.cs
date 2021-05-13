using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intec.IntratecWeb.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult UpLoad()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpLoadFile(HttpPostedFileBase file)
        {
            string ubicacion = string.Empty,
                webPath = string.Empty;

            if (Session["GlobalVarForFileUpLoad"].ToString().Equals("CAL_EQU"))
            {
                string filename = $"certCalEqu_{DateTime.Now.Ticks}{Path.GetExtension(file.FileName)}";
                ubicacion = Path.Combine(Server.MapPath("~/tmp/certificadosCalibraciones"), filename);
                file.SaveAs(ubicacion);
            }
            else if (Session["GlobalVarForFileUpLoad"].ToString().Equals("FOT_VIS"))
            {
                string filename = $"fotVis_{DateTime.Now.Ticks}{Path.GetExtension(file.FileName)}";
                ubicacion = Path.Combine(Server.MapPath("~/tmp/fotosVisita"), filename);
                webPath = $"../tmp/fotosVisita/{filename}";
                file.SaveAs(ubicacion);
            }
            ViewBag.status = "success";
            ViewBag.from = Session["GlobalVarForFileUpLoad"].ToString();
            ViewBag.file = ubicacion;
            ViewBag.webPath = webPath;
            return View("UpLoad");
        }

        public JsonResult SetGlobalVarForFileUpLoad(string From)
        {
            Session["GlobalVarForFileUpLoad"] = From;
            return Json("");
        }
    }
}