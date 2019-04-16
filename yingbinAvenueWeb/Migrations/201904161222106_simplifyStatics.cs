namespace yingbinAvenueWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class simplifyStatics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteStatics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);

            Sql("INSERT INTO SiteStatics([count]) Select 0");

            AlterColumn("dbo.EntryForms", "UserName", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EntryForms", "UserName", c => c.String(maxLength: 20));
            DropTable("dbo.SiteStatics");
        }
    }
}
