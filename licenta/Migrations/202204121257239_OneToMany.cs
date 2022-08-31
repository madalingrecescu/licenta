namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToMany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calcules", "PanouId", c => c.Int(nullable: false));
            CreateIndex("dbo.Calcules", "PanouSolar");
            AddForeignKey("dbo.Calcules", "PanouSolar", "dbo.PanouSolars", "PanouId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calcules", "PanouSolar", "dbo.PanouSolars");
            DropIndex("dbo.Calcules", new[] { "PanouSolar" });
            DropColumn("dbo.Calcules", "PanouId");
        }
    }
}
