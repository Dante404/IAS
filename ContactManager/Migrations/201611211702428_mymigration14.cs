namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "ContactsUni2_ContattoID", c => c.Int());
            AddColumn("dbo.Contacts", "ContactsUni2_ContattoID", c => c.Int());
            AddColumn("dbo.Contattis", "ContactsUni2_ContattoID", c => c.Int());
            CreateIndex("dbo.Companies", "ContactsUni2_ContattoID");
            CreateIndex("dbo.Contacts", "ContactsUni2_ContattoID");
            CreateIndex("dbo.Contattis", "ContactsUni2_ContattoID");
            AddForeignKey("dbo.Companies", "ContactsUni2_ContattoID", "dbo.ContactsUni2", "ContattoID");
            AddForeignKey("dbo.Contacts", "ContactsUni2_ContattoID", "dbo.ContactsUni2", "ContattoID");
            AddForeignKey("dbo.Contattis", "ContactsUni2_ContattoID", "dbo.ContactsUni2", "ContattoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contattis", "ContactsUni2_ContattoID", "dbo.ContactsUni2");
            DropForeignKey("dbo.Contacts", "ContactsUni2_ContattoID", "dbo.ContactsUni2");
            DropForeignKey("dbo.Companies", "ContactsUni2_ContattoID", "dbo.ContactsUni2");
            DropIndex("dbo.Contattis", new[] { "ContactsUni2_ContattoID" });
            DropIndex("dbo.Contacts", new[] { "ContactsUni2_ContattoID" });
            DropIndex("dbo.Companies", new[] { "ContactsUni2_ContattoID" });
            DropColumn("dbo.Contattis", "ContactsUni2_ContattoID");
            DropColumn("dbo.Contacts", "ContactsUni2_ContattoID");
            DropColumn("dbo.Companies", "ContactsUni2_ContattoID");
        }
    }
}
