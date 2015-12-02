namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotationsRestaurants",
                c => new
                    {
                        Id_Restaurant = c.Int(nullable: false),
                        Id_Notation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_Restaurant, t.Id_Notation })
                .ForeignKey("dbo.Restaurants", t => t.Id_Restaurant, cascadeDelete: true)
                .ForeignKey("dbo.Notation", t => t.Id_Notation, cascadeDelete: true)
                .Index(t => t.Id_Restaurant)
                .Index(t => t.Id_Notation);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotationsRestaurants", "Id_Notation", "dbo.Notation");
            DropForeignKey("dbo.NotationsRestaurants", "Id_Restaurant", "dbo.Restaurants");
            DropIndex("dbo.NotationsRestaurants", new[] { "Id_Notation" });
            DropIndex("dbo.NotationsRestaurants", new[] { "Id_Restaurant" });
            DropTable("dbo.NotationsRestaurants");
            DropTable("dbo.Notation");
        }
    }
}
