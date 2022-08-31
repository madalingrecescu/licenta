namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unghi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calcules", "Unghi", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calcules", "Unghi");
        }
    }
}
