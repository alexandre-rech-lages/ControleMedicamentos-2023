using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using System.Collections;
using System.Globalization;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : TelaBase
    {
        private RepositorioMedicamento repositorioMedicamento;
        private TelaFornecedor telaFornecedor;
        private RepositorioFornecedor repositorioFornecedor;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento,
            TelaFornecedor telaFornecedor, RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioBase = repositorioMedicamento;
            this.repositorioMedicamento = repositorioMedicamento;
            this.telaFornecedor = telaFornecedor;
            this.repositorioFornecedor = repositorioFornecedor;

            nomeEntidade = "Medicamento";
            sufixo = "s";
        }

        public override void InserirNovoRegistro()
        {
            bool temRegistros = repositorioFornecedor.TemRegistros();

            if (temRegistros == false)
            {
                MostrarMensagem("Cadastre ao menos um fornecedor para cadastrar medicamentos", ConsoleColor.DarkYellow);
                return;
            }

            base.InserirNovoRegistro();
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Medicamentos \n");

            Console.WriteLine("Digite 1 para Inserir Medicamento");
            Console.WriteLine("Digite 2 para Visualizar Medicamentos");
            Console.WriteLine("Digite 3 para Editar Medicamentos");
            Console.WriteLine("Digite 4 para Excluir Medicamentos");
            Console.WriteLine("Digite 5 para Visualizar Medicamentos Mais Retirados");
            Console.WriteLine("Digite 6 para Visualizar Medicamentos em Falta\n");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}", "Id", "Nome", "Fornecedor", "Quantidade", "Qtd Retiradas");

            Console.WriteLine("---------------------------------------------------------------------------------------");

            foreach (Medicamento medicamento in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                    medicamento.id, medicamento.nome, medicamento.fornecedor.nome, medicamento.quantidade, medicamento.quantidadeRequisicoesSaida);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Fornecedor fornecedor = ObterFornecedor();

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o lote: ");
            string lote = Console.ReadLine();

            Console.Write("Digite a data de validade: ");

            DateTime dataValidade = DateTime.MinValue;

            bool dataInvalida;

            do
            {
                dataInvalida = false;

                try
                {
                    dataValidade = Convert.ToDateTime(Console.ReadLine());
                }
                catch (FormatException)
                {
                    dataInvalida = true;
                    MostrarMensagem("Formato da data está inválido. Ex: 12/12/2000",
                        ConsoleColor.DarkYellow);
                }
                catch (ArgumentNullException)
                {
                    dataInvalida = true;
                    MostrarMensagem("Informe uma data. Ex: 12/12/2000",
                        ConsoleColor.DarkYellow);
                }

            } while (dataInvalida);

            return new Medicamento(nome, descricao, lote, dataValidade, fornecedor);
        }

        public void VisualizarMedicamentosMaisRetirados()
        {
            MostrarCabecalho("Cadastro de Medicamentos", "Visualizando medicamentos mais Retirados...");

            ArrayList medicamentosMaisRetirados = repositorioMedicamento.SelecionarMedicamentosMaisRetirados();

            if (medicamentosMaisRetirados.Count == 0)
            {
                MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(medicamentosMaisRetirados);
        }

        public void VisulizarMedicamentosEmFalta()
        {
            MostrarCabecalho("Cadastro de Medicamentos", "Visualizando medicamentos em falta...");

            ArrayList medicamentosMaisRetirados = repositorioMedicamento.SelecionarMedicamentosEmFalta();

            if (medicamentosMaisRetirados.Count == 0)
            {
                MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            MostrarTabela(medicamentosMaisRetirados);
        }

        private Fornecedor ObterFornecedor()
        {
            telaFornecedor.VisualizarRegistros(false);

            Fornecedor fornecedor = (Fornecedor)telaFornecedor.EncontrarRegistro("Digite o id do fornecedor: ");

            Console.WriteLine();

            return fornecedor;
        }
    }
}
