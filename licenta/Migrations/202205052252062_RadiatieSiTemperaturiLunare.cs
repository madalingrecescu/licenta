namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RadiatieSiTemperaturiLunare : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Judets", "RadiatieSolaraIanuarie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "RadiatieSolaraFebruarie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "RadiatieSolaraMartie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "RadiatieSolaraAprilie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "RadiatieSolaraMai", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "RadiatieSolaraIunie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "RadiatieSolaraIulie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "RadiatieSolaraAugust", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "RadiatieSolaraSeptembrie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "RadiatieSolaraOctombrie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "RadiatieSolaraNoiembrie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "RadiatieSolaraDecembrie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieIanuarie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieFebruarie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieMartie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieAprilie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieMai", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieIunie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieIulie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieAugust", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieSeptembrie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieOctombrie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieNoiembrie", c => c.Int(nullable: false));
            AddColumn("dbo.Judets", "TemperaturaMedieDecembrie", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Judets", "TemperaturaMedieDecembrie");
            DropColumn("dbo.Judets", "TemperaturaMedieNoiembrie");
            DropColumn("dbo.Judets", "TemperaturaMedieOctombrie");
            DropColumn("dbo.Judets", "TemperaturaMedieSeptembrie");
            DropColumn("dbo.Judets", "TemperaturaMedieAugust");
            DropColumn("dbo.Judets", "TemperaturaMedieIulie");
            DropColumn("dbo.Judets", "TemperaturaMedieIunie");
            DropColumn("dbo.Judets", "TemperaturaMedieMai");
            DropColumn("dbo.Judets", "TemperaturaMedieAprilie");
            DropColumn("dbo.Judets", "TemperaturaMedieMartie");
            DropColumn("dbo.Judets", "TemperaturaMedieFebruarie");
            DropColumn("dbo.Judets", "TemperaturaMedieIanuarie");
            DropColumn("dbo.Judets", "RadiatieSolaraDecembrie");
            DropColumn("dbo.Judets", "RadiatieSolaraNoiembrie");
            DropColumn("dbo.Judets", "RadiatieSolaraOctombrie");
            DropColumn("dbo.Judets", "RadiatieSolaraSeptembrie");
            DropColumn("dbo.Judets", "RadiatieSolaraAugust");
            DropColumn("dbo.Judets", "RadiatieSolaraIulie");
            DropColumn("dbo.Judets", "RadiatieSolaraIunie");
            DropColumn("dbo.Judets", "RadiatieSolaraMai");
            DropColumn("dbo.Judets", "RadiatieSolaraAprilie");
            DropColumn("dbo.Judets", "RadiatieSolaraMartie");
            DropColumn("dbo.Judets", "RadiatieSolaraFebruarie");
            DropColumn("dbo.Judets", "RadiatieSolaraIanuarie");
        }
    }
}
