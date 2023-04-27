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

        public override void InserirNovoRegistro()
        {
            bool temFuncionarios = repositorioFuncionario.TemRegistros();

            if (temFuncionarios == false)
            {
                MostrarMensagem("Cadastre ao menos um funcionário para cadastrar requisições de entrada", ConsoleColor.DarkYellow);
                return;
            }

            bool temMedicamentos = repositorioMedicamento.TemRegistros();

            if (temMedicamentos == false)
            {
                MostrarMensagem("Cadastre ao menos um medicamento para cadastrar requisições de entrada", ConsoleColor.DarkYellow);
                return;
            }

            base.InserirNovoRegistro();
        }

        public override void EditarRegistro()
        {
            bool temFuncionarios = repositorioFuncionario.TemRegistros();

            if (temFuncionarios == false)
            {
                MostrarMensagem("Cadastre ao menos um funcionário para cadastrar requisições de entrada", ConsoleColor.DarkYellow);
                return;
            }

            bool temMedicamentos = repositorioMedicamento.TemRegistros();

            if (temMedicamentos == false)
            {
                MostrarMensagem("Cadastre ao menos um medicamento para cadastrar requisições de entrada", ConsoleColor.DarkYellow);
                return;
            }

            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Editando um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            int id = EncontrarId();

            RequisicaoEntrada requisicaoEntrada = repositorioRequisicaoEntrada.SelecionarPorId(id);            

            EntidadeBase registroAtualizado = ObterRegistro();

            requisicaoEntrada.DesfazerRegistroEntrada();

            if (TemErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();

                return;
            }

            repositorioBase.Editar(id, registroAtualizado);

            MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green);
        }

        public override void ExcluirRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            int id = EncontrarId();

            RequisicaoEntrada requisicaoEntrada = repositorioRequisicaoEntrada.SelecionarPorId(id);

            requisicaoEntrada.DesfazerRegistroEntrada();

            repositorioBase.Excluir(id);

            MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green);
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
