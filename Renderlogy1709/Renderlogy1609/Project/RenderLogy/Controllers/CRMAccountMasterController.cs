using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OleDb;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Text;
using RgyDAL;


namespace RenderLogy.Controllers
{
    public class CRMAccountMasterController : Controller
    {
        private DataContext db = new DataContext();

        void BindCity()
        {
            List<Cities> CityList = new List<Cities>();
            CityList.Add(new Cities { StateID = null, CityName = "Select" });

            var q = db.City.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => CityList.Add(new Cities { CityID = item.CityID, CityName = item.CityName }));
            }
            ViewBag.CityList = CityList;
        }
        void BindAccountNames()
        {
            List<AccountMaster> AccountMasterList = new List<AccountMaster>();
            AccountMasterList.Add(new AccountMaster { AccountMasterId = 0, AccountMasterName = "Select" });

            var q = db.AccountMaster.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => AccountMasterList.Add(new AccountMaster { AccountMasterId = item.AccountMasterId, AccountMasterName = item.AccountMasterName }));
            }
            ViewBag.AccountMasterList = AccountMasterList;
        }
        void BindDevelopers()
        {
            List<DeveloperMaster> DeveloperMasterList = new List<DeveloperMaster>();
            DeveloperMasterList.Add(new DeveloperMaster { DeveloperId = 0, DeveloperName = "Select" });

            var q = db.DeveloperMaster.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => DeveloperMasterList.Add(new DeveloperMaster { DeveloperId = item.DeveloperId, DeveloperName = item.DeveloperName }));
            }

            ViewBag.DeveloperMasterList = DeveloperMasterList;
        }

        void BindAccountTypes()
        {
            List<AccountTypeMaster> AccountTypeMasterList = new List<AccountTypeMaster>();
            AccountTypeMasterList.Add(new AccountTypeMaster { AccountTypeId = 0, AccountTypeName = "Select" });

            var q = db.AccountTypeMaster.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => AccountTypeMasterList.Add(new AccountTypeMaster { AccountTypeId = item.AccountTypeId, AccountTypeName = item.AccountTypeName }));
            }

            ViewBag.AccountTypeMasterList = AccountTypeMasterList;
        }
        void BindAccountManager()
        {
            List<AccountManagerMaster> AccountManagerMasterList = new List<AccountManagerMaster>();
            AccountManagerMasterList.Add(new AccountManagerMaster { AccountManagerId = 0, AccountManagerName = "Select" });

            var q = db.AccountManagerMaster.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => AccountManagerMasterList.Add(new AccountManagerMaster { AccountManagerId = item.AccountManagerId, AccountManagerName = item.AccountManagerName }));
            }

            ViewBag.AccountManagerMasterList = AccountManagerMasterList;
        }
        void BindAccountMasterStatus()
        {
            List<AccountMasterStatus> AccountMasterStatusList = new List<AccountMasterStatus>();
            AccountMasterStatusList.Add(new AccountMasterStatus { AccountStatusId = 0, AccountStatusName = "Select" });

            var q = db.AccountMasterStatus.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => AccountMasterStatusList.Add(new AccountMasterStatus { AccountStatusId = item.AccountStatusId, AccountStatusName = item.AccountStatusName }));
            }

            ViewBag.AccountMasterStatusList = AccountMasterStatusList;
        }

        public ActionResult Index()
        {
            IList<CRMAccountMaster> CRMAccountMasterList = new List<CRMAccountMaster>();
            var query = from cr in db.CRMAccountMaster
                        join cs in db.AccountMasterStatus on cr.AccountStatusId equals cs.AccountStatusId
                        join amm in db.AccountManagerMaster on cr.AccountManagerId equals amm.AccountManagerId
                        join ct in db.City on cr.CityId equals ct.CityID
                        join acty in db.AccountTypeMaster on cr.AccountTypeId equals acty.AccountTypeId                      
                        select new
                        {
                            AccountId = cr.AccountId,
                            AccountMasterName = cr.AccountMasterName,
                            AccountStatusName = (cr.AccountStatusId == 0 ? String.Empty : cs.AccountStatusName),
                            CityName = (cr.CityId == 0 ? String.Empty : ct.CityName),
                            AccountManagerName = (cr.AccountManagerId == 0 ? String.Empty : amm.AccountManagerName),
                            Address = cr.Address,
                            AccountTypeName = (cr.AccountTypeId == 0 ? String.Empty : acty.AccountTypeName),
                            CreationDate = cr.ModifiedDate,
                            DeveloperName = cr.DeveloperName,
                        };

            var CRMAccounts = query.ToList();
            foreach (var CRMAccountMasterData in CRMAccounts)
            {
                CRMAccountMasterList.Add(new CRMAccountMaster()
                {
                    AccountMasterName = CRMAccountMasterData.AccountMasterName,
                    AccountStatusName = CRMAccountMasterData.AccountStatusName,
                    AccountId = CRMAccountMasterData.AccountId,   
                    CityName = CRMAccountMasterData.CityName,
                    AccountManagerName = CRMAccountMasterData.AccountManagerName,
                    Address = CRMAccountMasterData.Address,
                    DeveloperName = CRMAccountMasterData.DeveloperName,
                    CreationDate = CRMAccountMasterData.CreationDate,
                   // AccountMasterName = CRMAccountMasterData.AccountMasterName,                 

                });
            }
            return View(CRMAccountMasterList);

        }

        public ActionResult Create()
        {
            
            BindAccountNames();
            BindDevelopers();
            BindAccountTypes();
            BindAccountManager();
            BindCity();
            BindAccountMasterStatus();
          
            return View();
        }


        [HttpPost]
        public ActionResult Create(CRMContact crmcontact)
        {
            var user = db.CRMContact.Where(u => u.ContactEmailAddress == crmcontact.ContactEmailAddress).FirstOrDefault();
            if (user == null)
            {
                var ckmobile = db.CRMContact.Where(u => u.MobileNumber == crmcontact.MobileNumber).FirstOrDefault();
                if (ckmobile == null)
                {
                    if (ModelState.IsValid)
                    {
                        string sqlqry = "INSERT INTO CRMContacts (ContactName ,AccountMasterId ,DeveloperId ,AccountTypeId ,ProjectLocationId ,Address ,MobileNumber ,PhoneNumber ,ContactEmailAddress ,AccountManagerId ,ContactStatusId ,Budget,ReferralSourceId,TypeofconversationId ,CreatedBy,CreationDate ,ModifiedBy,ModifiedDate)";
                        sqlqry += " VALUES  (@ContactName ,@AccountMasterId ,@DeveloperId ,@AccountTypeId ,@ProjectLocationId ,@Address ,@MobileNumber ,@PhoneNumber ,@ContactEmailAddress ,@AccountManagerId ,@ContactStatusId ,@Budget,@ReferralSourceId,@TypeofconversationId ,@CreatedBy,@CreationDate ,@ModifiedBy,@ModifiedDate)";

                        List<SqlParameter> parameterList = new List<SqlParameter>();
                        parameterList.Add(new SqlParameter("@ContactName", crmcontact.ContactName));
                        parameterList.Add(new SqlParameter("@AccountMasterId", crmcontact.AccountMasterId));
                        parameterList.Add(new SqlParameter("@DeveloperId", crmcontact.DeveloperId));
                        parameterList.Add(new SqlParameter("@AccountTypeId", crmcontact.AccountTypeId));
                        parameterList.Add(new SqlParameter("@ProjectLocationId", crmcontact.ProjectLocationId));
                        parameterList.Add(new SqlParameter("@Address", crmcontact.Address));
                        parameterList.Add(new SqlParameter("@MobileNumber", crmcontact.MobileNumber));
                        parameterList.Add(new SqlParameter("@PhoneNumber", crmcontact.PhoneNumber));
                        parameterList.Add(new SqlParameter("@ContactEmailAddress", crmcontact.ContactEmailAddress));
                        parameterList.Add(new SqlParameter("@AccountManagerId", crmcontact.AccountManagerId));
                        parameterList.Add(new SqlParameter("@ContactStatusId", crmcontact.ContactStatusId));
                        parameterList.Add(new SqlParameter("@Budget", crmcontact.Budget));
                        parameterList.Add(new SqlParameter("@ReferralSourceId", crmcontact.ReferralSourceId));
                        //parameterList.Add(new SqlParameter("@TypeofconversationId", crmcontact.TypeofconversationId));
                        parameterList.Add(new SqlParameter("@TypeofconversationId", 1));
                        parameterList.Add(new SqlParameter("@CreatedBy", 1));
                        parameterList.Add(new SqlParameter("@CreationDate", DateTime.Now));
                        parameterList.Add(new SqlParameter("@ModifiedBy", 1));
                        parameterList.Add(new SqlParameter("@ModifiedDate", DateTime.Now));

                        SqlParameter[] parameters = parameterList.ToArray();
                        int result = (int)db.Database.ExecuteSqlCommand(sqlqry, parameters);
                        if (result != null)
                        {
                            if (crmcontact.FollowUpDate != null)
                            {
                                var checkContacId = from C in db.CRMContact
                                                    where C.ContactEmailAddress == crmcontact.ContactEmailAddress
                                                    select C.ContactId;
                                if (checkContacId.FirstOrDefault() != null)
                                {
                                    int cntid = checkContacId.FirstOrDefault();
                                    /////--------Insert Data in FollowAlerts---///
                                    string sqlqry2 = "INSERT INTO FollowAlerts(ContactId,Comments ,FollowUpDate,FollowUpHH,FollowUpMM,FollowUpAMPM,RemindMe2Hours,RemindMeToDay,RemindMe2Days,Status)";
                                    sqlqry2 += "Values(@ContactId,@Comments ,@FollowUpDate,@FollowUpHH,@FollowUpMM,@FollowUpAMPM,@RemindMe2Hours,@RemindMeToDay,@RemindMe2Days,@Status)";
                                    List<SqlParameter> parameterList2 = new List<SqlParameter>();
                                    parameterList2.Add(new SqlParameter("@ContactId", cntid));
                                    parameterList2.Add(new SqlParameter("@Comments", crmcontact.Comments));
                                    parameterList2.Add(new SqlParameter("@FollowUpDate", crmcontact.FollowUpDate));
                                    parameterList2.Add(new SqlParameter("@FollowUpHH", crmcontact.FollowUpHH));
                                    parameterList2.Add(new SqlParameter("@FollowUpMM", crmcontact.FollowUpMM));
                                    parameterList2.Add(new SqlParameter("@FollowUpAMPM", crmcontact.FollowUpAMPM));
                                    parameterList2.Add(new SqlParameter("@RemindMe2Hours", crmcontact.RemindMe2Hours));
                                    parameterList2.Add(new SqlParameter("@RemindMeToDay", crmcontact.RemindMeToDay));
                                    parameterList2.Add(new SqlParameter("@RemindMe2Days", crmcontact.RemindMe2Days));
                                    parameterList2.Add(new SqlParameter("@Status", 1));//1 for yes and 2 no//
                                    SqlParameter[] parameters2 = parameterList2.ToArray();
                                    int result2 = db.Database.ExecuteSqlCommand(sqlqry2, parameters2);
                                }
                            }
                        }
                        //db.CRMContact.Add(crmcontact);
                        //db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mobile Number already exists");
                }

            }
            else
            {
                ModelState.AddModelError("", "Email Address already exists");
            }
           
            BindAccountNames();
            BindDevelopers();
            BindAccountTypes();
            BindAccountManager();
            BindCity();
            BindAccountMasterStatus();
           
            return View(crmcontact);
        }

        public ActionResult ViewContact(int id = 0)
        {
         
            BindAccountNames();
            BindDevelopers();
            BindAccountTypes();
            BindAccountManager();
            BindCity();
            BindAccountMasterStatus();
        
            ViewBag.FollowAlerts = db.FollowAlerts.SqlQuery("SELECT AlertId ,Comments,FollowUpDate,FollowUpHH,FollowUpMM,FollowUpAMPM,RemindMe2Hours,RemindMeToDay,RemindMe2Days,Status,ContactId FROM FollowAlerts where Contactid=" + id + "").ToList();

            var query = (from cr in db.CRMContact
                         where cr.ContactId == id
                         join cs in db.ContactStatus on cr.ContactStatusId equals cs.ContactStatusId
                         join dp in db.DeveloperMaster on cr.DeveloperId equals dp.DeveloperId
                         join amm in db.AccountManagerMaster on cr.AccountManagerId equals amm.AccountManagerId
                         join ct in db.City on cr.ProjectLocationId equals ct.CityID
                         join acty in db.AccountTypeMaster on cr.AccountTypeId equals acty.AccountTypeId
                         join actnm in db.AccountMaster on cr.AccountMasterId equals actnm.AccountMasterId
                         join refs in db.ReferralSources on cr.ReferralSourceId equals refs.ReferralSourceId
                         join typeconv in db.Typeofconversations on cr.TypeofconversationId equals typeconv.TypeofconversationId
                         select new
                         {
                             ContactId = cr.ContactId,
                             ContactName = cr.ContactName,
                             ContactEmailAddress = cr.ContactEmailAddress,
                             ContactStatusName = (cr.ContactStatusId == 0 ? String.Empty : cs.ContactStatusName),
                             DeveloperName = (cr.DeveloperId == 0 ? String.Empty : dp.DeveloperName),
                             ProjectLocationCity = (cr.ProjectLocationId == 0 ? String.Empty : ct.CityName),
                             AccountManagerName = (cr.AccountManagerId == 0 ? String.Empty : amm.AccountManagerName),
                             Address = cr.Address,
                             AccountTypeName = (cr.AccountTypeId == 0 ? String.Empty : acty.AccountTypeName),
                             CreationDate = cr.ModifiedDate,
                             AccountMasterName = (cr.AccountMasterId == 0 ? String.Empty : actnm.AccountMasterName),
                             MobileNumber = cr.MobileNumber,
                             PhoneNumber = cr.PhoneNumber,
                             Budget = cr.Budget,
                             ReferralSourceName = (cr.ReferralSourceId == 0 ? String.Empty : refs.ReferralSourceName),
                             TypeofconversationName = (cr.TypeofconversationId == 0 ? String.Empty : typeconv.TypeofconversationName)
                         }).FirstOrDefault();
            if (query != null)
            {
                CRMContact crmContact = new CRMContact()
                {
                    ContactName = query.ContactName,
                    ContactEmailAddress = query.ContactEmailAddress,
                    ContactStatusName = query.ContactStatusName,
                    ContactId = query.ContactId,
                    DeveloperName = query.DeveloperName,
                    ProjectLocationCity = query.ProjectLocationCity,
                    AccountManagerName = query.AccountManagerName,
                    Address = query.Address,
                    AccountTypeName = query.AccountTypeName,
                    CreationDate = query.CreationDate,
                    AccountMasterName = query.AccountMasterName,
                    MobileNumber = query.MobileNumber,
                    PhoneNumber = query.PhoneNumber,
                    Budget = query.Budget,
                    ReferralSourceName = query.ReferralSourceName,
                    TypeofconversationName = query.TypeofconversationName

                };
                return View(crmContact);
            }
            else
                return HttpNotFound();

        }
        public ActionResult Edit(int id = 0)
        {
          
            BindAccountNames();
            BindDevelopers();
            BindAccountTypes();
            BindAccountManager();
            BindCity();
            BindAccountMasterStatus();
          
            CRMContact crmcontact = db.CRMContact.Find(id);
            if (crmcontact == null)
            {

                return HttpNotFound();
            }
            return View(crmcontact);
        }


        [HttpPost]
        public ActionResult Edit(CRMContact crmcontact)
        {
            if (ModelState.IsValid)
            {
                string sqlqry = "UPDATE CRMContacts SET ContactName=@ContactName ,AccountMasterId=@AccountMasterId ,DeveloperId=@DeveloperId ,AccountTypeId=@AccountTypeId ,ProjectLocationId=@ProjectLocationId ,Address=@Address ,PhoneNumber=@PhoneNumber ,";
                sqlqry += "AccountManagerId=@AccountManagerId ,ContactStatusId=@ContactStatusId ,Budget=@Budget,ReferralSourceId=@ReferralSourceId,TypeofconversationId=@TypeofconversationId ,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate";
                sqlqry += " Where ContactId=@ContactId";
                List<SqlParameter> parameterList = new List<SqlParameter>();
                parameterList.Add(new SqlParameter("@ContactId", crmcontact.ContactId));
                parameterList.Add(new SqlParameter("@ContactName", crmcontact.ContactName));
                parameterList.Add(new SqlParameter("@AccountMasterId", crmcontact.AccountMasterId));
                parameterList.Add(new SqlParameter("@DeveloperId", crmcontact.DeveloperId));
                parameterList.Add(new SqlParameter("@AccountTypeId", crmcontact.AccountTypeId));
                parameterList.Add(new SqlParameter("@ProjectLocationId", crmcontact.ProjectLocationId));
                parameterList.Add(new SqlParameter("@Address", crmcontact.Address));
                parameterList.Add(new SqlParameter("@PhoneNumber", crmcontact.PhoneNumber));
                parameterList.Add(new SqlParameter("@AccountManagerId", crmcontact.AccountManagerId));
                parameterList.Add(new SqlParameter("@ContactStatusId", crmcontact.ContactStatusId));
                parameterList.Add(new SqlParameter("@Budget", crmcontact.Budget));
                parameterList.Add(new SqlParameter("@ReferralSourceId", crmcontact.ReferralSourceId));
                parameterList.Add(new SqlParameter("@TypeofconversationId", crmcontact.TypeofconversationId));
                parameterList.Add(new SqlParameter("@ModifiedBy", 1));
                parameterList.Add(new SqlParameter("@ModifiedDate", DateTime.Now));

                SqlParameter[] parameters = parameterList.ToArray();
                int result = (int)db.Database.ExecuteSqlCommand(sqlqry, parameters);
                if (result != null)
                {
                    if (crmcontact.FollowUpDate != null)
                    {
                        /////--------Insert Data in FollowAlerts---///
                        string sqlqry2 = "INSERT INTO FollowAlerts(ContactId,Comments ,FollowUpDate,FollowUpHH,FollowUpMM,FollowUpAMPM,RemindMe2Hours,RemindMeToDay,RemindMe2Days,Status)";
                        sqlqry2 += "Values(@ContactId,@Comments ,@FollowUpDate,@FollowUpHH,@FollowUpMM,@FollowUpAMPM,@RemindMe2Hours,@RemindMeToDay,@RemindMe2Days,@Status)";
                        List<SqlParameter> parameterList2 = new List<SqlParameter>();
                        parameterList2.Add(new SqlParameter("@ContactId", crmcontact.ContactId));
                        parameterList2.Add(new SqlParameter("@Comments", crmcontact.Comments));
                        parameterList2.Add(new SqlParameter("@FollowUpDate", crmcontact.FollowUpDate));
                        parameterList2.Add(new SqlParameter("@FollowUpHH", crmcontact.FollowUpHH));
                        parameterList2.Add(new SqlParameter("@FollowUpMM", crmcontact.FollowUpMM));
                        parameterList2.Add(new SqlParameter("@FollowUpAMPM", crmcontact.FollowUpAMPM));
                        parameterList2.Add(new SqlParameter("@RemindMe2Hours", crmcontact.RemindMe2Hours));
                        parameterList2.Add(new SqlParameter("@RemindMeToDay", crmcontact.RemindMeToDay));
                        parameterList2.Add(new SqlParameter("@RemindMe2Days", crmcontact.RemindMe2Days));
                        parameterList2.Add(new SqlParameter("@Status", 1));//1 for yes and 2 no//
                        SqlParameter[] parameters2 = parameterList2.ToArray();
                        int result2 = db.Database.ExecuteSqlCommand(sqlqry2, parameters2);
                    }
                }
                return RedirectToAction("ViewContact", "CRM", new { id = crmcontact.ContactId });
            }


            BindAccountNames();
            BindDevelopers();
            BindAccountTypes();
            BindAccountManager();
            BindCity();
            BindAccountMasterStatus();
       
            return View(crmcontact);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}