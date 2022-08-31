namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LungimeLatimePanouSolar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PanouSolars", "Latime", c => c.Int(nullable: false));
            AddColumn("dbo.PanouSolars", "Inaltime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PanouSolars", "Inaltime");
            DropColumn("dbo.PanouSolars", "Latime");
        }
    }
}
