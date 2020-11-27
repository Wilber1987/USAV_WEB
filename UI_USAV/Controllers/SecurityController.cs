using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_USAV.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security        
        public ActionResult ViewRegister()
        {
            ViewBag.Title = "ViewRegister";
            return View();
        }

    }
}
