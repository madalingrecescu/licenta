namespace prima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoubleToRadiatieSiTemperatura : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Judets", "RadiatieSolara", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraIanuarie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraFebruarie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraMartie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraAprilie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraMai", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraIunie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraIulie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraAugust", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraSeptembrie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraOctombrie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraNoiembrie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraDecembrie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieIanuarie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieFebruarie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieMartie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieAprilie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieMai", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieIunie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieIulie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieAugust", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieSeptembrie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieOctombrie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieNoiembrie", c => c.Double(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieDecembrie", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Judets", "TemperaturaMedieDecembrie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieNoiembrie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieOctombrie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieSeptembrie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieAugust", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieIulie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieIunie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieMai", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieAprilie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieMartie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieFebruarie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "TemperaturaMedieIanuarie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraDecembrie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraNoiembrie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraOctombrie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraSeptembrie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraAugust", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraIulie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraIunie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraMai", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraAprilie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraMartie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraFebruarie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolaraIanuarie", c => c.Int(nullable: false));
            AlterColumn("dbo.Judets", "RadiatieSolara", c => c.Int(nullable: false));
        }
    }
}
