namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactsUni3",
                c => new
                    {
                        ContattoID = c.Int(nullable: false),
                        Company_CompanyId = c.Int(),
                        Contact_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.ContattoID)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactId)
                .ForeignKey("dbo.Contattis", t => t.ContattoID)
                .Index(t => t.ContattoID)
                .Index(t => t.Company_CompanyId)
                .Index(t => t.Contact_ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactsUni3", "ContattoID", "dbo.Contattis");
            DropForeignKey("dbo.ContactsUni3", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactsUni3", "Company_CompanyId", "dbo.Companies");
            DropIndex("dbo.ContactsUni3", new[] { "Contact_ContactId" });
            DropIndex("dbo.ContactsUni3", new[] { "Company_CompanyId" });
            DropIndex("dbo.ContactsUni3", new[] { "ContattoID" });
            DropTable("dbo.ContactsUni3");
        }
    }
}
