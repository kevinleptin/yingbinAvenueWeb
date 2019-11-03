namespace yingbinAvenueWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forRoseWoodEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoseWoodEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 200),
                        MobiPhone = c.String(maxLength: 15),
                        Email = c.String(maxLength: 200),
                        CreateOn = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 50),
                        Province = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoseWoodEntities");
        }
    }
}
