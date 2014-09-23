using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace RgyDAL
{
    public class DataContext : DbContext
    {
        public DataContext(): base("ConRenderLogyNew")
        {
        }
        public DbSet<SignUp> SignUp { get; set; }
        public DbSet<States> State { get; set; }
        public DbSet<Cities> City { get; set; }        
        public DbSet<Role> Roles { get; set; }
        public DbSet<EngagementTypes> EngagementType{ get; set; }
      
        public DbSet<TagsDictionary> TagDictionary { get; set; }
        public DbSet<mailsData> mailsData { get; set; }



        //----CRM------//
        public DbSet<CRMContact> CRMContact { get; set; }
        public DbSet<ContactStatus> ContactStatus { get; set; }
        public DbSet<AccountMaster> AccountMaster { get; set; }
        public DbSet<AccountManagerMaster> AccountManagerMaster { get; set; }
        public DbSet<AccountTypeMaster> AccountTypeMaster { get; set; }
        public DbSet<DeveloperMaster> DeveloperMaster { get; set; }
        public DbSet<ReferralSources> ReferralSources { get; set; }
        public DbSet<Typeofconversations> Typeofconversations { get; set; }
        public DbSet<FollowAlerts> FollowAlerts { get; set; }
        public DbSet<Customers> Customers { get; set; }
        //--End CRM--//

        //--CRM ACCOUNT MASTER--//
        public DbSet<CRMAccountMaster> CRMAccountMaster { get; set; }
        public DbSet<AccountMasterStatus> AccountMasterStatus { get; set; }
        public DbSet<AccountMasterContacts> AccountMasterContacts { get; set; }
        //

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(u => u.Users).Map(u =>
            //{
            //    u.MapLeftKey("UserId");
            //    u.MapRightKey("RoleId");
            //    u.ToTable("UserRoles");
            //});
            modelBuilder.Entity<SignUp>().HasMany(u => u.Roles).WithMany(u => u.SignUp).Map(u =>
            {
                u.MapLeftKey("SignUpId");
                u.MapRightKey("RoleId");
                u.ToTable("UserRoles");
            });
        }
    }
}