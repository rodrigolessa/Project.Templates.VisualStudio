namespace sample.T4M.UI.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovaEmpresa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "IdEmpresa", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "IdEmpresa");
            AddForeignKey("dbo.AspNetUsers", "IdEmpresa", "dbo.Empresas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "IdEmpresa", "dbo.Empresas");
            DropIndex("dbo.AspNetUsers", new[] { "IdEmpresa" });
            DropColumn("dbo.AspNetUsers", "IdEmpresa");
            DropTable("dbo.Empresas");
        }
    }
}
