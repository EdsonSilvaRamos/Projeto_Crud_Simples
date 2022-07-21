using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(14)]
        public string CPF { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(15)]
        public string RG { get; set; }
        
        public DateTime DataExpedicao { get; set; }

        [MaxLength(10)]
        public string OrgaoExpedicao { get; set; }

        [MaxLength(2)]
        public string UF { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Sexo { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string EstadoCivil { get; set; }

        [Required]
        public virtual Endereco Endereco { get; set; }
        public virtual int EnderecoId { get; set; }
    }
}