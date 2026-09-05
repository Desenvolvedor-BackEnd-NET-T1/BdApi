
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbApi.Models
{
    //[Table("clienteabd")]
    public class Cliente
    {
        [Key]
        [Column("codCli")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        [MaxLength(150)]
        [Column("nomeCli", TypeName ="varchar(150)") ]
        public string Nome { get; set; }
        [Column("telefoneCli", TypeName ="varchar(11)") ]
        public string Telefone { get; set; }
        [Required]
        public  string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        
        public bool Ativo { get; set; } = true;


        public void Update (Cliente cliente)
        {
            Ativo = cliente.Ativo;
            DataNascimento = cliente.DataNascimento;
            Nome = cliente.Nome;
            Telefone = cliente.Telefone;
            Endereco = cliente.Endereco;
            Email = cliente.Email;
        }
    
    }
}