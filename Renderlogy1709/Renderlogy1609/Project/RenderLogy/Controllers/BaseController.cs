
using RgyDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenderLogy.Controllers
{
    public class BaseController : Controller
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.User as CustomPrincipal;
            }
        }

    }
}
