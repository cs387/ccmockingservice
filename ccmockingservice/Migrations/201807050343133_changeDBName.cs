namespace ccmockingservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDBName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CreditCard", newName: "CreditCardEntity");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CreditCardEntity", newName: "CreditCard");
        }
    }
}
