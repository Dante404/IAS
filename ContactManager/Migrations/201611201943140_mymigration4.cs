namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration4 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ContattoID)
                .ForeignKey("dbo.ContactsUnis", t => t.ContactsUni_ContactId)
                .Index(t => t.ContactsUni_ContactId);
            
            AddColumn("dbo.Companies", "ContactsUni_ContactId", c => c.Int());
            AddColumn("dbo.Contacts", "ContactsUni_ContactId", c => c.Int());
            CreateIndex("dbo.Companies", "ContactsUni_ContactId");
            CreateIndex("dbo.Contacts", "ContactsUni_ContactId");
            AddForeignKey("dbo.Companies", "ContactsUni_ContactId", "dbo.ContactsUnis", "ContactId");
            AddForeignKey("dbo.Contacts", "ContactsUni_ContactId", "dbo.ContactsUnis", "ContactId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contattis", "ContactsUni_ContactId", "dbo.ContactsUnis");
            DropForeignKey("dbo.Contacts", "ContactsUni_ContactId", "dbo.ContactsUnis");
            DropForeignKey("dbo.Companies", "ContactsUni_ContactId", "dbo.ContactsUnis");
            DropIndex("dbo.Contattis", new[] { "ContactsUni_ContactId" });
            DropIndex("dbo.Contacts", new[] { "ContactsUni_ContactId" });
            DropIndex("dbo.Companies", new[] { "ContactsUni_ContactId" });
            DropColumn("dbo.Contacts", "ContactsUni_ContactId");
            DropColumn("dbo.Companies", "ContactsUni_ContactId");
            DropTable("dbo.Contattis");
        }
    }
}
