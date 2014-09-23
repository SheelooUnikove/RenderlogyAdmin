namespace RenderLogy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SignUps",
                c => new
                    {
                        SignUpId = c.Int(nullable: false, identity: true),
                        DesignHouseName = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        EmailId = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        StateName = c.String(),
                        City = c.Int(nullable: false),
                        CityName = c.String(),
                        PhoneNo = c.String(nullable: false),
                        NoOfEmployeeDesHouse = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 40),
                        RoleName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        RandomPwd = c.String(),
                    })
                .PrimaryKey(t => t.SignUpId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        StatName = c.String(),
                    })
                .PrimaryKey(t => t.StateID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        StateID = c.Int(),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.States", t => t.StateID)
                .Index(t => t.StateID);
            
            CreateTable(
                "dbo.EngagementTypes",
                c => new
                    {
                        EngagementTypesId = c.Int(nullable: false, identity: true),
                        EngagementTitle = c.String(),
                    })
                .PrimaryKey(t => t.EngagementTypesId);
            
            CreateTable(
                "dbo.TagsDictionary",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagTitle = c.String(),
                        Action = c.String(),
                        ActionAPI = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.mailsData",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        FromEmail = c.String(),
                        ToEmail = c.String(),
                        CC = c.String(),
                        BCC = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        AttachFileName = c.String(),
                        EmailRecvDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.CRMContacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactName = c.String(nullable: false),
                        AccountMasterId = c.Int(nullable: false),
                        OtherAccountName = c.String(),
                        DeveloperId = c.Int(nullable: false),
                        OtherDeveloperName = c.String(),
                        AccountTypeId = c.Int(nullable: false),
                        ProjectLocationId = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        ContactEmailAddress = c.String(nullable: false),
                        AccountManagerId = c.Int(nullable: false),
                        ContactStatusId = c.Int(nullable: false),
                        Budget = c.String(nullable: false),
                        ReferralSourceId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreationDate = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.ContactStatus",
                c => new
                    {
                        ContactStatusId = c.Int(nullable: false, identity: true),
                        ContactStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ContactStatusId);
            
            CreateTable(
                "dbo.AccountMasters",
                c => new
                    {
                        AccountMasterId = c.Int(nullable: false, identity: true),
                        AccountMasterName = c.String(),
                    })
                .PrimaryKey(t => t.AccountMasterId);
            
            CreateTable(
                "dbo.AccountManagerMasters",
                c => new
                    {
                        AccountManagerId = c.Int(nullable: false, identity: true),
                        AccountManagerName = c.String(),
                    })
                .PrimaryKey(t => t.AccountManagerId);
            
            CreateTable(
                "dbo.AccountTypeMasters",
                c => new
                    {
                        AccountTypeId = c.Int(nullable: false, identity: true),
                        AccountTypeName = c.String(),
                    })
                .PrimaryKey(t => t.AccountTypeId);
            
            CreateTable(
                "dbo.DeveloperMasters",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false, identity: true),
                        DeveloperName = c.String(),
                    })
                .PrimaryKey(t => t.DeveloperId);
            
            CreateTable(
                "dbo.ReferralSources",
                c => new
                    {
                        ReferralSourceId = c.Int(nullable: false, identity: true),
                        ReferralSourceName = c.String(),
                    })
                .PrimaryKey(t => t.ReferralSourceId);
            
            CreateTable(
                "dbo.Typeofconversations",
                c => new
                    {
                        TypeofconversationId = c.Int(nullable: false, identity: true),
                        TypeofconversationName = c.String(),
                    })
                .PrimaryKey(t => t.TypeofconversationId);
            
            CreateTable(
                "dbo.FollowAlerts",
                c => new
                    {
                        AlertId = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Comments = c.String(),
                        FollowUpDate = c.DateTime(),
                        FollowUpHH = c.String(),
                        FollowUpMM = c.String(),
                        FollowUpAMPM = c.String(),
                        RemindMe2Hours = c.Boolean(nullable: false),
                        RemindMeToDay = c.Boolean(nullable: false),
                        RemindMe2Days = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        TypeofconversationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlertId);
            
            CreateTable(
                "dbo.CRMAccountMasters",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountMasterName = c.String(nullable: false),
                        DeveloperName = c.String(nullable: false),
                        AccountTypeId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        ProjectWebsite = c.String(nullable: false),
                        AccountManagerId = c.Int(nullable: false),
                        AccountStatusId = c.Int(nullable: false),
                        Comments = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreationDate = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.AccountMasterStatus",
                c => new
                    {
                        AccountStatusId = c.Int(nullable: false, identity: true),
                        AccountStatusName = c.String(),
                    })
                .PrimaryKey(t => t.AccountStatusId);
            
            CreateTable(
                "dbo.AccountMasterContacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        AccountId = c.Int(nullable: false),
                        MobileNumber = c.String(),
                        PhoneNumber = c.String(),
                        ContactEmailAddress = c.String(),
                        CreationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        SignUpId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SignUpId, t.RoleId })
                .ForeignKey("dbo.SignUps", t => t.SignUpId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.SignUpId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "SignUpId" });
            DropIndex("dbo.Cities", new[] { "StateID" });
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "SignUpId", "dbo.SignUps");
            DropForeignKey("dbo.Cities", "StateID", "dbo.States");
            DropTable("dbo.UserRoles");
            DropTable("dbo.AccountMasterContacts");
            DropTable("dbo.AccountMasterStatus");
            DropTable("dbo.CRMAccountMasters");
            DropTable("dbo.FollowAlerts");
            DropTable("dbo.Typeofconversations");
            DropTable("dbo.ReferralSources");
            DropTable("dbo.DeveloperMasters");
            DropTable("dbo.AccountTypeMasters");
            DropTable("dbo.AccountManagerMasters");
            DropTable("dbo.AccountMasters");
            DropTable("dbo.ContactStatus");
            DropTable("dbo.CRMContacts");
            DropTable("dbo.mailsData");
            DropTable("dbo.TagsDictionary");
            DropTable("dbo.EngagementTypes");
            DropTable("dbo.Cities");
            DropTable("dbo.States");
            DropTable("dbo.Roles");
            DropTable("dbo.SignUps");
        }
    }
}
