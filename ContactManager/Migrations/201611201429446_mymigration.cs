namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "Self");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Self", c => c.String());
        }
    }
}
