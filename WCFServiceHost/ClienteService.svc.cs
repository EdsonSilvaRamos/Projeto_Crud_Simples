using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebForm.DTOs;

namespace WCFServiceHost
{
    public class ClienteService : IClienteService
    {
        private CadastroEntities _context;

        public IList<Clientes> RetornaClientes()
        {
            using (_context = new CadastroEntities())
            {
                _context.Configuration.ProxyCreationEnabled = false;
                var listaCliente = _context.Clientes.Include("Enderecos").ToList();
                return listaCliente;
            }
        }

        public Clientes RetornaClientePor(int id)
        {
            using (_context = new CadastroEntities())
            {
                _context.Configuration.ProxyCreationEnabled = false;
                var cliente = _context.Clientes.Include("Enderecos").SingleOrDefault(c => c.Id == id);
                return cliente;
            }
        }


        public Clientes AdicionaCliente(Clientes cliente)
        {
            using (_context = new CadastroEntities())
            {
                _context.Configuration.ProxyCreationEnabled = false;
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return cliente;
            }
        }

        public Clientes AtualizaCliente(ClienteEnderecoDTO clienteEnderecoDTO)
        {
            using (_context = new CadastroEntities())
            {
                _context.Configuration.ProxyCreationEnabled = false;

                var clienteInformado = _context.Clientes.SingleOrDefault(c => c.Id == clienteEnderecoDTO.ClienteId);
                AtualizaCliente(clienteInformado, clienteEnderecoDTO);
                
                _context.SaveChanges();

                return clienteInformado;
            }
        }
        
        public Clientes ExcluiClientePor(int id)
        {
            using (_context = new CadastroEntities())
            {
                _context.Configuration.ProxyCreationEnabled = false;
                var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);                
                _context.Entry(cliente).State = EntityState.Deleted;

                var enderecoClienteSelecionado = _context.Enderecos
                    .Where(ec => ec.Id == cliente.EnderecoId)
                    .FirstOrDefault();

                if (enderecoClienteSelecionado != null)
                {
                    _context.Entry(enderecoClienteSelecionado).State = EntityState.Deleted;
                }

                _context.SaveChanges();
                return cliente;
            }
        }

        private void AtualizaCliente(Clientes clienteInformado, ClienteEnderecoDTO clienteEnderecoDTO)
        {
            clienteInformado.CPF = clienteEnderecoDTO.CPF;
            clienteInformado.Nome = clienteEnderecoDTO.Nome;
            clienteInformado.RG = clienteEnderecoDTO.RG;
            clienteInformado.DataExpedicao = clienteEnderecoDTO.DataExpedicao;
            clienteInformado.OrgaoExpedicao = clienteEnderecoDTO.OrgaoExpedicao;
            clienteInformado.UF = clienteEnderecoDTO.UfExpedicao;
            clienteInformado.DataNascimento = clienteEnderecoDTO.DataNascimento;
            clienteInformado.Sexo = clienteEnderecoDTO.Sexo;
            clienteInformado.EstadoCivil = clienteEnderecoDTO.EstadoCivil;

            _context.Entry(clienteInformado).State = EntityState.Modified;

            var enderecoClienteInformado = _context
                .Enderecos
                .Where(ec => ec.Id == clienteInformado.EnderecoId)
                .FirstOrDefault();

            if (enderecoClienteInformado != null)
            {
                enderecoClienteInformado.CEP = clienteEnderecoDTO.CEP;
                enderecoClienteInformado.Logradouro = clienteEnderecoDTO.Logradouro;
                enderecoClienteInformado.Numero = clienteEnderecoDTO.Numero;
                enderecoClienteInformado.Complemento = clienteEnderecoDTO.Complemento;
                enderecoClienteInformado.Bairro = clienteEnderecoDTO.Bairro;
                enderecoClienteInformado.Cidade = clienteEnderecoDTO.Cidade;
                enderecoClienteInformado.UF = clienteEnderecoDTO.UfEndereco;

                _context.Entry(enderecoClienteInformado).State = EntityState.Modified;
            }
        }
    }
}
