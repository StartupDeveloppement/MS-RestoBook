namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitailCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        lb_rue = c.String(nullable: false),
                        lb_codepostal = c.String(nullable: false),
                        VilleId = c.Int(nullable: false),
                        RestaurantsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantsId, cascadeDelete: true)
                .ForeignKey("dbo.Ville", t => t.VilleId, cascadeDelete: true)
                .Index(t => t.VilleId)
                .Index(t => t.RestaurantsId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id_Restaurant = c.Int(nullable: false, identity: true),
                        lb_nom = c.String(nullable: false),
                        lb_web = c.String(),
                        lb_tel = c.String(),
                    })
                .PrimaryKey(t => t.Id_Restaurant);
            
            CreateTable(
                "dbo.TypeCuisine",
                c => new
                    {
                        Id_Cuisine = c.Int(nullable: false, identity: true),
                        lb_cuisne = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Cuisine);
            
            CreateTable(
                "dbo.Ville",
                c => new
                    {
                        Id_Ville = c.Int(nullable: false, identity: true),
                        lb_ville = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Ville);
            
            CreateTable(
                "dbo.TypeCuisinesRestaurants",
                c => new
                    {
                        Id_Restaurant = c.Int(nullable: false),
                        Id_Cuisine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_Restaurant, t.Id_Cuisine })
                .ForeignKey("dbo.Restaurants", t => t.Id_Restaurant, cascadeDelete: true)
                .ForeignKey("dbo.TypeCuisine", t => t.Id_Cuisine, cascadeDelete: true)
                .Index(t => t.Id_Restaurant)
                .Index(t => t.Id_Cuisine);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adresse", "VilleId", "dbo.Ville");
            DropForeignKey("dbo.Adresse", "RestaurantsId", "dbo.Restaurants");
            DropForeignKey("dbo.TypeCuisinesRestaurants", "Id_Cuisine", "dbo.TypeCuisine");
            DropForeignKey("dbo.TypeCuisinesRestaurants", "Id_Restaurant", "dbo.Restaurants");
            DropIndex("dbo.TypeCuisinesRestaurants", new[] { "Id_Cuisine" });
            DropIndex("dbo.TypeCuisinesRestaurants", new[] { "Id_Restaurant" });
            DropIndex("dbo.Adresse", new[] { "RestaurantsId" });
            DropIndex("dbo.Adresse", new[] { "VilleId" });
            DropTable("dbo.TypeCuisinesRestaurants");
            DropTable("dbo.Ville");
            DropTable("dbo.TypeCuisine");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Adresse");
        }
    }
}
