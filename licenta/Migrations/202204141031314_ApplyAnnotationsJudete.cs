namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsJudete : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Judets", "Nume", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Judets", "Nume", c => c.String());
        }
    }
}
