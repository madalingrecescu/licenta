namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reparare : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Calcules", "JudetId");
            DropColumn("dbo.Calcules", "PanouId");
            RenameColumn(table: "dbo.Calcules", name: "Judet", newName: "JudetId");
            RenameColumn(table: "dbo.Calcules", name: "PanouSolar", newName: "PanouId");
            RenameIndex(table: "dbo.Calcules", name: "IX_Judet", newName: "IX_JudetId");
            RenameIndex(table: "dbo.Calcules", name: "IX_PanouSolar", newName: "IX_PanouId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Calcules", name: "IX_PanouId", newName: "IX_PanouSolar");
            RenameIndex(table: "dbo.Calcules", name: "IX_JudetId", newName: "IX_Judet");
            RenameColumn(table: "dbo.Calcules", name: "PanouId", newName: "PanouSolar");
            RenameColumn(table: "dbo.Calcules", name: "JudetId", newName: "Judet");
            AddColumn("dbo.Calcules", "PanouId", c => c.Int(nullable: false));
            AddColumn("dbo.Calcules", "JudetId", c => c.Int(nullable: false));
        }
    }
}
