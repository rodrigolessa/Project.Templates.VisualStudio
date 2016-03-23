namespace sample.T4M.UI.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SemEmpresa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "IdEmpresa", "dbo.Empresas");
            DropIndex("dbo.AspNetUsers", new[] { "IdEmpresa" });
            DropColumn("dbo.AspNetUsers", "IdEmpresa");
            DropTable("dbo.Empresas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "IdEmpresa", c => c.Long());
            CreateIndex("dbo.AspNetUsers", "IdEmpresa");
            AddForeignKey("dbo.AspNetUsers", "IdEmpresa", "dbo.Empresas", "Id");
        }
    }
}
