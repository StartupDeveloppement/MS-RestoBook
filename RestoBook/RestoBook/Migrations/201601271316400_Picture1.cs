namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Picture1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Picture", "lb_Picure", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Picture", "lb_Picure", c => c.Byte(nullable: false));
        }
    }
}
