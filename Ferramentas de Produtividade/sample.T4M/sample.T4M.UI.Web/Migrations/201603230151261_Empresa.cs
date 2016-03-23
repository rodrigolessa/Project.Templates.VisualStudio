namespace sample.T4M.UI.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Empresa : DbMigration
    {
        public override void Up()
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
            AlterColumn("dbo.AspNetUsers", "Nome", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "Situacao", c => c.String(maxLength: 1));
            CreateIndex("dbo.AspNetUsers", "IdEmpresa");
            AddForeignKey("dbo.AspNetUsers", "IdEmpresa", "dbo.Empresas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "IdEmpresa", "dbo.Empresas");
            DropIndex("dbo.AspNetUsers", new[] { "IdEmpresa" });
            AlterColumn("dbo.AspNetUsers", "Situacao", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Nome", c => c.String());
            DropColumn("dbo.AspNetUsers", "IdEmpresa");
            DropTable("dbo.Empresas");
        }
    }
}
