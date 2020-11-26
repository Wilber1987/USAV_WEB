using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_USAV.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        public ActionResult ViewPortalVideos()
        {
            ViewBag.Title = "ViewPortalVideos";
            return View();
        }
        public ActionResult viewReservaciones()
        {
            ViewBag.Title = "ViewReservaciones";
            return View();
        }
        public ActionResult viewCalendario()
        {
            ViewBag.Title = "ViewCalendario";
            return View();
        }
        public ActionResult ViewComoFunciona()
        {
            ViewBag.Title = "ViewComoFunciona";
            return View();
        }
        public ActionResult ViewContactos()
        {
            ViewBag.Title = "ViewContactos";
            return View();
        }
        public ActionResult ViewDocentes()
        {
            ViewBag.Title = "ViewDocentes";
            return View();
        }
        public ActionResult ViewPersonal()
        {
            ViewBag.Title = "ViewPersonal";
            return View();
        }
        public ActionResult ViewQuienSomos()
        {
            ViewBag.Title = "ViewQuienSomos";
            return View();
        }
        public ActionResult ViewServicios()
        {
            ViewBag.Title = "ViewServicios";
            return View();
        }
        public ActionResult ViewOrganizacion()
        {
            ViewBag.Title = "ViewOrganizacion";
            return View();
        }

    }
}
