using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase
    {
        public RepositorioFuncionario(ArrayList listaFuncionario)
        {
            this.listaRegistros = listaFuncionario;
        }

        public override Funcionario SelecionarPorId(int id)
        {
            return (Funcionario)base.SelecionarPorId(id);
        }
    }

}
