using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EpreuveIzabela.Tools.Filters
{
   
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    //le nom peut etre quelquqnque mais doit se finir avec attribut
    //on l'appele par le nom CustomAuthorize sans le mot Atribut
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        //Called when access is denied
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //User isn't logged in
            if (!SessionUtils.IsConnected)
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "Home", action = "Index", area = "" })
                );
            }
        }

        //Core authentication, called before each action
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return SessionUtils.IsConnected;
        }
    }
}