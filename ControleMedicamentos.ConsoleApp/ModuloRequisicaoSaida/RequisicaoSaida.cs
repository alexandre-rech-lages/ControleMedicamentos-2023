using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaoSaida
{
    public class RequisicaoSaida : EntidadeBase
    {
        public Medicamento medicamento;
        public int quantidade;
        public DateTime data;
        public Funcionario funcionario;

        public Paciente paciente;

        public RequisicaoSaida(Medicamento medicamento, int quantidade, DateTime data, 
            Funcionario funcionario, Paciente paciente)
        {
            this.medicamento = medicamento;
            this.data = data;
            this.funcionario = funcionario;
            this.paciente = paciente;
            this.quantidade = quantidade;
            
            this.medicamento.RemoverQuantidade(quantidade);
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            RequisicaoSaida requisicaoSaidaAtualizada = (RequisicaoSaida)registroAtualizado;

            this.medicamento = requisicaoSaidaAtualizada.medicamento;
            this.quantidade = requisicaoSaidaAtualizada.quantidade;
            this.data = requisicaoSaidaAtualizada.data;
            this.funcionario = requisicaoSaidaAtualizada.funcionario;
            this.paciente = requisicaoSaidaAtualizada.paciente;
        }

        public void DesfazerRegistroSaida()
        {
            medicamento.AdicionarQuantidade(quantidade);
        }
    }
}
