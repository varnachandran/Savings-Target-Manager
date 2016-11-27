namespace SavingsTarget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSavingsAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSavingsAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Deposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserSavingsAccounts");
        }
    }
}
