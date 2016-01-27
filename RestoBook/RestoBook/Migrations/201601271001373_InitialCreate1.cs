namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "lb_description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "lb_description");
        }
    }
}
