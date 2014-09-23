using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RenderLogy.DAL;
using RenderLogy.Models;

namespace RenderLogy.DAL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("ConRenderLogy")
        {
        }
        public DbSet<SignUp> SignUp { get; set; }
        public DbSet<States> State { get; set; }
        public DbSet<Cities> City { get; set; }
        
        public DbSet<Role> Roles { get; set; }

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