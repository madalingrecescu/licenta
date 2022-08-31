namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutereMaxima : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PanouSolars", "PutereMaxima", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PanouSolars", "PutereMaxima");
        }
    }
}
