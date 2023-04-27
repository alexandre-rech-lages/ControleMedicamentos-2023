using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {
        public string nome;
        public string login;
        public string senha;

        public Funcionario(string nome, string login, string senha)
        {
            this.nome = nome;
            this.login = login;
            this.senha = senha;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Funcionario funcionarioAtualizado = (Funcionario)registroAtualizado;

            this.nome = funcionarioAtualizado.nome;
            this.login = funcionarioAtualizado.login;
            this.senha = funcionarioAtualizado.senha;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");
                      
            if (string.IsNullOrEmpty(login.Trim()))
                erros.Add("O campo \"login\" é obrigatório");

            if (string.IsNullOrEmpty(senha.Trim()))
                erros.Add("O campo \"senha\" é obrigatório");

            return erros;
        }
    }

}
