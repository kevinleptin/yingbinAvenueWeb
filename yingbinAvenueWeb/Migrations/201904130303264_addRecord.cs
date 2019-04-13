namespace yingbinAvenueWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRecord : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApiInvokeRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(maxLength: 200),
                        CreateOn = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.EntryForms", "CreateOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.EntryForms", "CreateBy", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EntryForms", "CreateBy");
            DropColumn("dbo.EntryForms", "CreateOn");
            DropTable("dbo.ApiInvokeRecords");
        }
    }
}
