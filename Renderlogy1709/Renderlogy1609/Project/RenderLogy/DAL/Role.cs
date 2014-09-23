using RenderLogy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenderLogy.DAL
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<SignUp> SignUp { get; set; }
    }
}