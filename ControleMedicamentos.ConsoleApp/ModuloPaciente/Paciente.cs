using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : EntidadeBase
    {
        public string nome;
        public string cartaoSUS;

        public Paciente(string nome, string cartaoSUS)
        {
            this.nome = nome;
            this.cartaoSUS = cartaoSUS;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Paciente pacienteAtualizado = (Paciente)registroAtualizado;

            this.nome = pacienteAtualizado.nome;
            this.cartaoSUS = pacienteAtualizado.cartaoSUS;
        }
    }
}
