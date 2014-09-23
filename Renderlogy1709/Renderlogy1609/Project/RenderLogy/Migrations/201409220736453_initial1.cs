namespace RenderLogy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Cusid = c.Int(nullable: false, identity: true),
                        Contid = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        UnitId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Cusid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
