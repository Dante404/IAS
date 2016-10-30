namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatever : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Self", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Self");
        }
    }
}
