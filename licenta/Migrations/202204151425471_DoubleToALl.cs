namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoubleToALl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PanouSolars", "PutereMaxima", c => c.Double(nullable: false));
            AlterColumn("dbo.PanouSolars", "CostPanou", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PanouSolars", "CostPanou", c => c.Int(nullable: false));
            AlterColumn("dbo.PanouSolars", "PutereMaxima", c => c.Int(nullable: false));
        }
    }
}
