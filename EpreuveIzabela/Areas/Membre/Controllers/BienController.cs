using EpreuveIzabela.Areas.Membre.Models;
using EpreuveIzabela.DAL.Repositories;
using EpreuveIzabela.Tools;
using EpreuveIzabela.Models;
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
            
            PaysRepository mr = new PaysRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            //select comme for
            //ici je retraduit le mapper de maptoDBModel a la requeque que j'ai fait
            List<PaysModel> ListePays = mr.GetCountries().Select(item => MapToDBModel.PaysToPaysModel(item)).ToList();

            OptionRepository or = new OptionRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            List<OptionModel> ListeOptions = or.GetAll().Select(item=>MapToDBModel.OptionToOptionModel(item)).ToList();
            
            
            return View();
            

        }

        //TODO prepare
        public ActionResult BienRegister() 
        {
            return null;
        }
    }
}