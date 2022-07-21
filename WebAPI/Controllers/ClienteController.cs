using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebAPI.Data;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class ClienteController : ApiController
    {
        #region Construtor e campos
        
        public ClienteController()
        {
            _context = new CadastroContext();
        }

        private CadastroContext _context;
                
        #endregion

        #region Web Métodos

        [Route("api/cliente")]
        [HttpGet]        
        public IHttpActionResult RetornaClientes()
        {
            var listaCliente = RetornarListaCliente();

            if (listaCliente.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(listaCliente);
        }

        [Route("api/cliente/{id}")]
        [HttpGet]
        public IHttpActionResult RetornaClientePor(int id)
        {
            if (id == 0)
            {
                return BadRequest("Código do cliente não informado.");
            }

            var listaCliente = RetornarListaCliente();

            ClienteEnderecoDTO clienteEnderecoDTO;

            if (listaCliente == null || listaCliente.Count == 0)
            {
                return BadRequest("Cliente não encontrado.");
            }
            else
            {
                clienteEnderecoDTO = RetornaClienteEnderecoDTO(id, listaCliente);
            }

            return Ok(clienteEnderecoDTO);
        }

        [Route("api/cliente")]
        [HttpPost]
        public IHttpActionResult AdicionaCliente([FromBody] ClienteEnderecoDTO clienteEnderecoDTO)
        {
            if (!ModelState.IsValid || clienteEnderecoDTO == null)
            {
                return BadRequest("Dados do cliente inválidos.");
            }

            var novoCliente = AdicionarNovoCliente(clienteEnderecoDTO);
            _context.Clientes.Add(novoCliente);
            _context.SaveChanges();

            return Ok(novoCliente);
        }

        [Route("api/cliente")]
        [HttpPut]
        public IHttpActionResult AtualizaCliente([FromBody] ClienteEnderecoDTO clienteEnderecoDTO)
        {
            if (!ModelState.IsValid || clienteEnderecoDTO == null)
            {
                return BadRequest("Dados do cliente inválidos.");
            }

            var clienteInformado = _context.Clientes.FirstOrDefault(c => c.Id == clienteEnderecoDTO.ClienteId);
            if (clienteInformado == null)
            {
                return NotFound();
            }
            else
            {
                AtualizaCliente(clienteInformado, clienteEnderecoDTO);
                _context.SaveChanges();
            }

            return Ok($"Cliente {clienteEnderecoDTO.Nome} atualizado com sucesso!");
        }        

        [Route("api/cliente/{id}")]
        [HttpDelete]
        public IHttpActionResult ExcluiClientePor(int id)
        {
            if (id == 0)
            {
                return BadRequest("Cliente não informado.");
            }

            var clienteInformado = _context.Clientes.FirstOrDefault(c => c.Id == id);
            var nome = string.Empty;

            if (clienteInformado == null)
            {
                return BadRequest("Cliente não encontrado.");
            }
            else
            {
                nome = clienteInformado.Nome;
                DeletaCliente(clienteInformado);
                _context.SaveChanges();                
            }

            return Ok($"Cliente: {nome} excluido com sucesso.");
        }

        #endregion

        #region Métodos auxiliares

        private IList<Cliente> RetornarListaCliente()
        {
            return _context.Clientes
                .Include("Endereco")
                .ToList()
                .Select(s => new Cliente
                {
                    Id = s.Id,
                    CPF = s.CPF,
                    DataExpedicao = s.DataExpedicao,
                    DataNascimento = s.DataNascimento,
                    EstadoCivil = s.EstadoCivil,
                    Nome = s.Nome,
                    OrgaoExpedicao = s.OrgaoExpedicao,
                    RG = s.RG,
                    Sexo = s.Sexo,
                    UF = s.UF,
                    Endereco = s.Endereco == null 
                    ? null
                    : new Endereco
                    {
                        Bairro = s.Endereco.Bairro,
                        CEP = s.Endereco.CEP,
                        Cidade = s.Endereco.Cidade,
                        Complemento = s.Endereco.Complemento,
                        Id = s.Id,
                        Logradouro = s.Endereco.Logradouro,
                        Numero = s.Endereco.Numero,
                        UF = s.Endereco.UF
                    },
                }).ToList();
        }

        private ClienteEnderecoDTO RetornaClienteEnderecoDTO(int id, IList<Cliente> listaCliente)
        {
            var clienteEnderecoDTO = new ClienteEnderecoDTO();
            var clienteInformado = listaCliente
                .Where(c => c.Id == id)
                .FirstOrDefault();
            
            clienteEnderecoDTO.ClienteId = clienteInformado.Id;
            clienteEnderecoDTO.CPF = clienteInformado.CPF;
            clienteEnderecoDTO.Nome = clienteInformado.Nome;
            clienteEnderecoDTO.RG = clienteInformado.RG;
            clienteEnderecoDTO.DataExpedicao = clienteInformado.DataExpedicao;
            clienteEnderecoDTO.OrgaoExpedicao = clienteInformado.OrgaoExpedicao;
            clienteEnderecoDTO.UfExpedicao = clienteInformado.UF;
            clienteEnderecoDTO.DataNascimento = clienteInformado.DataNascimento;
            clienteEnderecoDTO.Sexo = clienteInformado.Sexo;
            clienteEnderecoDTO.EstadoCivil = clienteInformado.EstadoCivil;

            clienteEnderecoDTO.CEP = clienteInformado.Endereco.CEP;
            clienteEnderecoDTO.Logradouro = clienteInformado.Endereco.Logradouro;
            clienteEnderecoDTO.Numero = clienteInformado.Endereco.Numero;
            clienteEnderecoDTO.Complemento = clienteInformado.Endereco.Complemento;
            clienteEnderecoDTO.Bairro = clienteInformado.Endereco.Bairro;
            clienteEnderecoDTO.Cidade = clienteInformado.Endereco.Cidade;
            clienteEnderecoDTO.UfEndereco = clienteInformado.Endereco.UF;

            return clienteEnderecoDTO;
        }

        private Cliente AdicionarNovoCliente(ClienteEnderecoDTO clienteEnderecoDTO)
        {
            return new Cliente
            {
                CPF = clienteEnderecoDTO.CPF,
                Nome = clienteEnderecoDTO.Nome,
                RG = clienteEnderecoDTO.RG,
                DataExpedicao = clienteEnderecoDTO.DataExpedicao,
                OrgaoExpedicao = clienteEnderecoDTO.OrgaoExpedicao,
                UF = clienteEnderecoDTO.UfExpedicao,
                DataNascimento = clienteEnderecoDTO.DataNascimento,
                Sexo = clienteEnderecoDTO.Sexo,
                EstadoCivil = clienteEnderecoDTO.EstadoCivil,
                Endereco = new Endereco
                {
                    CEP = clienteEnderecoDTO.CEP,
                    Logradouro = clienteEnderecoDTO.Logradouro,
                    Numero = clienteEnderecoDTO.Numero,
                    Complemento = clienteEnderecoDTO.Complemento,
                    Bairro = clienteEnderecoDTO.Bairro,
                    Cidade = clienteEnderecoDTO.Cidade,
                    UF = clienteEnderecoDTO.UfEndereco
                }
            };
        }

        private void AtualizaCliente(Cliente clienteInformado, ClienteEnderecoDTO clienteEnderecoDTO)
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
                .EnderecoClientes
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

        private void DeletaCliente(Cliente clienteInformado)
        {
            _context.Entry(clienteInformado).State = EntityState.Deleted;

            var enderecoClienteSelecionado = _context.EnderecoClientes
                .Where(ec => ec.Id == clienteInformado.EnderecoId)
                .FirstOrDefault();

            if (enderecoClienteSelecionado != null)
            {
                _context.Entry(enderecoClienteSelecionado).State = EntityState.Deleted;
            }
        }

        #endregion
    }
}
