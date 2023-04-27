using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp
{
    public class FornecedorInvalidoException : ApplicationException
    {

    }

    internal class OutraProgram
    {
        //Exceções
        static void Main2(string[] args)
        {
            int numeroA = 10;

            Console.WriteLine("Digite o numeroB: ");
            int numeroB = Convert.ToInt32("0");
            try
            {
                int resultado = numeroA / numeroB;
            }
            catch(DivideByZeroException exc)
            {
                Console.WriteLine(exc.Message);
            }

            RepositorioFuncionario repositorioFuncionario =
                new RepositorioFuncionario(new ArrayList());

            Funcionario x = repositorioFuncionario.SelecionarPorId(2);

            try
            {
                x.AtualizarInformacoes(new Funcionario("rech", "rech", "123"));

                int resultado = numeroA / numeroB;

                int[] idades = new int[5] { 20, 25, 29, 32, 35 };

                Console.WriteLine("Início do método Metodo02");

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(idades[i]);
                }               
            }
            catch (IndexOutOfRangeException exc)
            {

            }
            catch (NullReferenceException exc)
            {

            }
            catch(DivideByZeroException exc)
            {
                Console.WriteLine(exc.Message);
            }

            Console.WriteLine("Início do método Main");

            try
            {
                Metodo01();
            }
            catch
            {

            }

            Console.WriteLine("Fim do método Main");

            Console.ReadLine();
        }

        private static void Metodo01()
        {
            Console.WriteLine("Início do método Metodo01");

            Metodo02();

            Console.WriteLine("Fim do método Metodo01");
        }

        private static void Metodo02()
        {
            int[] idades = new int[5] { 20, 25, 29, 32, 35 };

            Console.WriteLine("Início do método Metodo02");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(idades[i]);
            }

            Console.WriteLine("Fim do método Metodo02");
        }
    }
}
