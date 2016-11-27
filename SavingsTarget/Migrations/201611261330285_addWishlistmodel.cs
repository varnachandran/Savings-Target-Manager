namespace SavingsTarget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWishlistmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WishlistItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Title = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WishlistItems");
        }
    }
}
