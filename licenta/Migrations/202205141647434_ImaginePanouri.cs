namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImaginePanouri : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PanouSolars", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PanouSolars", "ImagePath");
        }
    }
}
