using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RenderLogy.DAL
{
    public class SignUp
    {
        //public SignUp()
        //{
        //    IsActive = false;
        //    StateName = "delhi";
        //    CityName = "del";
        //    RoleName = "Admin";

        //}
        public int SignUpId { get; set; }
        [Required(ErrorMessage = "Please Enter name of design house ")]
        public string DesignHouseName { get; set; }

        [Required(ErrorMessage = "Please Enter Name of the account manager")]
        public string AccountManagerName { get; set; }
        [Required(ErrorMessage = "Please Enter Account Manager EmailId")]

        public string AccountMgrEmailId { get; set; }
        [Required(ErrorMessage = "Please Enter Offical Address of design house")]
        public string CurrentOfficalAddress { get; set; }

        [Required(ErrorMessage = "Please select State ")]
        public int? State { get; set; }
        
        public string StateName { get; set; }
        [Required(ErrorMessage = "Please select City")]
        public int? City { get; set; }
        public string CityName { get; set; }
        [Required(ErrorMessage = "Please Enter Phone No of account manager")]
        public string PhoneNoAcManger { get; set; }
        // [Required(ErrorMessage = "Please Enter Account DisplayName")]
        //public string PhoneNoAcNo { get; set; }
        [Required(ErrorMessage = "Please Enter No of Employee personnel in design house")]
        public string NoOfEmployeeDesHouse { get; set; }
        //[Required(ErrorMessage = "Please Enter Password:")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Password:")]
        //[MaxLength(30, ErrorMessage = "Max 30 characters")]
        //[MinLength(6, ErrorMessage = "password greater than 6 characters")]
       // [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter ConfirmPassword")]
       // [Compare("Password", ErrorMessage = "Confirm Password doesnot matched")]
        //[MaxLength(30, ErrorMessage = "Max 30 characters")]
        //[MinLength(6, ErrorMessage = "password greater than 6 characters")]
       // [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; }


        public string RoleName { get; set; }
        public bool IsActive { get; set; }

       // //public virtual ICollection<Cities> Cities { get; set; }
       // //public virtual ICollection<States> States { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}