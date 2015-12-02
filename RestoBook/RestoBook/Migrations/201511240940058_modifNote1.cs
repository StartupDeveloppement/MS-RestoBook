namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifNote1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notation", "Note", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notation", "Note", c => c.Int(nullable: false));
        }
    }
}
