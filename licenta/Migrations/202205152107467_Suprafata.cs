namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Suprafata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calcules", "Suprafata", c => c.Double(nullable: false));
            AlterColumn("dbo.Calcules", "EnergieNecesara", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Calcules", "EnergieNecesara", c => c.Int(nullable: false));
            DropColumn("dbo.Calcules", "Suprafata");
        }
    }
}
