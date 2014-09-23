using RgyDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenderLogy.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        CommonUtility objCommUtil = new CommonUtility();
        public ActionResult ConfirmAccount(int Id, string EmailId)
        {
           // var confirmationToken = Request["Id"];
            objCommUtil.ActiveAccount( Id,  EmailId);
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
       //[ValidateAntiForgeryToken]
        public ActionResult ConfirmAccount(string ID)
        {
            //return View("ConfirmAccount");
            var confirmationToken = Request["token"];
            if (!String.IsNullOrEmpty(confirmationToken))
            {
                //var user = WebSecurity.CurrentUserName;
                //WebSecurity.ConfirmAccount(confirmationToken);
                //WebSecurity.Login(user, null);
                //return View("Welcome");
            }

            TempData["message"] = string.Format(
                        "Your account was not confirmed, please try again or contact the website adminstrator.");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult resetPwdForm(int Id) 
        {
         // https://portal1.passportindia.gov.in/AppOnlineProject/user/resetPwdForm?validationString=3082621608126643
            var confirmationToken = Request["Id"];
            return View();
        }

    }
}
