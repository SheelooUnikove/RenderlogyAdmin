using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RgyDAL
{
    public class CRMContact
    {
        [Key]
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Please Enter Contact Name")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "Please Select Account Name")]
        public int AccountMasterId { get; set; }
        public string OtherAccountName { get; set; }
        [NotMapped]
        public string AccountMasterName { get; set; }
        [Required(ErrorMessage = "Please Select Developer Name")]
        public int DeveloperId { get; set; }
        [NotMapped]
        public string DeveloperName { get; set; }
        public string OtherDeveloperName { get; set; }
        [Required(ErrorMessage = "Please Select Account Type")]
        public int AccountTypeId { get; set; }
        [NotMapped]
        public string AccountTypeName { get; set; }
        [Required(ErrorMessage = "Please Select City")]
        public int ProjectLocationId { get; set; }
        [NotMapped]
        public string ProjectLocationCity { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Account Manager EmailId")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please Enter correct Email Format")]
        public string ContactEmailAddress { get; set; }
        [Required(ErrorMessage = "Please Select Account Manager Name")]
        public int AccountManagerId { get; set; }
        [NotMapped]
        public string AccountManagerName { get; set; }
        [Required(ErrorMessage = "Please Select Contact Status")]
        public int ContactStatusId { get; set; }
        [NotMapped]
        public string ContactStatusName { get; set; }


        [Required(ErrorMessage = "Please Enter Budget")]
        public string Budget { get; set; }
        [Required(ErrorMessage = "Please Select Referral Source")]
        public int ReferralSourceId { get; set; }
        [NotMapped]
        public string ReferralSourceName { get; set; }

        [NotMapped]
        public int TypeofconversationId { get; set; }
        [NotMapped]
        public string TypeofconversationName { get; set; }


        public int CreatedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreationDate { get; set; }
        public int ModifiedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Follow
        /// </summary>
        /// 
        [NotMapped]
        public string Comments { get; set; }
        [NotMapped]
        public DateTime? FollowUpDate { get; set; }
        [NotMapped]
        public string FollowUpHH { get; set; }
        [NotMapped]
        public string FollowUpMM { get; set; }
        [NotMapped]
        public string FollowUpAMPM { get; set; }
        [NotMapped]
        public bool RemindMe2Hours { get; set; }
        [NotMapped]
        public bool RemindMeToDay { get; set; }
        [NotMapped]
        public bool RemindMe2Days { get; set; }
        [NotMapped]
        public DateTime? CreationDateEnd { get; set; }
        
        [NotMapped]
        public bool IsActive { get; set; }
    }

   
    public class FollowAlerts
    {
        [Key]
        public int AlertId { get; set; }
        public int ContactId { get; set; }
        public string Comments { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string FollowUpHH { get; set; }
        public string FollowUpMM { get; set; }
        public string FollowUpAMPM { get; set; }
        public bool RemindMe2Hours { get; set; }
        public bool RemindMeToDay { get; set; }
        public bool RemindMe2Days { get; set; }
        public int Status { get; set; }
        public int TypeofconversationId { get; set; }
        [NotMapped]
        public string TypeofconversationName { get; set; }
    }
    public class ContactStatus
    {
        [Key]
        public int? ContactStatusId { get; set; }
        public string ContactStatusName { get; set; }
    }
    public class AccountMaster
    {
        [Key]
        public int? AccountMasterId { get; set; }
        public string AccountMasterName { get; set; }
    }
    public class DeveloperMaster
    {
        [Key]
        public int? DeveloperId { get; set; }
        public string DeveloperName { get; set; }
    }
    public class AccountTypeMaster
    {
        [Key]
        public int? AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }
    }
    public class AccountManagerMaster
    {
        [Key]
        public int? AccountManagerId { get; set; }
        public string AccountManagerName { get; set; }
    }
    public class ReferralSources
    {
        [Key]
        public int? ReferralSourceId { get; set; }
        public string ReferralSourceName { get; set; }
    }
    public class Typeofconversations
    {
        [Key]
        public int TypeofconversationId { get; set; }
        public string TypeofconversationName { get; set; }
    }
    public class FollowUpHH
    {
        public int? FollowUpHHId { get; set; }
        public string FollowUpHHName { get; set; }
    }
    public class FollowUpMM
    {
        public int? FollowUpMMId { get; set; }
        public string FollowUpMMName { get; set; }
    }

    public class ExportData
    {
        public string ContactName { get; set; }
        public string ContactStatusName { get; set; }
        public string DeveloperName { get; set; }
        public string ProjectLocationCity { get; set; }
        public string AccountManagerName { get; set; }
        public string ContactEmailAddress { get; set; }
        public string Address { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountMasterName { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Budget { get; set; }
        public string ReferralSourceName { get; set; }
        public DateTime? CreationDate { get; set; }
    }
    public class States
    {
        [Key]
        public int? StateID { get; set; }
        public string StatName { get; set; }
        public virtual ICollection<Cities> City { get; set; }
    }

    public class Cities
    {
        [Key]
        public int? CityID { get; set; }
        public string CityName { get; set; }
        [ForeignKey("State")]
        public int? StateID { get; set; }
        public virtual States State { get; set; }

    }

    public class UploadFilesResult
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
    }
    public class Customers
    {
        [Key]
        public int Cusid { get; set; }
        public int Contid { get; set; }
        public string  Email { get; set; }
        public string Password { get; set; }
        public int UnitId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
