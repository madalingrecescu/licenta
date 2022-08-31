namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbleUnghi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Calcules", "Unghi", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Calcules", "Unghi", c => c.Int(nullable: false));
        }
    }
}
