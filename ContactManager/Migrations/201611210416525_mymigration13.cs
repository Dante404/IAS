namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contattis", "ContattoID", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.ContactsUni2", "ContattoID", "dbo.Contattis");
            DropForeignKey("dbo.ContactsUni3", "ContattoID", "dbo.Contattis");
            DropIndex("dbo.Contacts", new[] { "CompanyId" });
            DropIndex("dbo.Contattis", new[] { "ContattoID" });
            DropPrimaryKey("dbo.Contattis");
            CreateTable(
                "dbo.ContattiContacts",
                c => new
                    {
                        Contatti_ContattoID = c.Int(nullable: false),
                        Contact_ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contatti_ContattoID, t.Contact_ContactId })
                .ForeignKey("dbo.Contattis", t => t.Contatti_ContattoID, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactId, cascadeDelete: true)
                .Index(t => t.Contatti_ContattoID)
                .Index(t => t.Contact_ContactId);
            
            AddColumn("dbo.Companies", "Contact_ContactId", c => c.Int());
            AlterColumn("dbo.Contattis", "ContattoID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contattis", "ContattoID");
            CreateIndex("dbo.Companies", "Contact_ContactId");
            AddForeignKey("dbo.Companies", "Contact_ContactId", "dbo.Contacts", "ContactId");
            AddForeignKey("dbo.ContactsUni2", "ContattoID", "dbo.Contattis", "ContattoID");
            AddForeignKey("dbo.ContactsUni3", "ContattoID", "dbo.Contattis", "ContattoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactsUni3", "ContattoID", "dbo.Contattis");
            DropForeignKey("dbo.ContactsUni2", "ContattoID", "dbo.Contattis");
            DropForeignKey("dbo.Companies", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContattiContacts", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContattiContacts", "Contatti_ContattoID", "dbo.Contattis");
            DropIndex("dbo.ContattiContacts", new[] { "Contact_ContactId" });
            DropIndex("dbo.ContattiContacts", new[] { "Contatti_ContattoID" });
            DropIndex("dbo.Companies", new[] { "Contact_ContactId" });
            DropPrimaryKey("dbo.Contattis");
            AlterColumn("dbo.Contattis", "ContattoID", c => c.Int(nullable: false));
            DropColumn("dbo.Companies", "Contact_ContactId");
            DropTable("dbo.ContattiContacts");
            AddPrimaryKey("dbo.Contattis", "ContattoID");
            CreateIndex("dbo.Contattis", "ContattoID");
            CreateIndex("dbo.Contacts", "CompanyId");
            AddForeignKey("dbo.ContactsUni3", "ContattoID", "dbo.Contattis", "ContattoID");
            AddForeignKey("dbo.ContactsUni2", "ContattoID", "dbo.Contattis", "ContattoID");
            AddForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
            AddForeignKey("dbo.Contattis", "ContattoID", "dbo.Contacts", "ContactId");
        }
    }
}
