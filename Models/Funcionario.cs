namespace DbApi.Models
{
    public class Funcionario
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; }
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


