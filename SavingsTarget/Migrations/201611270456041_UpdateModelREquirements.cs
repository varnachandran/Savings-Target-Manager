namespace SavingsTarget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelREquirements : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WishlistItems", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WishlistItems", "Title", c => c.String());
        }
    }
}
