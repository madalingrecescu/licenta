namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PanouSolars", "Latime", c => c.Double(nullable: false));
            AlterColumn("dbo.PanouSolars", "Inaltime", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PanouSolars", "Inaltime", c => c.Int(nullable: false));
            AlterColumn("dbo.PanouSolars", "Latime", c => c.Int(nullable: false));
        }
    }
}
