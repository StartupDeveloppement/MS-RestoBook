namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActiveRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "isActive");
        }
    }
}
