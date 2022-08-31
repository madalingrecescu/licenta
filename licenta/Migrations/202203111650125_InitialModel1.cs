namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PanouSolars",
                c => new
                    {
                        PanouId = c.Int(nullable: false, identity: true),
                        NumePanou = c.String(),
                        AriePanou = c.Int(nullable: false),
                        RandamentPanou = c.Double(nullable: false),
                        CostPanou = c.Int(nullable: false),
                        RaportPerformantaPanou = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PanouId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PanouSolars");
        }
    }
}
