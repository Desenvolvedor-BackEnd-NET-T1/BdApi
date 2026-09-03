
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbApi.Models
{
    public class Cliente
    {
        [Key]
        [Column("codCli")]
        
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [Column("nomeCli", TypeName ="varchar(150)") ]
        [MaxLength(150)]
        public string Nome { get; set; }
        [Column("telefoneCli", TypeName ="varchar(11)") ]
        public string Telefone { get; set; }
        [Required]
        public  string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }

    
    }
}