using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamento : RepositorioBase 
    {
        public RepositorioMedicamento(ArrayList listaMedicamento)
        {
            this.listaRegistros = listaMedicamento;
        }

        public override Medicamento SelecionarPorId(int id)
        {
            return (Medicamento)base.SelecionarPorId(id);
        }

        public ArrayList SelecionarMedicamentosMaisRetirados()
        {
            //fazer a ordenação...
            return listaRegistros;
        }

        internal ArrayList SelecionarMedicamentosEmFalta()
        {
            //fazer o filtro...
            return listaRegistros;
        }
    }


}
