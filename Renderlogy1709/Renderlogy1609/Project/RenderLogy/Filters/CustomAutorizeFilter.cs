
using RgyDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenderLogy.Filters
{
    public class CustomAutorizeFilter : AuthorizeAttribute
    {
        public  CustomPrincipal CurrentUser
        {

            get { return HttpContext.Current.User as CustomPrincipal; }
            
        }
        public override void OnAuthorization(AuthorizationContext filterContext)

        {
            if (CurrentUser.Identity.IsAuthenticated)
            {
                //role based
                if (!string.IsNullOrEmpty(Roles))
                {
                    if (!CurrentUser.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Error", action = "UnAutorize" }));
                    }
                }

                //user based
                if (!string.IsNullOrEmpty(Users))
                {
                    if (!Users.Contains(CurrentUser.Identity.Name))
                    {
                        filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Error", action = "UnAutorize" }));
                    }
                }
            }
        }
    }
}