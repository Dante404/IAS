namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactsUnis",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Via = c.String(),
                        Citta = c.String(),
                        Stato = c.String(),
                        CodicePostale = c.String(),
                        Email = c.String(),
                        Zip = c.String(),
                        CompanyId = c.Int(nullable: false),
                        City = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactsUnis");
        }
    }
}
