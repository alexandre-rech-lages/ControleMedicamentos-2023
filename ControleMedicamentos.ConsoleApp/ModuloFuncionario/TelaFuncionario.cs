using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario : TelaBase
    {
        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioBase = repositorioFuncionario;
            nomeEntidade = "Funcionário";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Login");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Funcionario funcionario in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", funcionario.id, funcionario.nome, funcionario.login);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o login: ");
            string login = Console.ReadLine();

            Console.Write("Digite a senha: ");
            string senha = Console.ReadLine();

            return new Funcionario(nome, login, senha);
        }
    }

}
