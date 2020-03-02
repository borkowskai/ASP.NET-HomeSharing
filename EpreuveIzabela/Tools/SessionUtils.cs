using EpreuveIzabela.Areas.Membre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpreuveIzabela.Tools
{
    //static pour pouvoir utiliser partout sans besoin de l'instancier
    public static class SessionUtils
    {
        public static bool IsConnected
        {
            get
            {
                if (HttpContext.Current.Session["IsConnected"] != null)
                {
                    return (bool)HttpContext.Current.Session["IsConnected"];
                }
                return false;

            }

            set
            {
                HttpContext.Current.Session["IsConnected"] = value;
            }
        }
        // profilemodel nous avons besoin apres creating AREA
        public static ProfileModel ConnectedUser
        {
            get
            {
                if (HttpContext.Current.Session["ConnectedUser"] != null)
                {
                    return (ProfileModel)HttpContext.Current.Session["ConnectedUser"];
                }
                return null;

            }

            set
            {
                HttpContext.Current.Session["ConnectedUser"] = value;
            }
        }
    }
}