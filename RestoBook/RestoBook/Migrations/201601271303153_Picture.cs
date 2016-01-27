namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Picture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        Id_Picture = c.Int(nullable: false, identity: true),
                        lb_Name = c.String(),
                        lb_Picure = c.Byte(nullable: false),
                        fk_Restaurant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Picture)
                .ForeignKey("dbo.Restaurants", t => t.fk_Restaurant, cascadeDelete: true)
                .Index(t => t.fk_Restaurant);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Picture", "fk_Restaurant", "dbo.Restaurants");
            DropIndex("dbo.Picture", new[] { "fk_Restaurant" });
            DropTable("dbo.Picture");
        }
    }
}
