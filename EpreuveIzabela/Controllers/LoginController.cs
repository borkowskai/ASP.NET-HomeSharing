using EpreuveIzabela.Areas.Membre.Models;
using EpreuveIzabela.DAL.Repositories;
using EpreuveIzabela.Models;
using EpreuveIzabela.Tools;
using EpreuveIzabela.Tools.Filters;
using EpreuveIzabela.Tools.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpreuveIzabela.Controllers
{


    public class LoginController : Controller
    {

        // GET: Login

        // on pourrait mettre [HttpGet] mais c'est la meme chose si on ne met rien
        // il y a auusi HTTPPOST HTTPPATCH etc
        //on le dirige dans HTML par  action="/Home/Login" method="post"                       
        //Home c'est le nom de mon controleur et Login c'est le nom de l'action dedans        

        [HttpGet]
        public ActionResult Login()
        {
            if (SessionUtils.IsConnected)
            // je pourrais utiliser CustomAutorize que nous avons creer apres 
            // mais je devrais faire une deuxieme fonctionne qui permets faire des if  avec 
            {
                return RedirectToAction("Index", new { controller = "Home", area = "Membre" });
            }
            //TODO add ViewBag.ErrorMessage  + html
            return RedirectToAction("Index", new { controller = "Home", area = "" });
        }

        //[HttpPost] remplace dans PHP $ ifSetPOST
        [HttpPost]
        public ActionResult Login(LoginModel lm)
        {
            // I intanciate a MembreRepository with the connectionstring.
            // The connectionstring is stored into web.config and i get it with the ConfigurationManager

            MembreRepository Cr = new MembreRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            //I use the function VerifLogin from the MembreRepository
            //For use this function, I have to convert The LoginModel to the
            ProfileModel Mmodel = MapToDBModel.MemberToProfile(Cr.VerifLogin(MapToDBModel.LoginToMember(lm)));
            if (Mmodel != null)
            {
                SessionUtils.ConnectedUser = Mmodel;
                SessionUtils.IsConnected = true;
                return RedirectToAction("Index", new { controller = "Home", area = "Membre" });
            }
            else
            {
                ViewBag.ErrorLoginMessage = "Error Login or Password";
                return RedirectToAction("Index", new { controller = "Home", area = "" });
            }
        }
    }
}