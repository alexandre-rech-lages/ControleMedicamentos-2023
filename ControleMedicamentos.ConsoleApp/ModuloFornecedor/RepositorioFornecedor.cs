using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class RepositorioFornecedor : RepositorioBase
    {
        public RepositorioFornecedor(ArrayList listaForcedor)
        {
            this.listaRegistros = listaForcedor;
        }

        public override Fornecedor SelecionarPorId(int id)
        {
            return (Fornecedor)base.SelecionarPorId(id);
        }
    }
}
