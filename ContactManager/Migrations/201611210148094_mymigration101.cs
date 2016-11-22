namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration101 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactsUni2", "Company_CompanyId", c => c.Int());
            AddColumn("dbo.ContactsUni2", "Contact_ContactId", c => c.Int());
            CreateIndex("dbo.ContactsUni2", "Company_CompanyId");
            CreateIndex("dbo.ContactsUni2", "Contact_ContactId");
            AddForeignKey("dbo.ContactsUni2", "Company_CompanyId", "dbo.Companies", "CompanyId");
            AddForeignKey("dbo.ContactsUni2", "Contact_ContactId", "dbo.Contacts", "ContactId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactsUni2", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactsUni2", "Company_CompanyId", "dbo.Companies");
            DropIndex("dbo.ContactsUni2", new[] { "Contact_ContactId" });
            DropIndex("dbo.ContactsUni2", new[] { "Company_CompanyId" });
            DropColumn("dbo.ContactsUni2", "Contact_ContactId");
            DropColumn("dbo.ContactsUni2", "Company_CompanyId");
        }
    }
}
