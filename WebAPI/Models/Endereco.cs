using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string CEP { get; set; }

        [Required]
        [MaxLength(100)]
        public string Logradouro { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string Numero { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Bairro { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Cidade { get; set; }
        
        [Required]
        [MaxLength(2)]
        public string UF { get; set; }
    }
}