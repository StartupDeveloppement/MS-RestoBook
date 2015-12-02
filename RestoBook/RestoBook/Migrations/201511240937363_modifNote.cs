namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifNote : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notation", "Note", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notation", "Note", c => c.Double(nullable: false));
        }
    }
}
