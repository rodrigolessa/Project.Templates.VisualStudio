namespace sample.T4M.UI.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataNula : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "LimiteDeTeste", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LimiteDeTeste", c => c.DateTime(nullable: false));
        }
    }
}
