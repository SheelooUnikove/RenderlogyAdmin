
using RgyDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenderLogy.Controllers
{
    public class PMOmanageController : Controller
    {
        //
        // GET: /PMOmanage/
        DataContext db = new DataContext();
        public ActionResult Engagements()
        {
            BindEngagementTypes();

            BindStates();
            BindCity(null);
            return View();

        }
      //  [HttpPost]
        public JsonResult GetCities(int StateID)
        {
            States states = new States();

            
            BindStates();
            ViewBag.SelState =StateID;
           // ViewBag.SelCity = states.City;

            if (StateID != null)
                BindCity(StateID);
            else
                BindCity(null);
            return Json(new SelectList(ViewBag.CitiesList, "CityId", "CityName"), JsonRequestBehavior.AllowGet);
          //  return View();


        }
        void BindStates()
        {
            List<RgyDAL.States> lstStates = new List<RgyDAL.States>();

            var q = db.State.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => lstStates.Add(new RgyDAL.States { StateID = item.StateID, StatName = item.StatName }));
            }

            ViewBag.StatesList = lstStates;
        }
        void BindEngagementTypes()
        {
            List<EngagementTypes> lstStates = new List<EngagementTypes>();

            var q = db.EngagementType.ToList();

              
            ViewBag.EngagementTypes = q;
        }

        [HttpPost]
        public string GenerateRandomCustId()
        {
            int length = 5;
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-*&#+";
            char[] chars = new char[length];
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }
        //void BindCity()
        //{
        //    List<RgyDAL.Cities> lstCities = new List<RgyDAL.Cities>();

        //    var q = db.City.ToList();

        //    ViewBag.CitiesList = q;
        //}
        //void BindCity(int? Id)
        //{
        //    List<RgyDAL.Cities> lstCities = new List<RgyDAL.Cities>();

        //    var q = db.City.ToList();
        //    if (q.Count > 0)
        //    {
        //        q.ForEach(item => lstCities.Add(new RgyDAL.Cities { StateID = item.StateID }));
        //    }

        //    ViewBag.CitiesList = lstCities;
        //}
        void BindCity(int? Id)
        {
            List<Cities> CityList = new List<Cities>();
            CityList.Add(new Cities { CityID = null, CityName = "Select City" });

            if (Id != null)
            {
                var q = db.City.Where(c => c.StateID == Id).ToList();
                if (q.Count > 0)
                {
                    q.ForEach(item => CityList.Add(new Cities { CityID = item.CityID, CityName = item.CityName }));
                }
            }
            ViewBag.CitiesList = CityList;
        }


        void BindStates(int? Id)
        {

            List<RgyDAL.States> lstStates = new List<RgyDAL.States>();

            var q = db.State.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => lstStates.Add(new RgyDAL.States { StatName = item.StatName }));
            }

            ViewBag.StatesList = lstStates; 
            //List<RenderLogy.Models.States> lstStates = new List<RenderLogy.Models.States>();


            //if (Id != null)
            //{
            //    var q = db.State.Where(s => s.StateID == Id).ToList();
            //    if (q.Count > 0)
            //    {
            //        q.ForEach(item => lstStates.Add(new RenderLogy.Models.States { StatName = item.StatName }));
            //    }
            //}
            //  ViewBag.StatesList= lstStates; 
        }
        //for server side






       
    }
} 
 