using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

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

        public void RegistrarSaida()
        {
            this.medicamento.RemoverQuantidade(quantidade);
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (medicamento == null)
                erros.Add("O campo \"medicamento\" é obrigatório");

            if (funcionario == null)
                erros.Add("O campo \"funcionário\" é obrigatório");

            if (paciente == null)
                erros.Add("O campo \"paciente\" é obrigatório");

            if (data < DateTime.Now.Date)
                erros.Add("O campo \"data\" deve ser maior que a data atual");

            if (quantidade < 0)
                erros.Add("O campo \"quantidade\" deve ser maior que 0");

            if (medicamento != null && quantidade > medicamento.quantidade)
                erros.Add("O campo \"quantidade requisitada\" excedeu a quantidade em estoque deste medicamento");

            return erros;
        }
    }
}