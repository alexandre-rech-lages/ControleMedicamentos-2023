using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaoEntrada
{
    public class TelaRequisicaoEntrada : TelaBase
    {
        private RepositorioRequisicaoEntrada repositorioRequisicaoEntrada;

        private RepositorioFuncionario repositorioFuncionario;
        private RepositorioMedicamento repositorioMedicamento;

        private TelaFuncionario telaFuncionario;
        private TelaMedicamento telaMedicamento;

        public TelaRequisicaoEntrada(RepositorioRequisicaoEntrada repositorioRequisicaoEntrada, 
            RepositorioFuncionario repositorioFuncionario, RepositorioMedicamento repositorioMedicamento, 
            TelaFuncionario telaFuncionario, TelaMedicamento telaMedicamento)
        {
            this.repositorioBase = repositorioRequisicaoEntrada;

            this.repositorioRequisicaoEntrada = repositorioRequisicaoEntrada;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioMedicamento = repositorioMedicamento;
            this.telaFuncionario = telaFuncionario;
            this.telaMedicamento = telaMedicamento;

            nomeEntidade = "Requisições de Entrada";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -10} | {2, -20} | {3, -20}", "Id", "Data", "Medicamento", "Fonecedor", "Quantidade");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (RequisicaoEntrada requisicaoEntrada in registros)
            {
                Console.WriteLine("{0, -10} | {1, -10} | {2, -20} | {3, -20}", 
                    requisicaoEntrada.id, 
                    requisicaoEntrada.data.ToShortDateString(),
                    requisicaoEntrada.medicamento.nome, 
                    requisicaoEntrada.medicamento.fornecedor.nome, 
                    requisicaoEntrada.quantidade);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Medicamento medicamento = ObterMedicamento();

            Funcionario funcionario = ObterFuncionario();

            Console.Write("Digite a quantidade de caixas: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            return new RequisicaoEntrada(medicamento, quantidade, data, funcionario);
        }

        private Funcionario ObterFuncionario()
        {
            //Visulizar a lista de funcionarios
            telaFuncionario.VisualizarRegistros(false);

            //Selecionar um funcionario por id
            Console.Write("\nDigite o id do Funcionário: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());

            //Pegar o objeto no repositorio de Funcionario a partir do id selecionado
            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(idFuncionario);

            return funcionario;
        }

        private Medicamento ObterMedicamento()
        {
            //Visulizar a lista de medicamentos 
            telaMedicamento.VisualizarRegistros(false);

            //Selecionar um medicamento por id
            Console.Write("\nDigite o id do Medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            //Pegar o objeto no repositorio de Medicamento a partir do id selecionado
            Medicamento medicamento = repositorioMedicamento.SelecionarPorId(idMedicamento);

            return medicamento;
        }
    }

}
