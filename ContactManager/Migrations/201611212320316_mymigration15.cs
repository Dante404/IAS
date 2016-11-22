namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration15 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContattiContacts", newName: "ContactContattis");
            DropPrimaryKey("dbo.ContactContattis");
            AddColumn("dbo.Contacts", "ContattoID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ContactContattis", new[] { "Contact_ContactId", "Contatti_ContattoID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ContactContattis");
            DropColumn("dbo.Contacts", "ContattoID");
            AddPrimaryKey("dbo.ContactContattis", new[] { "Contatti_ContattoID", "Contact_ContactId" });
            RenameTable(name: "dbo.ContactContattis", newName: "ContattiContacts");
        }
    }
}
