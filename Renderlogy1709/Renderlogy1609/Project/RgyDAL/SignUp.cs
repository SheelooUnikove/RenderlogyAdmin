using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RgyDAL
{
    public class SignUp
    {

        [Key]
        public int SignUpId { get; set; }
        [Required(ErrorMessage = "Please Enter name of design house ")]
        public string DesignHouseName { get; set; }
        //[Required(ErrorMessage = "Please Enter FirstName")]
        //public string FirstName { get; set; }
        //[Required(ErrorMessage = "Please Enter LastName")]
        //public string LastName { get; set; }
        //[Required(ErrorMessage = "Please Enter Middle Name")]
        //public string MiddleName { get; set; }
        //[Required(ErrorMessage = "Please Enter Full Name")]
        //[NotMapped]
        //public string FullName { get; set; }

        [Required(ErrorMessage = "Please Enter Name of the account manager")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please Enter Account Manager EmailId")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please Enter correct Email Format")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please Enter Offical Address of design house")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please select State ")]
        public int? State { get; set; }

        public string StateName { get; set; }
        [Required(ErrorMessage = "Please select City")]
        public int? City { get; set; }


        public string CityName { get; set; }
        [Required(ErrorMessage = "Please Enter Phone No of account manager")]
        public string PhoneNo { get; set; }
        // [Required(ErrorMessage = "Please Enter Account DisplayName")]
        //public string PhoneNoAcNo { get; set; }
        [Required(ErrorMessage = "Please Enter No of Employee personnel in design house")]
        public string NoOfEmployeeDesHouse { get; set; }
        [Required(ErrorMessage = "Please Enter Password:")]
        // [MaxLength(30, ErrorMessage = "Max 30 characters")]
        //[MinLength(6, ErrorMessage = "password greater than 6 characters")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "password greater than 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter ConfirmPassword")]
        // [Compare("Password", ErrorMessage = "Confirm Password doesnot matched")]
        [CompareAttribute("Password", ErrorMessage = "Password mismatch")]
        //[MaxLength(30, ErrorMessage = "Max 30 characters")]
        //[MinLength(6, ErrorMessage = "password greater than 6 characters")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "password greater than 6 characters")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public string RandomPwd { get; set; }
       // //public virtual ICollection<Cities> Cities { get; set; }
       // //public virtual ICollection<States> States { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
   

  
}