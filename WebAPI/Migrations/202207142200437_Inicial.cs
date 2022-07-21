namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPF = c.String(nullable: false, maxLength: 14),
                        Nome = c.String(nullable: false, maxLength: 100),
                        RG = c.String(maxLength: 15),
                        DataExpedicao = c.DateTime(nullable: false),
                        OrgaoExpedicao = c.String(maxLength: 10),
                        UF = c.String(maxLength: 2),
                        DataNascimento = c.DateTime(nullable: false),
                        Sexo = c.String(nullable: false, maxLength: 50),
                        EstadoCivil = c.String(nullable: false, maxLength: 50),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecos", t => t.EnderecoId, cascadeDelete: true)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CEP = c.String(nullable: false, maxLength: 15),
                        Logradouro = c.String(nullable: false, maxLength: 100),
                        Numero = c.String(nullable: false, maxLength: 10),
                        Complemento = c.String(maxLength: 100),
                        Bairro = c.String(nullable: false, maxLength: 50),
                        Cidade = c.String(nullable: false, maxLength: 50),
                        UF = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "EnderecoId", "dbo.Enderecos");
            DropIndex("dbo.Clientes", new[] { "EnderecoId" });
            DropTable("dbo.Enderecos");
            DropTable("dbo.Clientes");
        }
    }
}
