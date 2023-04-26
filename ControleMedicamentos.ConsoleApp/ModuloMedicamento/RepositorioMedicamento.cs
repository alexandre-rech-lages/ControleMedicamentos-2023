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
            Medicamento[] medicamentos = new Medicamento[listaRegistros.Count];

            int posicao = 0;
            foreach (Medicamento m in listaRegistros)
            {
                medicamentos[posicao++] = m;
            }

            Array.Sort(medicamentos, new ComparadorMedicamentosRetirados());

            return new ArrayList(medicamentos);
        }

        public ArrayList SelecionarMedicamentosEmFalta()
        {
            ArrayList listaMedicamentosEmFalta = new ArrayList();

            foreach (Medicamento m in listaRegistros)
            {
                if (m.quantidade == 0)
                    listaMedicamentosEmFalta.Add(m);
            }

            return listaMedicamentosEmFalta;
        }
    }


}
