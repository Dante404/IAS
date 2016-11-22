namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration10 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ContactsUni2");
            CreateTable(
                "dbo.Contattis",
                c => new
                    {
                        ContattoID = c.Int(nullable: false),
                        Nome = c.String(),
                        Via = c.String(),
                        Citta = c.String(),
                        Stato = c.String(),
                        CodicePostale = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ContattoID)
                .ForeignKey("dbo.Contacts", t => t.ContattoID)
                .Index(t => t.ContattoID);
            
            AddColumn("dbo.ContactsUni2", "ContattoID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ContactsUni2", "ContattoID");
            CreateIndex("dbo.Contacts", "CompanyId");
            CreateIndex("dbo.ContactsUni2", "ContattoID");
            AddForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
            AddForeignKey("dbo.ContactsUni2", "ContattoID", "dbo.Contattis", "ContattoID");
            DropColumn("dbo.ContactsUni2", "uniID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactsUni2", "uniID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ContactsUni2", "ContattoID", "dbo.Contattis");
            DropForeignKey("dbo.Contattis", "ContattoID", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.ContactsUni2", new[] { "ContattoID" });
            DropIndex("dbo.Contattis", new[] { "ContattoID" });
            DropIndex("dbo.Contacts", new[] { "CompanyId" });
            DropPrimaryKey("dbo.ContactsUni2");
            DropColumn("dbo.ContactsUni2", "ContattoID");
            DropTable("dbo.Contattis");
            AddPrimaryKey("dbo.ContactsUni2", "uniID");
        }
    }
}
