using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Web.Security;
using Newtonsoft.Json;
using System.Net;
using RgyDAL;

namespace RenderLogy.Controllers
{
    public class HomeController : Controller
    {
          DataContext db = new DataContext();
         
        //
        // GET: /Home/

        public ActionResult SignIn()
        {           
            return View();
        }
        
      

        CommonUtility objCommUtil = new CommonUtility();
        public ActionResult ConfirmAccount(int Id, string EmailId)
        {
            // var confirmationToken = Request["Id"];
            if (objCommUtil.ActiveAccount(Id, EmailId))
            {
               TempData["SignUpMsg"] = "Your account is activated"; 
                return RedirectToAction("SignIn");
            }
            return RedirectToAction("SignUp");
           
        }
        [HttpPost]
        public ActionResult SignIn(SignUp model)
        {           
            var user = db.SignUp.Where(u => u.EmailId == model.EmailId && u.Password == model.Password).FirstOrDefault();
            
            if (user != null)
            {
                if (user.IsActive != false)
                {
                    string[] roles = user.Roles.Select(u => u.Name).ToArray();
                  
                    UserData userdata = new UserData();
                    userdata.Username = user.FullName;
                    userdata.FirstName = user.EmailId;
                    userdata.Roles = roles;
                     Session["FullName"]=  user.FullName;
                     Session["UserId"] = user.SignUpId;
                    string struserdata = JsonConvert.SerializeObject(userdata);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.FullName, DateTime.Now, DateTime.Now.AddMinutes(60), false, struserdata);
                    string encpdata = FormsAuthentication.Encrypt(ticket);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encpdata);
                    Response.Cookies.Add(cookie);

                    if (userdata.Roles.Contains("Admin"))
                    {

                        return RedirectToAction("AdminAccount", "Admin");
                    }
                    else if (userdata.Roles.Contains("User"))
                    {

                        return RedirectToAction("Index", "User");
                    } 
                    else if (userdata.Roles.Contains("CRM"))
                    {

                        return RedirectToAction("Index", "CRM");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Your Account is not Activate yet, Check your email for activation");
                }
            }
            else
            {
                ModelState.AddModelError("", "Your User name or password is incorrect");
            }
            return View();
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            SignUp signup = db.SignUp.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        //
        // GET: /Home/Create

        public ActionResult SignUp()
        {
              BindState();
             BindCity(null);
            return View();
        }

        //
        // POST: /Home/Create
        CommonUtility objUtil = new CommonUtility();
        [HttpPost]
        public ActionResult SignUp(SignUp signup)
        {
            //if (!ModelState.IsValid)
            //{
            //    var message = string.Join(" | ", ModelState.Values
            //        .SelectMany(v => v.Errors)
            //        .Select(e => e.ErrorMessage));
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            //}
             if (ModelState.IsValid)
            {              
                if (!objUtil.IsUserEmlExist(signup.EmailId))
                {
                    SignUp objDSignUP = new SignUp();
                    objDSignUP.DesignHouseName = signup.DesignHouseName;
                    objDSignUP.FullName = signup.FullName;
                    objDSignUP.EmailId = signup.EmailId;
                    objDSignUP.Address = signup.Address;
                    objDSignUP.State = signup.State;
                    objDSignUP.StateName = signup.StateName;
                    objDSignUP.City = signup.City;
                    //objDSignUP.CityName=signup.CityName; 
                    objDSignUP.PhoneNo = signup.PhoneNo;
                    objDSignUP.NoOfEmployeeDesHouse = signup.NoOfEmployeeDesHouse;
                    objDSignUP.Password = signup.Password;
                    objDSignUP.ConfirmPassword = signup.ConfirmPassword;
                    objDSignUP.RoleName = signup.RoleName;
                    Session["EmailId"] = signup.EmailId;
                    //var RandomPwd = GenerateRandomPassword(10);
                    //objDSignUP.RandomPwd = RandomPwd;                    
                    db.SignUp.Add(objDSignUP);
                    db.SaveChanges();
                    int SignUpId = objDSignUP.SignUpId;
                    objUtil.InsertRole(SignUpId, 1);
                    MailUtil objMailUtil = new MailUtil();
                    objMailUtil.RegistrationMail(SignUpId);
                    TempData["SignUpMsg"] = "Your have registered successfully. Check your email for account activation";
                    TempData.Keep();
                    return RedirectToAction("SignIn");
                    //return View("Index");       
                }
                else
                {
                    BindCity(null);
                    BindState();
                    ViewBag.EmailDuplicate = "This email id already exists in our database";
                   // ModelState.AddModelError("", "This email id already exists in our database");
 
                }
            }
             BindCity(signup.State);
             BindState();
             return View(signup);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SignUp signup = db.SignUp.Find(id);
            SignUp signUpM = new SignUp();

            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(SignUp signup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(signup);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SignUp signup = db.SignUp.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SignUp signup = db.SignUp.Find(id);
            db.SignUp.Remove(signup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(FormCollection frm,SignUp model)
        {
            var txtEmail = frm["txtForgEmail"];
           var user = db.SignUp.Where(u => u.EmailId == txtEmail).FirstOrDefault();
              if (user != null)
              {
                  string FullName = user.FullName;
                  string  EmailId = user.EmailId;
                  string Password = user.Password;
                 string MailerPath= Server.MapPath("~/Mailer/forgotPassword.htm");
                 MailUtil objMailUtil = new MailUtil();
                 objMailUtil.SendForgotPassword(FullName, EmailId, Password, MailerPath);
                 ViewBag.FogotPwd = "Your password has been sent to your Email";
             }
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [HttpPost]
        public ActionResult GetCity(SignUp SignUp)
        {
            BindCity(SignUp.State);
            BindState();
            ViewBag.Password = SignUp.Password;
            ViewBag.ConfirmPassword = SignUp.ConfirmPassword;
            //var value = frm["hdnRegister"];
            //if (value == "Reg")
            //    return View("RegisterUser");
            //else
                return View("SignUp");

        }

        void BindState()
        {
            var q = db.State.ToList();
            List<States> StateList = new List<States>();
            StateList.Add(new States { StateID = null, StatName = "Select State" });
            if (q.Count > 0)
            {
                q.ForEach(item => StateList.Add(new States { StateID = item.StateID, StatName = item.StatName }));
            }
            ViewBag.StateList = StateList;

        }
        void BindStateName(int? Id)
        {
           // var q = db.State.ToList();
            List<States> StateListName = new List<States>();
            //StateList.Add(new State { StateID = null, Name = "Select State" });
            if (Id != null)
            {
                var q = db.State.Where(s => s.StateID == Id).ToList();
                if (q.Count > 0)
                {
                    q.ForEach(item => StateListName.Add(new States { StatName = item.StatName }));
                }
            }
            ViewBag.StateListName = StateListName;

        }
        void BindCity(int? Id)
        {
            List<Cities> CityList = new List<Cities>();
            CityList.Add(new Cities { StateID = null, CityName = "Select City" });

            if (Id != null)
            {
                var q = db.City.Where(c => c.StateID == Id).ToList();
                if (q.Count > 0)
                {
                    q.ForEach(item => CityList.Add(new Cities { CityID = item.CityID, CityName = item.CityName }));
                }
            }
            ViewBag.CityList = CityList;
        }
       
        private string GenerateRandomPassword(int length)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-*&#+";
            char[] chars = new char[length];
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn", "Home");
        }
        [HttpPost]
        public void DisableAccount(int Id)
        {  
            if(Id!=null)        
            objUtil.DisableAccount(Id);
        }
        public ActionResult AccountActive(string EmailId)
        {
            // var confirmationToken = Request["Id"];
            if (objCommUtil.ActiveAccount(EmailId))
            {
                TempData["SignUpMsg"] = "Your account is activated";
                return RedirectToAction("SignIn");
            }
            return RedirectToAction("SignUp");

        }

    }
}