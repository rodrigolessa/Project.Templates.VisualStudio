namespace sample.T4M.UI.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LimitedeTeste : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nome", c => c.String());
            AddColumn("dbo.AspNetUsers", "Situacao", c => c.String());
            AddColumn("dbo.AspNetUsers", "LimiteDeTeste", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LimiteDeTeste");
            DropColumn("dbo.AspNetUsers", "Situacao");
            DropColumn("dbo.AspNetUsers", "Nome");
        }
    }
}
