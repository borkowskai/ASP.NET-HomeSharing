using EpreuveIzabela.DAL.Repositories;
using EpreuveIzabela.Models;
using EpreuveIzabela.Tools.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpreuveIzabela.Controllers
{
    public class HomeController : Controller
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

        public ActionResult Agents() 
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult BuySaleRent() 
        {
            return View();
        }

        public ActionResult PropertyDetail()
        {
            return View();
        }
        public ActionResult Form()
        {

            PaysRepository mr = new PaysRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);

            //select comme for
            //ici je retraduit le mapper de maptoDBModel a la requeque que j'ai fait
            List<PaysModel> ListePays = mr.GetCountries().Select(c => MapToDBModel.PaysToPaysModel(c)).ToList();
            
            return View(ListePays);
        }

    }
}