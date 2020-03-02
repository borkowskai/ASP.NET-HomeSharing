using EpreuveIzabela.Areas.Membre.Models;
using EpreuveIzabela.DAL.Repositories;
using EpreuveIzabela.Tools;
using EpreuveIzabela.Tools.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpreuveIzabela.Areas.Membre.Controllers
{
    public class BienController : Controller
    {
        // GET: Membre/Bien
        public ActionResult DisplayProperties()
        {
            MembreRepository mr = new MembreRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            int id = SessionUtils.ConnectedUser.Id;

            //select comme for
            //ici je retraduit le mapper de maptoDBModel a la requeque que j'ai fait
            List<BienModel> ListeBien = mr.LoadBien(id).Select(c => MapToDBModel.BienToBienModel(c)).ToList();
            return View(ListeBien);
        }
        public ActionResult AddProperties() 
        {
            return View();
        
        }
    }
}