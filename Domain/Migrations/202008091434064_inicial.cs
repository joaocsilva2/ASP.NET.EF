namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UF_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UFs", t => t.UF_ID)
                .Index(t => t.UF_ID);
            
            CreateTable(
                "dbo.UFs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sigla = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CPF = c.String(),
                        Telefone = c.String(),
                        Logradouro = c.String(),
                        Numero = c.String(),
                        Cep = c.String(),
                        Cidade_ID = c.Int(),
                        UF_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cidades", t => t.Cidade_ID)
                .ForeignKey("dbo.UFs", t => t.UF_ID)
                .Index(t => t.Cidade_ID)
                .Index(t => t.UF_ID);
            
            CreateTable(
                "dbo.Dependentes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CPF = c.String(),
                        Info = c.String(),
                        cliente_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.cliente_ID)
                .Index(t => t.cliente_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "UF_ID", "dbo.UFs");
            DropForeignKey("dbo.Dependentes", "cliente_ID", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Cidade_ID", "dbo.Cidades");
            DropForeignKey("dbo.Cidades", "UF_ID", "dbo.UFs");
            DropIndex("dbo.Dependentes", new[] { "cliente_ID" });
            DropIndex("dbo.Clientes", new[] { "UF_ID" });
            DropIndex("dbo.Clientes", new[] { "Cidade_ID" });
            DropIndex("dbo.Cidades", new[] { "UF_ID" });
            DropTable("dbo.Dependentes");
            DropTable("dbo.Clientes");
            DropTable("dbo.UFs");
            DropTable("dbo.Cidades");
        }
    }
}
