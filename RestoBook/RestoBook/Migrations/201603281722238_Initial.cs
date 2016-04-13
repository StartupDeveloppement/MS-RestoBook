namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Picture", "role", c => c.String());
            AddColumn("dbo.Picture", "active", c => c.Boolean(nullable: false));
            DropColumn("dbo.Picture", "banner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Picture", "banner", c => c.Boolean(nullable: false));
            DropColumn("dbo.Picture", "active");
            DropColumn("dbo.Picture", "role");
        }
    }
}
