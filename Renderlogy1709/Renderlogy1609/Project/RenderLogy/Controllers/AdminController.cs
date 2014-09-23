using RenderLogy.Filters;
using RgyDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenderLogy.Controllers
{
    public class AdminController : BaseController
    {
        //
        // GET: /Admin/
        DataContext db = new DataContext();
        CommonUtility objComUtil = new CommonUtility();
        MailUtil objMailUt = new MailUtil();
        [CustomAutorizeFilter(Roles = "Admin")]
        public ActionResult AdminAccount()
        {
            ViewBag.logged = Session["FullName"];        
            var users = from user in db.SignUp where user.IsActive != false  orderby user.FullName ascending  select user;                    
            ViewBag.NoAciveUser = db.SignUp.Where(u => u.IsActive == false).ToList();
            return View(users.ToList());
            //return View(db.SignUp.ToList());
        }
        [HttpPost]
        public ActionResult AdminAccount(string sortingOrd)
        {
            if (sortingOrd == "ascending")
                return RedirectToAction("AdminAccount");
               var users = from user in db.SignUp 
                        where user.IsActive != false
                        orderby user.FullName descending
                        select user;
            ViewBag.NoAciveUser = db.SignUp.Where(u => u.IsActive == false).ToList();
            return View(users.ToList());

        }
        [HttpPost]
        public void DisableAccount(int Id)
        {
            if (Id !=null)
                objComUtil.DisableAccount(Id);
        }
        [HttpPost]
        public void ChangeRole(int Id, string RoleName)
        {
            if (Id != null && RoleName!=null)
                objComUtil.ChangeRole(Id, RoleName);
        }

       
        public ActionResult InviteNewMembersTab()
        {
            //if (Id != null)
            //    objUtil.DisableAccount(Id);
            return RedirectToAction("AdminAccount");
        }
        [HttpPost]
        public void SendInvitationMail(string To)
        {
            if(To!=null)
              objMailUt.InviteNewMemberMail(To);
        }
        public void Sort(ref List<SignUp> list, string sortBy, string sortDirection)
        { 
         //sortBy = "FirstName"
        //sortDirection = "ASC" or "DESC"
       var sort = list;
      if (sortBy == "FirstName")
      {
         list = list.OrderBy(x => x.FullName).ToList();    
      }

}

    }
}
