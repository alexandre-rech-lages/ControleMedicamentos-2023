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

        public override void InserirNovoRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Inserindo um novo registro...");

            bool temFuncionarios = repositorioFuncionario.TemRegistros();

            if (temFuncionarios == false)
            {
                MostrarMensagem("Cadastre ao menos um funcionário para cadastrar requisições de saída", ConsoleColor.DarkYellow);
                return;
            }

            bool temMedicamentos = repositorioMedicamento.TemRegistros();

            if (temMedicamentos == false)
            {
                MostrarMensagem("Cadastre ao menos um medicamento para cadastrar requisições de saída", ConsoleColor.DarkYellow);
                return;
            }

            bool temPacientes = repositorioPaciente.TemRegistros();

            if (temPacientes == false)
            {
                MostrarMensagem("Cadastre ao menos um paciente para cadastrar requisições de saída", ConsoleColor.DarkYellow);
                return;
            }
            
            RequisicaoSaida registro = (RequisicaoSaida)ObterRegistro();

            if (TemErrosDeValidacao(registro))
            {
                return;
            }

            registro.RegistrarSaida();

            repositorioBase.Inserir(registro);

            MostrarMensagem("Registro inserido com sucesso!", ConsoleColor.Green);
        }

        public override void EditarRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Editando um registro já cadastrado...");

            bool temFuncionarios = repositorioFuncionario.TemRegistros();

            if (temFuncionarios == false)
            {
                MostrarMensagem("Cadastre ao menos um funcionário para cadastrar requisições de saída", ConsoleColor.DarkYellow);
                return;
            }

            bool temMedicamentos = repositorioMedicamento.TemRegistros();

            if (temMedicamentos == false)
            {
                MostrarMensagem("Cadastre ao menos um medicamento para cadastrar requisições de saída", ConsoleColor.DarkYellow);
                return;
            }

            bool temPacientes = repositorioPaciente.TemRegistros();

            if (temPacientes == false)
            {
                MostrarMensagem("Cadastre ao menos um paciente para cadastrar requisições de saída", ConsoleColor.DarkYellow);
                return;
            }

            VisualizarRegistros(false);

            Console.WriteLine();

            int id = EncontrarId();

            RequisicaoSaida requisicaoSaida = repositorioRequisicaoSaida.SelecionarPorId(id);

            RequisicaoSaida registroAtualizado = (RequisicaoSaida)ObterRegistro();

            requisicaoSaida.DesfazerRegistroSaida();

            if (TemErrosDeValidacao(registroAtualizado))
            {
                return;
            }

            registroAtualizado.RegistrarSaida();

            repositorioBase.Editar(id, registroAtualizado);

            MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green);
        }

        public override void ExcluirRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            int id = EncontrarId();

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

            int id = EncontrarId(repositorioPaciente);

            Paciente paciente = repositorioPaciente.SelecionarPorId(id);

            Console.WriteLine();

            return paciente;
        }

        private Funcionario ObterFuncionario()
        {
            telaFuncionario.VisualizarRegistros(false);

            int id = EncontrarId(repositorioFuncionario);
            
            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(id);

            Console.WriteLine();

            return funcionario;
        }

        private Medicamento ObterMedicamento()
        {
            telaMedicamento.VisualizarRegistros(false);

            int id = EncontrarId(repositorioMedicamento);

            Medicamento medicamento = repositorioMedicamento.SelecionarPorId(id);

            Console.WriteLine();

            return medicamento;
        }
    }
}
