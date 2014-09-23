using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace RgyDAL
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

      //  public virtual ICollection<Role> Roles { get; set; }
    }

   
    public class UsersData
    {        
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
    }
}