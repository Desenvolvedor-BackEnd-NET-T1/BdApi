
using System.ComponentModel.DataAnnotations;

namespace DbApi.Models
{
    public class Cliente
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        [Required]
        public  string Email { get; set; }
        public string Endereco { get; set; }
    }
}