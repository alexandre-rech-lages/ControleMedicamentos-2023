﻿using ControleMedicamentos.ConsoleApp.Compartilhado;
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


        public override void EditarRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Editando um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            Console.Write("Digite o id do registro: ");
            int id = Convert.ToInt32(Console.ReadLine());
            
            RequisicaoEntrada requisicaoEntrada = repositorioRequisicaoEntrada.SelecionarPorId(id);            

            EntidadeBase registroAtualizado = ObterRegistro();

            requisicaoEntrada.DesfazerRegistroEntrada();

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
            //Visulizar a lista de funcionarios
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
