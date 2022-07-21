using System.Data.Entity;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class CadastroContext : DbContext
    {
        public CadastroContext() : base("name=stringConexaoCadastro") { }      
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> EnderecoClientes { get; set; }
    }
}


