using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class RepositorioPaciente : RepositorioBase
    {
        public RepositorioPaciente(ArrayList listaPaciente)
        {
            this.listaRegistros = listaPaciente;
        }

        public override Paciente SelecionarPorId(int id)
        {
            return (Paciente)base.SelecionarPorId(id);
        }
    }
}
