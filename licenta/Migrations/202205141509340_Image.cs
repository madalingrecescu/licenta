namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Judets", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Judets", "ImagePath");
        }
    }
}
