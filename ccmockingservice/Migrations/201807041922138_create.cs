namespace ccmockingservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCard",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 16),
                        Expiry = c.String(nullable: false, maxLength: 6),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Number, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CreditCard", new[] { "Number" });
            DropTable("dbo.CreditCard");
        }
    }
}
