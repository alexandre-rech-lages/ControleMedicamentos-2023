using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaoEntrada
{
    public class RepositorioRequisicaoEntrada : RepositorioBase
    {
        public RepositorioRequisicaoEntrada(ArrayList listaRequisicaoEntrada)
        {
            this.listaRegistros = listaRequisicaoEntrada;
        }

        public override RequisicaoEntrada SelecionarPorId(int id)
        {
            return (RequisicaoEntrada)base.SelecionarPorId(id);
        }
    }

}
