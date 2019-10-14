namespace yingbinAvenueWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bayerinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurveyEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserIp = c.String(maxLength: 50),
                        UserLocalId = c.String(maxLength: 50),
                        Subject1 = c.Int(nullable: false),
                        Subject2 = c.String(nullable: false, maxLength: 100),
                        Subject3 = c.String(maxLength: 1000),
                        Subject4 = c.String(maxLength: 1000),
                        Subject5 = c.String(maxLength: 1000),
                        Subject6 = c.String(maxLength: 1000),
                        Subject7 = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SurveyEntities");
        }
    }
}
