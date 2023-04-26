using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaoSaida
{
    public class TelaRequisicaoSaida : TelaBase
    {
        private RepositorioRequisicaoSaida repositorioRequisicaoSaida;

        private RepositorioPaciente repositorioPaciente;
        private TelaPaciente telaPaciente;

        private RepositorioFuncionario repositorioFuncionario;
        private TelaFuncionario telaFuncionario;

        private RepositorioMedicamento repositorioMedicamento;
        private TelaMedicamento telaMedicamento;

        public TelaRequisicaoSaida(RepositorioRequisicaoSaida repositorioRequisicaoSaida,
            RepositorioPaciente repositorioPaciente, TelaPaciente telaPaciente, 
            RepositorioFuncionario repositorioFuncionario, TelaFuncionario telaFuncionario, 
            RepositorioMedicamento repositorioMedicamento, TelaMedicamento telaMedicamento)
        {
            this.repositorioBase = repositorioRequisicaoSaida;
            this.repositorioPaciente = repositorioPaciente;
            this.telaPaciente = telaPaciente;
            this.repositorioFuncionario = repositorioFuncionario;
            this.telaFuncionario = telaFuncionario;
            this.repositorioMedicamento = repositorioMedicamento;
            this.telaMedicamento = telaMedicamento;

            nomeEntidade = "Requisição de Saída";
        }

        public override void EditarRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Editando um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            Console.Write("Digite o id do registro: ");
            int id = Convert.ToInt32(Console.ReadLine());

            RequisicaoSaida requisicaoSaida = repositorioRequisicaoSaida.SelecionarPorId(id);

            EntidadeBase registroAtualizado = ObterRegistro();

            requisicaoSaida.DesfazerRegistroSaida();

            repositorioBase.Editar(id, registroAtualizado);

            MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green);
        }

        public override void ExcluirRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            Console.Write("Digite o id do registro: ");
            int id = Convert.ToInt32(Console.ReadLine());

            RequisicaoSaida requisicaoEntrada = repositorioRequisicaoSaida.SelecionarPorId(id);

            requisicaoEntrada.DesfazerRegistroSaida();

            repositorioBase.Excluir(id);

            MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green);
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            const string FORMATO_TABELA = "{0, -10} | {1, -10} | {2, -20} | {3, -20} | {4, -20} | {5, -20}";

            Console.WriteLine(FORMATO_TABELA, "Id", "Data", "Medicamento", "Fonecedor", "Paciente", "Quantidade");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (RequisicaoSaida requisicaoSaida in registros)
            {
                Console.WriteLine(FORMATO_TABELA,
                    requisicaoSaida.id,
                    requisicaoSaida.data.ToShortDateString(),
                    requisicaoSaida.medicamento.nome,
                    requisicaoSaida.medicamento.fornecedor.nome,
                    requisicaoSaida.paciente.nome,
                    requisicaoSaida.quantidade);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Medicamento medicamento = ObterMedicamento();

            Funcionario funcionario = ObterFuncionario();

            Paciente paciente = ObterPaciente();

            Console.Write("Digite a quantidade de caixas: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            return new RequisicaoSaida(medicamento, quantidade, data, funcionario, paciente);
        }

        private Paciente ObterPaciente()
        {
            telaPaciente.VisualizarRegistros(false);

            //Selecionar um paciente por id
            Console.Write("\nDigite o id do Funcionário: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            //Pegar o objeto no repositorio de Paciente a partir do id selecionado
            Paciente paciente = repositorioPaciente.SelecionarPorId(idPaciente);

            Console.WriteLine();

            return paciente;
        }

        private Funcionario ObterFuncionario()
        {
            telaFuncionario.VisualizarRegistros(false);

            //Selecionar um funcionario por id
            Console.Write("\nDigite o id do Funcionário: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());

            //Pegar o objeto no repositorio de Funcionario a partir do id selecionado
            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(idFuncionario);

            Console.WriteLine();

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

            Console.WriteLine();

            return medicamento;
        }
    }
}
