using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using System.Collections;

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

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(cartaoSUS.Trim()))
                erros.Add("O campo \"cartaoSUS\" é obrigatório");

            return erros;
        }
    }
}
