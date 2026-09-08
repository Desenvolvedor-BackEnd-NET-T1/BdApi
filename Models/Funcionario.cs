using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbApi.Models
{
    [Table("tb_funcionarios")]
    public class Funcionario
    {
        [Key]
        [Column("idFunc", TypeName = "varchar(50)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column("nomeFunc", TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Column("emailFunc", TypeName = "varchar(100)")]
        public string Email { get; set; }
        //Exercicio Crie  o crud de fucionarios no Db. 
        //a tabela tem que ter o nome tb_funcionarios
        // e todas propriedades devem ter o sufico Func (idFunc, nomeFunc, emailFunc)
        // e devem possuir as devidas tipagens Varcahr (x)



        //A controller deve possuir os metodos 
        //[Get] obter todos funcionarios
        //[Get({id})] obter funcionario por Id
        //[Post] Cadastrar novo funcionario
        //[delete] excluir funcionario 
        //[update] atualizar funcionario 
    }
}


