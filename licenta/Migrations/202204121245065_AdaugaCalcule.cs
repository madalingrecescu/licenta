namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdaugaCalcule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calcules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Judet = c.Int(nullable: false),
                        PanouSolar = c.Int(nullable: false),
                        EnergieNecesara = c.Int(nullable: false),
                        JudetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Judets", t => t.Judet, cascadeDelete: true)
                .Index(t => t.Judet);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calcules", "Judet", "dbo.Judets");
            DropIndex("dbo.Calcules", new[] { "Judet" });
            DropTable("dbo.Calcules");
        }
    }
}
