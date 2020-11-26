using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USAV_Solicitudes.DatosSolicitudes;

namespace UI_USAV.Controllers
{
    public class AdministratorController : Controller
    {
        public ActionResult ViewCatalogos()
        {
            ViewBag.Title = "ViewCatalogos";
            return View();
        }
        public ActionResult ViewAdminVideos()
        {
            ViewBag.Title = "ViewAdminVideos";
            return View();
        }

    }
}
