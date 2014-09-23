using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace RgyDAL
{
    public class CustomPrincipal : IPrincipal
    {

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

        public IIdentity Identity
        {
            get;
            private set;
        }

        public bool IsInRole(string role)
        {
            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
                return false;
        }

        public string[] Roles { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string NotificationNo {get;set;}
    }

    public class UserData
    {
        public string[] Roles { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string NotificationNo { get; set; }
    }
}