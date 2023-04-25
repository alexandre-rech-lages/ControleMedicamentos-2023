namespace ControleMedicamentos.ConsoleApp
{
    public class TelaPrincipal
    {
        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Controle de Medicamentos 1.0\n");

            Console.WriteLine("Digite 1 para Cadastrar Fornecedores");
            Console.WriteLine("Digite 2 para Cadastrar Funcionários");
            Console.WriteLine("Digite 3 para Cadastrar Pacientes");
            Console.WriteLine("Digite 4 para Cadastrar Medicamentos");

            Console.WriteLine("Digite 5 para Cadastrar Requisições de Entrada\n");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
