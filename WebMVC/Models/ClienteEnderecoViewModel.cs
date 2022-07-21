using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class ClienteEnderecoViewModel
    {
        public int ClienteId { get; set; }

        [DisplayName("CPF *")]
        [Required(ErrorMessage = "O campo CPF é Obrigatório")]
        public string CPF { get; set; }

        [DisplayName("Nome *")]
        [Required(ErrorMessage = "O campo Nome é Obrigatório")]
        public string Nome { get; set; }
        
        public string RG { get; set; }

        [DisplayName("Data Expedição")]
        public DateTime DataExpedicao { get; set; }

        [DisplayName("Orgão Expedição")]
        public string OrgaoExpedicao { get; set; }

        [DisplayName("UF Expedição")]
        public string UfExpedicao { get; set; }

        [DisplayName("Data de Nascimento *")]
        [Required(ErrorMessage = "O campo Data de Nascimento é Obrigatório")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Sexo *")]
        [Required(ErrorMessage = "O campo Sexo é Obrigatório")]
        public string Sexo { get; set; }

        [DisplayName("Estado Civil *")]
        [Required(ErrorMessage = "O campo Estado Civil é Obrigatório")]
        public string EstadoCivil { get; set; }

        [DisplayName("Cep *")]
        [Required(ErrorMessage = "O campo CEP é Obrigatório")]
        public string CEP { get; set; }

        [DisplayName("Rua *")]
        [Required(ErrorMessage = "O campo Rua é Obrigatório")]
        public string Logradouro { get; set; }

        [DisplayName("Número *")]
        [Required(ErrorMessage = "O campo Número é Obrigatório")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [DisplayName("Bairro *")]
        [Required(ErrorMessage = "O campo Bairro é Obrigatório")]
        public string Bairro { get; set; }

        [DisplayName("Cidade *")]
        [Required(ErrorMessage = "O campo Cidade é Obrigatório")]
        public string Cidade { get; set; }

        [DisplayName("UF *")]
        [Required(ErrorMessage = "O campo UF do endereço é Obrigatório")]
        public string UfEndereco { get; set; }
    }
}