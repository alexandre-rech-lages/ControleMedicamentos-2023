﻿using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicaoEntrada;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor(new ArrayList());
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente(new ArrayList());
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(new ArrayList());
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento(new ArrayList());

            RepositorioRequisicaoEntrada repositorioRequisicaoEntrada = new RepositorioRequisicaoEntrada(new ArrayList());

            CadastrarRegistros(repositorioFuncionario, repositorioFornecedor, repositorioMedicamento, repositorioPaciente);

            TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioFornecedor);
            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
            TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);            

            TelaMedicamento telaMedicamento = new TelaMedicamento(repositorioMedicamento, telaFornecedor, repositorioFornecedor);


            TelaRequisicaoEntrada telaRequisicaoEntrada = new TelaRequisicaoEntrada(repositorioRequisicaoEntrada,
                repositorioFuncionario, repositorioMedicamento, telaFuncionario, telaMedicamento);

            TelaPrincipal principal = new TelaPrincipal();

            while (true)
            {
                string opcao = principal.ApresentarMenu();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string subMenu = telaFornecedor.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaFornecedor.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaFornecedor.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaFornecedor.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaFornecedor.ExcluirRegistro();
                    }
                }
                else if (opcao == "2")
                {
                    string subMenu = telaFuncionario.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaFuncionario.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaFuncionario.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaFuncionario.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaFuncionario.ExcluirRegistro();
                    }
                }
                else if (opcao == "3")
                {
                    string subMenu = telaPaciente.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaPaciente.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaPaciente.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaPaciente.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaPaciente.ExcluirRegistro();
                    }
                }
                else if (opcao == "4")
                {
                    string subMenu = telaMedicamento.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaMedicamento.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaMedicamento.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaMedicamento.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaMedicamento.ExcluirRegistro();
                    }
                    else if (subMenu == "5")
                    {
                        telaMedicamento.VisualizarMedicamentosMaisRetirados();
                    }
                    else if (subMenu == "6")
                    {
                        telaMedicamento.VisulizarMedicamentosEmFalta();
                    }
                }
                else if (opcao == "5")
                {
                    string subMenu = telaRequisicaoEntrada.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaRequisicaoEntrada.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaRequisicaoEntrada.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaRequisicaoEntrada.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaRequisicaoEntrada.ExcluirRegistro();
                    }
                }
            }
        }


        private static void CadastrarRegistros(
            RepositorioFuncionario repositorioFuncionario,
            RepositorioFornecedor repositorioFornecedor,
            RepositorioMedicamento repositorioMedicamento,
            RepositorioPaciente repositorioPaciente)
        {

            Funcionario funcionario1 = new Funcionario("Alexandre Rech", "rech", "123");
            Funcionario funcionario2 = new Funcionario("Tiago Santini", "santini", "456");

            repositorioFuncionario.Inserir(funcionario1);
            repositorioFuncionario.Inserir(funcionario2);

            Fornecedor fornecedor1 = new Fornecedor("Ultrafarma", "987654312", "ultrafarma@gmail.com", "São Paulo", "SP");
            Fornecedor fornecedor2 = new Fornecedor("Medica Super", "12345679", "medica@gmail.com", "Rio de Janeiro", "RJ");

            repositorioFornecedor.Inserir(fornecedor1);
            repositorioFornecedor.Inserir(fornecedor2);

            Medicamento medicamento1 = new Medicamento("Gliclazida", "Remédio p/ Diabetes", "321-987", new DateTime(2024, 01, 01), fornecedor1);
            Medicamento medicamento2 = new Medicamento("Entresto", "Remédio p/ Coração", "987-321", new DateTime(2024, 01, 01), fornecedor2);

            repositorioMedicamento.Inserir(medicamento1);
            repositorioMedicamento.Inserir(medicamento2);

            Paciente paciente1 = new Paciente("Gabriel Rech", "741258963");
            Paciente paciente2 = new Paciente("Palmira Souza", "582147852");
            Paciente paciente3 = new Paciente("Léo Rech", "111111111");
            Paciente paciente4 = new Paciente("Diane Rech", "222222222");

            repositorioPaciente.Inserir(paciente1);
            repositorioPaciente.Inserir(paciente2);
            repositorioPaciente.Inserir(paciente3);
            repositorioPaciente.Inserir(paciente4);


        }
    }
}