namespace ccmockingservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropExpiry : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CreditCard", "Expiry");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditCard", "Expiry", c => c.String(nullable: false, maxLength: 6));
        }
    }
}
