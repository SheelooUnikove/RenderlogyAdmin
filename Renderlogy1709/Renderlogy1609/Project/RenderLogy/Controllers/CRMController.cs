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
using RenderLogy.Filters;

namespace RenderLogy.Controllers
{
     [CustomAutorizeFilter(Roles = "Admin,CRM")]
    public class CRMController : Controller
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
            AccountMasterList.Add(new AccountMaster { AccountMasterId = null, AccountMasterName = "Select" });

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
            DeveloperMasterList.Add(new DeveloperMaster { DeveloperId = null, DeveloperName = "Select" });

            var q = db.DeveloperMaster.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => DeveloperMasterList.Add(new DeveloperMaster { DeveloperId = item.DeveloperId, DeveloperName = item.DeveloperName }));
            }

            ViewBag.DeveloperMasterList = DeveloperMasterList;
        }
        void BindDevelopersForIndex()
        {
            List<DeveloperMaster> IndexDeveloperMasterList = new List<DeveloperMaster>();
            IndexDeveloperMasterList.Add(new DeveloperMaster { DeveloperId = null, DeveloperName = "Select" });

            var q = db.DeveloperMaster.ToList();
            q.RemoveAll(s => s.DeveloperName == "Other");
            if (q.Count > 0)
            {
                q.ForEach(item => IndexDeveloperMasterList.Add(new DeveloperMaster { DeveloperId = item.DeveloperId, DeveloperName = item.DeveloperName }));
            }

            ViewBag.IndexDeveloperMasterList = IndexDeveloperMasterList;
        }

        void BindAccountTypes()
        {
            List<AccountTypeMaster> AccountTypeMasterList = new List<AccountTypeMaster>();
            AccountTypeMasterList.Add(new AccountTypeMaster { AccountTypeId = null, AccountTypeName = "Select" });

            var q = db.AccountTypeMaster.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => AccountTypeMasterList.Add(new AccountTypeMaster { AccountTypeId = item.AccountTypeId, AccountTypeName = item.AccountTypeName }));
            }

            ViewBag.AccountTypeMasterList = AccountTypeMasterList;
        }
        void BindAccountManager()
        {
            var qry = "SELECT  SignUps.SignUpId AccountManagerId,FullName AccountManagerName";
            qry += " FROM SignUps";
            qry += " join UserRoles on UserRoles.SignUpId=SignUps.SignUpId";
            qry += " where UserRoles.RoleId=7 and SignUps.IsActive=1";

            ViewBag.AccountManagerMasterList = db.AccountManagerMaster.SqlQuery(qry).ToList();

            //List<AccountManagerMaster> AccountManagerMasterList = new List<AccountManagerMaster>();
            //AccountManagerMasterList.Add(new AccountManagerMaster { AccountManagerId = null, AccountManagerName = "Select" });

            //var q = db.AccountManagerMaster.ToList();
            //if (q.Count > 0)
            //{
            //    q.ForEach(item => AccountManagerMasterList.Add(new AccountManagerMaster { AccountManagerId = item.AccountManagerId, AccountManagerName = item.AccountManagerName }));
            //}

            //ViewBag.AccountManagerMasterList = AccountManagerMasterList;
        }
        void BindReferralSources()
        {
            List<ReferralSources> ReferralSourcesList = new List<ReferralSources>();
            ReferralSourcesList.Add(new ReferralSources { ReferralSourceId = null, ReferralSourceName = "Select" });

            var q = db.ReferralSources.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => ReferralSourcesList.Add(new ReferralSources { ReferralSourceId = item.ReferralSourceId, ReferralSourceName = item.ReferralSourceName }));
            }

            ViewBag.ReferralSourcesList = ReferralSourcesList;
        }
        void BindTypeofconversations()
        {
            List<Typeofconversations> TypeofconversationsList = new List<Typeofconversations>();
            TypeofconversationsList.Add(new Typeofconversations { TypeofconversationId = 0, TypeofconversationName = "Select" });

            var q = db.Typeofconversations.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => TypeofconversationsList.Add(new Typeofconversations { TypeofconversationId = item.TypeofconversationId, TypeofconversationName = item.TypeofconversationName }));
            }

            ViewBag.TypeofconversationsList = TypeofconversationsList;
        }
        void BindContactStatus()
        {
            List<ContactStatus> ContactStatusList = new List<ContactStatus>();
            ContactStatusList.Add(new ContactStatus { ContactStatusId = null, ContactStatusName = "Select" });

            var q = db.ContactStatus.ToList();
            if (q.Count > 0)
            {
                q.ForEach(item => ContactStatusList.Add(new ContactStatus { ContactStatusId = item.ContactStatusId, ContactStatusName = item.ContactStatusName }));
            }

            ViewBag.ContactStatusList = ContactStatusList;
        }


        void BindFollowUpHH()
        {
            List<FollowUpHH> FollowUpHHList = new List<FollowUpHH>();
            FollowUpHHList.Add(new FollowUpHH { FollowUpHHId = null, FollowUpHHName = "HH" });
            for (int i = 1; i < 10; i++)
            {
                FollowUpHHList.Add(new FollowUpHH { FollowUpHHId = i, FollowUpHHName = "0" + i.ToString() });
            }
            for (int i = 10; i <= 12; i++)
            {
                FollowUpHHList.Add(new FollowUpHH { FollowUpHHId = i, FollowUpHHName = i.ToString() });
            }
            ViewBag.FollowUpHHList = FollowUpHHList;

        }
        void BindFollowUpMM()
        {
            List<FollowUpMM> FollowUpMMList = new List<FollowUpMM>();
            FollowUpMMList.Add(new FollowUpMM { FollowUpMMId = null, FollowUpMMName = "MM" });
            for (int i = 0; i < 10; i++)
            {
                FollowUpMMList.Add(new FollowUpMM { FollowUpMMId = i, FollowUpMMName = "0" + i.ToString() });
            }
            for (int i = 10; i <= 59; i++)
            {
                FollowUpMMList.Add(new FollowUpMM { FollowUpMMId = i, FollowUpMMName = i.ToString() });
            }
            ViewBag.FollowUpMMList = FollowUpMMList;

        }
        public ActionResult Index(CRMContact crmcontact)
        {
            List<CRMContact> CRMContactList = new List<CRMContact>();
			ViewBag.logged = Session["FullName"];    
            var firstdate = DateTime.Now.AddYears(-10);
            var query = from cr in db.CRMContact
                        where 
                        cr.ContactName.Contains(crmcontact.ContactName == null ? cr.ContactName : crmcontact.ContactName)
                        && cr.DeveloperId == (crmcontact.DeveloperId == 0 ? cr.DeveloperId : crmcontact.DeveloperId)
                        && cr.ProjectLocationId == (crmcontact.ProjectLocationId == 0 ? cr.ProjectLocationId : crmcontact.ProjectLocationId)
                        && cr.ContactStatusId == (crmcontact.ContactStatusId == 0 ? cr.ContactStatusId : crmcontact.ContactStatusId)
                        && (cr.ModifiedDate >= (crmcontact.CreationDate == null ? firstdate : crmcontact.CreationDate) && cr.ModifiedDate <= (crmcontact.CreationDateEnd == null ? DateTime.Now : crmcontact.CreationDateEnd))                        
                        join cs in db.ContactStatus on cr.ContactStatusId equals cs.ContactStatusId
                        join dp in db.DeveloperMaster on cr.DeveloperId equals dp.DeveloperId
                        join amm in db.SignUp on cr.AccountManagerId equals amm.SignUpId
                        join ct in db.City on cr.ProjectLocationId equals ct.CityID
                        join acty in db.AccountTypeMaster on cr.AccountTypeId equals acty.AccountTypeId
                        join actnm in db.AccountMaster on cr.AccountMasterId equals actnm.AccountMasterId
                        join cust in db.Customers on cr.ContactId equals cust.Contid into gj
                        from subpet in gj.DefaultIfEmpty()
                        select new
                        {
                            ContactId = cr.ContactId,
                            ContactName = cr.ContactName,
                            ContactStatusName = (cr.ContactStatusId == 0 ? String.Empty : cs.ContactStatusName),
                            DeveloperName = (cr.DeveloperId == 0 ? String.Empty : dp.DeveloperName),
                            ProjectLocationCity = (cr.ProjectLocationId == 0 ? String.Empty : ct.CityName),
                            AccountManagerName = (cr.AccountManagerId == 0 ? String.Empty : amm.FullName),
                            Address = cr.Address,
                            AccountTypeName = (cr.AccountTypeId == 0 ? String.Empty : acty.AccountTypeName),
                            CreationDate = cr.ModifiedDate,
                            AccountMasterName = (cr.AccountMasterId == 0 ? String.Empty : actnm.AccountMasterName),
                            MobileNumber = cr.MobileNumber,
                            PhoneNumber = cr.PhoneNumber,
                            Budget = cr.Budget,
                            IsActive = (subpet.IsActive == null ? false : true),
                        };

            var CRMContacts = query.ToList();
            foreach (var CRMContactsData in CRMContacts)
            {
                CRMContactList.Add(new CRMContact()
                {
                    ContactName = CRMContactsData.ContactName.ToString(),
                    ContactStatusName = CRMContactsData.ContactStatusName.ToString(),
                    ContactId = CRMContactsData.ContactId,
                    DeveloperName = CRMContactsData.DeveloperName.ToString(),
                    ProjectLocationCity = CRMContactsData.ProjectLocationCity.ToString(),
                    AccountManagerName = CRMContactsData.AccountManagerName.ToString(),
                    Address = CRMContactsData.Address.ToString(),
                    AccountTypeName = CRMContactsData.AccountTypeName.ToString(),
                    CreationDate = CRMContactsData.CreationDate,
                    AccountMasterName = CRMContactsData.AccountMasterName.ToString(),
                    MobileNumber = CRMContactsData.MobileNumber.ToString(),
                    PhoneNumber = CRMContactsData.PhoneNumber.ToString(),
                    Budget = CRMContactsData.Budget.ToString(),
                    IsActive=CRMContactsData.IsActive,
                });
            }
            BindAccountNames();
            BindDevelopersForIndex();
            BindAccountTypes();
            BindAccountManager();
            BindCity();
            BindContactStatus();
            ViewBag.CRMContactList = CRMContactList;
            ModelState.Clear();
            return View();

        }

        public ActionResult Create()
        {
            BindTypeofconversations();
            BindReferralSources();
            BindAccountNames();
            BindDevelopers();
            BindAccountTypes();
            BindAccountManager();
            BindCity();
            BindContactStatus();
            BindFollowUpHH();
            BindFollowUpMM();
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
                        string sqlqry = "INSERT INTO CRMContacts (ContactName ,AccountMasterId ,OtherAccountName,DeveloperId,OtherDeveloperName ,AccountTypeId ,ProjectLocationId ,Address ,MobileNumber ,PhoneNumber ,ContactEmailAddress ,AccountManagerId ,ContactStatusId ,Budget,ReferralSourceId ,CreatedBy,CreationDate ,ModifiedBy,ModifiedDate)";
                        sqlqry += " VALUES  (@ContactName ,@AccountMasterId,@OtherAccountName ,@DeveloperId,@OtherDeveloperName ,@AccountTypeId ,@ProjectLocationId ,@Address ,@MobileNumber ,@PhoneNumber ,@ContactEmailAddress ,@AccountManagerId ,@ContactStatusId ,@Budget,@ReferralSourceId ,@CreatedBy,@CreationDate ,@ModifiedBy,@ModifiedDate)";

                        List<SqlParameter> parameterList = new List<SqlParameter>();
                        parameterList.Add(new SqlParameter("@ContactName", crmcontact.ContactName));
                        parameterList.Add(new SqlParameter("@AccountMasterId", crmcontact.AccountMasterId));
                        parameterList.Add(new SqlParameter("@OtherAccountName", crmcontact.OtherAccountName = crmcontact.OtherAccountName == null ? String.Empty : crmcontact.OtherAccountName));
                        parameterList.Add(new SqlParameter("@DeveloperId", crmcontact.DeveloperId));
                        parameterList.Add(new SqlParameter("@OtherDeveloperName", crmcontact.OtherDeveloperName = crmcontact.OtherDeveloperName == null ? String.Empty : crmcontact.OtherDeveloperName));
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
                        parameterList.Add(new SqlParameter("@CreatedBy", Session["UserId"]));
                        parameterList.Add(new SqlParameter("@CreationDate", DateTime.Now));
                        parameterList.Add(new SqlParameter("@ModifiedBy", Session["UserId"]));
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
                                    string sqlqry2 = "INSERT INTO FollowAlerts(ContactId,Comments ,FollowUpDate,FollowUpHH,FollowUpMM,FollowUpAMPM,RemindMe2Hours,RemindMeToDay,RemindMe2Days,Status,TypeofconversationId)";
                                    sqlqry2 += "Values(@ContactId,@Comments ,@FollowUpDate,@FollowUpHH,@FollowUpMM,@FollowUpAMPM,@RemindMe2Hours,@RemindMeToDay,@RemindMe2Days,@Status,@TypeofconversationId)";
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
                                    parameterList2.Add(new SqlParameter("@TypeofconversationId", crmcontact.TypeofconversationId));
                                    SqlParameter[] parameters2 = parameterList2.ToArray();
                                    int result2 = db.Database.ExecuteSqlCommand(sqlqry2, parameters2);
                                }
                            }
                        }
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
            BindTypeofconversations();
            BindReferralSources();
            BindAccountNames();
            BindDevelopers();
            BindAccountTypes();
            BindAccountManager();
            BindCity();
            BindContactStatus();
            BindFollowUpHH();
            BindFollowUpMM();
            return View(crmcontact);
        }

        public ActionResult ViewContact(int id = 0)
        {
            BindTypeofconversations();
            BindReferralSources();
            BindAccountNames();
            BindDevelopers();
            BindAccountTypes();
            BindAccountManager();
            BindCity();
            BindContactStatus();
            BindFollowUpHH();
            BindFollowUpMM();

            List<FollowAlerts> FollowAlertList = new List<FollowAlerts>();
            var quryalerts =
              from fa in db.FollowAlerts
              where fa.ContactId == id
              join typcon in db.Typeofconversations on fa.TypeofconversationId equals typcon.TypeofconversationId
              select new
              {
                  AlertId = fa.AlertId,
                  Comments = fa.Comments,
                  FollowUpDate = fa.FollowUpDate,
                  FollowUpHH = fa.FollowUpHH,
                  FollowUpMM = fa.FollowUpMM,
                  FollowUpAMPM = fa.FollowUpAMPM,
                  RemindMe2Hours = fa.RemindMe2Hours,
                  RemindMeToDay = fa.RemindMeToDay,
                  RemindMe2Days = fa.RemindMe2Days,
                  Status = fa.Status,
                  ContactId = fa.ContactId,
                  TypeofconversationName = typcon.TypeofconversationName
              };

            var FollowAlerts = quryalerts.ToList();
            foreach (var FollowAlertsData in FollowAlerts)
            {
                FollowAlertList.Add(new FollowAlerts()
                {
                    AlertId = FollowAlertsData.AlertId,
                    Comments = FollowAlertsData.Comments,
                    FollowUpDate = FollowAlertsData.FollowUpDate,
                    FollowUpHH = FollowAlertsData.FollowUpHH + ':' + FollowAlertsData.FollowUpMM + FollowAlertsData.FollowUpAMPM,
                    RemindMe2Hours = FollowAlertsData.RemindMe2Hours,
                    RemindMeToDay = FollowAlertsData.RemindMeToDay,
                    RemindMe2Days = FollowAlertsData.RemindMe2Days,
                    Status = FollowAlertsData.Status,
                    ContactId = FollowAlertsData.ContactId,
                    TypeofconversationName = FollowAlertsData.TypeofconversationName,

                });
            }

            ViewBag.FollowAlerts = FollowAlertList;
            var query = (from cr in db.CRMContact
                         where cr.ContactId == id
                         join cs in db.ContactStatus on cr.ContactStatusId equals cs.ContactStatusId
                         join dp in db.DeveloperMaster on cr.DeveloperId equals dp.DeveloperId
                         join amm in db.SignUp on cr.AccountManagerId equals amm.SignUpId
                         join ct in db.City on cr.ProjectLocationId equals ct.CityID
                         join acty in db.AccountTypeMaster on cr.AccountTypeId equals acty.AccountTypeId
                         join actnm in db.AccountMaster on cr.AccountMasterId equals actnm.AccountMasterId
                         join refs in db.ReferralSources on cr.ReferralSourceId equals refs.ReferralSourceId
                         select new
                         {
                             ContactId = cr.ContactId,
                             ContactName = cr.ContactName,
                             ContactEmailAddress = cr.ContactEmailAddress,
                             ContactStatusName = (cr.ContactStatusId == 0 ? String.Empty : cs.ContactStatusName),
                             DeveloperName = (cr.DeveloperId == 0 ? String.Empty : dp.DeveloperName),
                             OtherDeveloperName = cr.OtherDeveloperName,
                             ProjectLocationCity = (cr.ProjectLocationId == 0 ? String.Empty : ct.CityName),
                             AccountManagerName = (cr.AccountManagerId == 0 ? String.Empty : amm.FullName),
                             Address = cr.Address,
                             AccountTypeName = (cr.AccountTypeId == 0 ? String.Empty : acty.AccountTypeName),
                             CreationDate = cr.ModifiedDate,
                             AccountMasterName = (cr.AccountMasterId == 0 ? String.Empty : actnm.AccountMasterName),
                             OtherAccountName = cr.OtherAccountName,
                             MobileNumber = cr.MobileNumber,
                             PhoneNumber = cr.PhoneNumber,
                             Budget = cr.Budget,
                             ReferralSourceName = (cr.ReferralSourceId == 0 ? String.Empty : refs.ReferralSourceName),
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
                    OtherDeveloperName = query.OtherDeveloperName,
                    ProjectLocationCity = query.ProjectLocationCity,
                    AccountManagerName = query.AccountManagerName,
                    Address = query.Address,
                    AccountTypeName = query.AccountTypeName,
                    CreationDate = query.CreationDate,
                    AccountMasterName = query.AccountMasterName,
                    OtherAccountName = query.OtherAccountName,
                    MobileNumber = query.MobileNumber,
                    PhoneNumber = query.PhoneNumber,
                    Budget = query.Budget,
                    ReferralSourceName = query.ReferralSourceName,

                };
                return View(crmContact);
            }
            else
                return HttpNotFound();

        }
        public ActionResult Edit(int id = 0)
        {
            BindTypeofconversations();
            BindReferralSources();
            BindAccountNames();
            BindDevelopers();
            BindAccountTypes();
            BindAccountManager();
            BindCity();
            BindContactStatus();
            BindFollowUpHH();
            BindFollowUpMM();
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
            //var user = db.CRMContact.Where(u => u.ContactEmailAddress == crmcontact.ContactEmailAddress).FirstOrDefault();
            //if (user == null)
            //{
            //    var ckmobile = db.CRMContact.Where(u => u.MobileNumber == crmcontact.MobileNumber).FirstOrDefault();
            //    if (ckmobile == null)
            //    {

            if (ModelState.IsValid)
            {
                string sqlqry = "UPDATE CRMContacts SET ContactName=@ContactName ,AccountMasterId=@AccountMasterId,OtherAccountName=@OtherAccountName ,DeveloperId=@DeveloperId,OtherDeveloperName=@OtherDeveloperName,AccountTypeId=@AccountTypeId ,ProjectLocationId=@ProjectLocationId ,Address=@Address ,PhoneNumber=@PhoneNumber ,";
                sqlqry += "AccountManagerId=@AccountManagerId ,ContactStatusId=@ContactStatusId ,Budget=@Budget,ReferralSourceId=@ReferralSourceId ,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate";
                sqlqry += " Where ContactId=@ContactId";
                List<SqlParameter> parameterList = new List<SqlParameter>();
                parameterList.Add(new SqlParameter("@ContactId", crmcontact.ContactId));
                parameterList.Add(new SqlParameter("@ContactName", crmcontact.ContactName));
                parameterList.Add(new SqlParameter("@AccountMasterId", crmcontact.AccountMasterId));
                parameterList.Add(new SqlParameter("@OtherAccountName", crmcontact.OtherAccountName = crmcontact.OtherAccountName == null ? String.Empty : crmcontact.OtherAccountName));
                parameterList.Add(new SqlParameter("@DeveloperId", crmcontact.DeveloperId));
                parameterList.Add(new SqlParameter("@OtherDeveloperName", crmcontact.OtherDeveloperName = crmcontact.OtherDeveloperName == null ? String.Empty : crmcontact.OtherDeveloperName));
                parameterList.Add(new SqlParameter("@AccountTypeId", crmcontact.AccountTypeId));
                parameterList.Add(new SqlParameter("@ProjectLocationId", crmcontact.ProjectLocationId));
                parameterList.Add(new SqlParameter("@Address", crmcontact.Address));
                parameterList.Add(new SqlParameter("@PhoneNumber", crmcontact.PhoneNumber));
                parameterList.Add(new SqlParameter("@AccountManagerId", crmcontact.AccountManagerId));
                parameterList.Add(new SqlParameter("@ContactStatusId", crmcontact.ContactStatusId));
                parameterList.Add(new SqlParameter("@Budget", crmcontact.Budget));
                parameterList.Add(new SqlParameter("@ReferralSourceId", crmcontact.ReferralSourceId));
                parameterList.Add(new SqlParameter("@ModifiedBy", Session["UserId"]));
                parameterList.Add(new SqlParameter("@ModifiedDate", DateTime.Now));

                SqlParameter[] parameters = parameterList.ToArray();
                int result = (int)db.Database.ExecuteSqlCommand(sqlqry, parameters);
                if (result != null)
                {
                    if (crmcontact.FollowUpDate != null)
                    {
                        /////--------Insert Data in FollowAlerts---///
                        string sqlqry2 = "INSERT INTO FollowAlerts(ContactId,Comments ,FollowUpDate,FollowUpHH,FollowUpMM,FollowUpAMPM,RemindMe2Hours,RemindMeToDay,RemindMe2Days,Status,TypeofconversationId)";
                        sqlqry2 += "Values(@ContactId,@Comments ,@FollowUpDate,@FollowUpHH,@FollowUpMM,@FollowUpAMPM,@RemindMe2Hours,@RemindMeToDay,@RemindMe2Days,@Status,@TypeofconversationId)";
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
                        parameterList2.Add(new SqlParameter("@TypeofconversationId", crmcontact.TypeofconversationId));//1 for yes and 2 no//
                        SqlParameter[] parameters2 = parameterList2.ToArray();
                        int result2 = db.Database.ExecuteSqlCommand(sqlqry2, parameters2);
                    }
                }
                return RedirectToAction("ViewContact", "CRM", new { id = crmcontact.ContactId });
            }
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Mobile Number already exists");
            //    }

            //}
            //else
            //{
            //    ModelState.AddModelError("", "Email Address already exists");
            //}

            BindTypeofconversations();
            BindReferralSources();
            BindAccountNames();
            BindDevelopers();
            BindAccountTypes();
            BindAccountManager();
            BindCity();
            BindContactStatus();
            BindFollowUpHH();
            BindFollowUpMM();
            return View(crmcontact);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [HttpPost]
        public ActionResult ExportData()
        {
            IList<ExportData> ExportDataontactList = new List<ExportData>();
            var query = from cr in db.CRMContact
                        join cs in db.ContactStatus on cr.ContactStatusId equals cs.ContactStatusId
                        join dp in db.DeveloperMaster on cr.DeveloperId equals dp.DeveloperId
                        join amm in db.AccountManagerMaster on cr.AccountManagerId equals amm.AccountManagerId
                        join ct in db.City on cr.ProjectLocationId equals ct.CityID
                        join acty in db.AccountTypeMaster on cr.AccountTypeId equals acty.AccountTypeId
                        join actnm in db.AccountMaster on cr.AccountMasterId equals actnm.AccountMasterId
                        join refs in db.ReferralSources on cr.ReferralSourceId equals refs.ReferralSourceId
                        select new
                        {
                            ContactName = cr.ContactName,
                            ContactEmailAddress = cr.ContactEmailAddress,
                            ContactStatusName = (cr.ContactStatusId == 0 ? String.Empty : cs.ContactStatusName),
                            DeveloperName = (cr.DeveloperId == 0 ? String.Empty : dp.DeveloperName == "Other" ? cr.OtherDeveloperName : dp.DeveloperName),
                            OtherDeveloperName = cr.OtherDeveloperName,
                            ProjectLocationCity = (cr.ProjectLocationId == 0 ? String.Empty : ct.CityName),
                            AccountManagerName = (cr.AccountManagerId == 0 ? String.Empty : amm.AccountManagerName),
                            Address = cr.Address,
                            AccountTypeName = (cr.AccountTypeId == 0 ? String.Empty : acty.AccountTypeName),
                            CreationDate = cr.ModifiedDate,
                            AccountMasterName = (cr.AccountMasterId == 0 ? String.Empty : actnm.AccountMasterName == "Other" ? cr.OtherAccountName : actnm.AccountMasterName),
                            MobileNumber = cr.MobileNumber,
                            PhoneNumber = cr.PhoneNumber,
                            Budget = cr.Budget,
                            ReferralSourceName = (cr.ReferralSourceId == 0 ? String.Empty : refs.ReferralSourceName),
                            ModifiedDate = cr.ModifiedDate
                        };

            var ExportContacts = query.ToList();
            foreach (var ExportData in ExportContacts)
            {
                ExportDataontactList.Add(new ExportData()
                {
                    ContactName = ExportData.ContactName,
                    ContactEmailAddress = ExportData.ContactEmailAddress,
                    ContactStatusName = ExportData.ContactStatusName,
                    DeveloperName = ExportData.DeveloperName,
                    ProjectLocationCity = ExportData.ProjectLocationCity,
                    AccountManagerName = ExportData.AccountManagerName,
                    Address = ExportData.Address,
                    AccountTypeName = ExportData.AccountTypeName,
                    AccountMasterName = ExportData.AccountMasterName,
                    MobileNumber = ExportData.MobileNumber,
                    PhoneNumber = ExportData.PhoneNumber,
                    Budget = ExportData.Budget,
                    ReferralSourceName = ExportData.ReferralSourceName,
                    CreationDate = ExportData.ModifiedDate,

                });
            }
            GridView gv = new GridView();
            gv.DataSource = ExportDataontactList;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=AccountDetails.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ImportData()
        {
            var r = new List<UploadFilesResult>();
            string savedFileName = string.Empty;
            string fileExtension = string.Empty;
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                savedFileName = Path.Combine(Server.MapPath("~/CRMFiles"), Path.GetFileName(DateTime.Now.Millisecond + hpf.FileName));
                fileExtension = System.IO.Path.GetExtension(hpf.FileName);
                hpf.SaveAs(savedFileName);

                r.Add(new UploadFilesResult()
                {
                    Name = hpf.FileName,
                    Length = hpf.ContentLength,
                    Type = hpf.ContentType
                });
            }

            if (r[0].Length > 0)
            {
                try
                {
                    DataContext context = new DataContext();

                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        ExcelParser excelObj;

                        excelObj = new ExcelParser();
                        DataTable dt1 = new DataTable("ReturnTable");// = excelObj.ExcelContent(filename, true,"");


                        string SheetName = "Account";
                        string AgainstType = "contact";


                        DataSet dsXmlFields = excelObj.XmlColumnDefSynonym(AgainstType, ConfigurationManager.ConnectionStrings["ConRenderLogyNew"].ToString(), Server.MapPath("~/CRMFiles/"));
                        if (dsXmlFields.Tables.Count > 1)
                        {
                            DataTable dtExcel = excelObj.ExcelColumnDef(savedFileName, true, SheetName);
                            if (dtExcel.Rows.Count > 0)
                            {
                                var queryRes = (from cs in dsXmlFields.Tables["Name"].AsEnumerable()
                                                join cs1 in dsXmlFields.Tables["Synonyms"].AsEnumerable() on cs["Field_Id"].ToString().ToLower().Trim() equals cs1["Field_Id"].ToString().ToLower().Trim()
                                                join cs2 in dsXmlFields.Tables["Synonym"].AsEnumerable() on cs1["Synonyms_Id"].ToString().ToLower().Trim() equals cs2["Synonyms_Id"].ToString().ToLower().Trim()
                                                join c in dtExcel.AsEnumerable() on cs["Name_Text"].ToString().ToLower().Trim() equals c["COLUMN_NAME"].ToString().ToLower().Trim()
                                                orderby Convert.ToInt32(cs["ColumnOrder"].ToString())
                                                select cs["Name_Text"]).Distinct().ToList();
                                dt1 = excelObj.GetSpecificColumnsValue(savedFileName, true, SheetName, queryRes, "");
                            }
                        }
                        using (System.IO.StringWriter writer = new System.IO.StringWriter())
                        {
                            dt1.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                            StringBuilder getdata = new StringBuilder();
                            getdata.Append(writer);
                            writer.Close();
                            writer.Flush();
                            writer.Close();

                            var connectionString = ConfigurationManager.ConnectionStrings["ConRenderLogyNew"].ConnectionString;

                            using (var connection = new SqlConnection(connectionString))
                            {
                                var command = new SqlCommand("sp_SaveAccountXML", connection);
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@AccountDetailsXML", getdata.ToString());
                                command.Parameters.AddWithValue("@UserId", Session["UserId"]);
                                connection.Open();

                                command.ExecuteNonQuery();

                                connection.Close();
                            }

                        }
                    }
                    else
                    {
                        if (System.IO.File.Exists(savedFileName))
                        {

                            System.IO.File.Delete(savedFileName);
                        }
                        ModelState.AddModelError("", "Invalid file");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                finally
                {
                    if (System.IO.File.Exists(savedFileName))
                    {

                        System.IO.File.Delete(savedFileName);
                    }
                }
            }
            return RedirectToAction("Index", "CRM");

        }

        public ActionResult SeacrhContact(CRMContact crmContact)
        {

            return RedirectToAction("Index", "CRM", crmContact);
        }
        public ActionResult IndexClear()
        {

            return RedirectToAction("Index", "CRM");
        }
        public ActionResult UpdateHistory(int id = 0)
        {

            var query = (from Falw in db.FollowAlerts
                         where Falw.AlertId == id
                         join typec in db.Typeofconversations on Falw.TypeofconversationId equals typec.TypeofconversationId
                         select new
                         {
                             AlertId = Falw.AlertId,
                             Comments = Falw.Comments,
                             FollowUpDate = Falw.FollowUpDate,
                             FollowUpHH = Falw.FollowUpHH,
                             FollowUpMM = Falw.FollowUpMM,
                             FollowUpAMPM = Falw.FollowUpAMPM,
                             TypeofconversationName = typec.TypeofconversationName,

                         }).FirstOrDefault();

            if (query != null)
            {
                FollowAlerts followAlerts = new FollowAlerts()
                {
                    AlertId = query.AlertId,
                    Comments = query.Comments,
                    FollowUpDate = query.FollowUpDate,
                    FollowUpHH = query.FollowUpHH +':'+query.FollowUpMM +query.FollowUpAMPM,                   
                    TypeofconversationName = query.TypeofconversationName,
                };
                return View(followAlerts);
            }
            else
                return HttpNotFound();
        }
        [HttpPost]
        public ActionResult UpdateHistory(FollowAlerts followAlerts)
        {          
                if (ModelState.IsValid)
                {
                    string sqlqry = "UPDATE FollowAlerts SET Comments=@Comments  Where AlertId=@AlertId";
                    List<SqlParameter> parameterList = new List<SqlParameter>();
                    parameterList.Add(new SqlParameter("@AlertId", followAlerts.AlertId));
                    parameterList.Add(new SqlParameter("@Comments", followAlerts.Comments));

                    SqlParameter[] parameters = parameterList.ToArray();
                    int result = (int)db.Database.ExecuteSqlCommand(sqlqry, parameters);
                    TempData["successmsg"] = "Update Successfully";
                }
                return RedirectToAction("UpdateHistory", "CRM", new { id = followAlerts.AlertId });
            
        }
        public ActionResult SendInvitationtoUser(int id=0)
        {
            var user = db.CRMContact.Where(u => u.ContactId == 1).FirstOrDefault();
            string sqlqry = "INSERT INTO Customers (Contid,Email,IsActive,CreationDate,CreatedBy)";
            sqlqry += " VALUES  (@Contid,@Email,@IsActive,@CreationDate,@CreatedBy)";

            List<SqlParameter> parameterList = new List<SqlParameter>();
            parameterList.Add(new SqlParameter("@Contid", user.ContactId));
            parameterList.Add(new SqlParameter("@Email", user.ContactEmailAddress));
            parameterList.Add(new SqlParameter("@IsActive", false));

            parameterList.Add(new SqlParameter("@CreationDate", DateTime.Now));
            parameterList.Add(new SqlParameter("@CreatedBy", 1));


            SqlParameter[] parameters = parameterList.ToArray();
            int result = (int)db.Database.ExecuteSqlCommand(sqlqry, parameters);
            MailUtil objMailUtil = new MailUtil();
            objMailUtil.InviteNewCustomer(user.ContactEmailAddress, user.ContactId);
           
            return RedirectToAction("Index");
        }
    }
}