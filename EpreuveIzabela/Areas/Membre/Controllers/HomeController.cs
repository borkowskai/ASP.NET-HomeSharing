using EpreuveIzabela.Tools;
using EpreuveIzabela.Tools.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpreuveIzabela.Areas.Membre.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        // GET: Membre/Home
        public ActionResult Index()
        {

            // [CustomAuthorize] remplace if (!SessionUtils.IsConnected)
            ViewBag.Welcome = "Welcome to your area " + SessionUtils.ConnectedUser.Nom;
            return View(SessionUtils.ConnectedUser);



        }
    }
}