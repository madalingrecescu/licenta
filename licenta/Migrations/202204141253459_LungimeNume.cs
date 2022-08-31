namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LungimeNume : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PanouSolars", "NumePanou", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PanouSolars", "NumePanou", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
