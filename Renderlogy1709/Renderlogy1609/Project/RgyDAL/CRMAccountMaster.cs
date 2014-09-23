using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RgyDAL
{
    public class CRMAccountMaster
    {
        [Key]
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Please Select Account Name")]       
        public string AccountMasterName { get; set; }
        [Required(ErrorMessage = "Please Select Developer Name")]     
        public string DeveloperName { get; set; }
        [Required(ErrorMessage = "Please Select Account Type")]
        public int AccountTypeId { get; set; }       
        [Required(ErrorMessage = "Please Select City")]
        public int CityId { get; set; }
        [NotMapped]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }        
        [Required(ErrorMessage = "Please Select Account Manager Name")]
        public string ProjectWebsite { get; set; }
        [Required(ErrorMessage = "Please Enter WebSite Address")]
        public int AccountManagerId { get; set; }
        [NotMapped]
        public string AccountManagerName { get; set; }
        [Required(ErrorMessage = "Please Select Account Status")]
        public int AccountStatusId { get; set; }
        [NotMapped]
        public string AccountStatusName { get; set; }
        public string Comments { get; set; }

        public int CreatedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreationDate { get; set; }
        public int ModifiedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedDate { get; set; }

       
    }

    public class AccountMasterStatus
    {
        [Key]
        public int AccountStatusId { get; set; }
        public string AccountStatusName { get; set; }
    }

    public class AccountMasterContacts
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int AccountId { get; set; }
      
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please Enter correct Email Format")]
        public string ContactEmailAddress { get; set; }     
 
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreationDate { get; set; }
      
    }
}
