namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Double : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PanouSolars", "AriePanou", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PanouSolars", "AriePanou", c => c.Int(nullable: false));
        }
    }
}
