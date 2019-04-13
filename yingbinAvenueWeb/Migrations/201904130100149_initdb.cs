namespace yingbinAvenueWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntryForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 20),
                        MobiPhone = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.MobiPhone, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.EntryForms", new[] { "MobiPhone" });
            DropTable("dbo.EntryForms");
        }
    }
}
