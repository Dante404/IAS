namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactsUni2",
                c => new
                    {
                        uniID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.uniID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactsUni2");
        }
    }
}
