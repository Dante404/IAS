namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "ContactsUni_ContactId", "dbo.ContactsUnis");
            DropForeignKey("dbo.Contacts", "ContactsUni_ContactId", "dbo.ContactsUnis");
            DropForeignKey("dbo.Contattis", "ContactsUni_ContactId", "dbo.ContactsUnis");
            DropIndex("dbo.Companies", new[] { "ContactsUni_ContactId" });
            DropIndex("dbo.Contacts", new[] { "ContactsUni_ContactId" });
            DropIndex("dbo.Contattis", new[] { "ContactsUni_ContactId" });
            DropColumn("dbo.Companies", "ContactsUni_ContactId");
            DropColumn("dbo.Contacts", "ContactsUni_ContactId");
            DropTable("dbo.Contattis");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contattis",
                c => new
                    {
                        ContattoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Via = c.String(),
                        Citta = c.String(),
                        Stato = c.String(),
                        CodicePostale = c.String(),
                        Email = c.String(),
                        ContactsUni_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.ContattoID);
            
            AddColumn("dbo.Contacts", "ContactsUni_ContactId", c => c.Int());
            AddColumn("dbo.Companies", "ContactsUni_ContactId", c => c.Int());
            CreateIndex("dbo.Contattis", "ContactsUni_ContactId");
            CreateIndex("dbo.Contacts", "ContactsUni_ContactId");
            CreateIndex("dbo.Companies", "ContactsUni_ContactId");
            AddForeignKey("dbo.Contattis", "ContactsUni_ContactId", "dbo.ContactsUnis", "ContactId");
            AddForeignKey("dbo.Contacts", "ContactsUni_ContactId", "dbo.ContactsUnis", "ContactId");
            AddForeignKey("dbo.Companies", "ContactsUni_ContactId", "dbo.ContactsUnis", "ContactId");
        }
    }
}
