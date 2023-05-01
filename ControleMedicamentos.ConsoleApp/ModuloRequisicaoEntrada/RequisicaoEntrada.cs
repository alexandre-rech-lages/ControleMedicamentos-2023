using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaoEntrada
{
    public class RequisicaoEntrada : EntidadeBase
    {
        public Medicamento medicamento;
        public int quantidade;
        public DateTime data;
        public Funcionario funcionario;     

        public RequisicaoEntrada(Medicamento medicamento, int quantidade, DateTime data, Funcionario funcionario)
        {
            this.medicamento = medicamento;
            this.quantidade = quantidade;
            this.data = data;
            this.funcionario = funcionario;

            this.medicamento.AdicionarQuantidade(quantidade);
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            RequisicaoEntrada requisicaoEntradaAtualizada = (RequisicaoEntrada) registroAtualizado;

            this.medicamento = requisicaoEntradaAtualizada.medicamento;
            this.quantidade = requisicaoEntradaAtualizada.quantidade;
            this.data = requisicaoEntradaAtualizada.data;
            this.funcionario = requisicaoEntradaAtualizada.funcionario;
        }

        public void DesfazerRegistroEntrada()
        {
            medicamento.RemoverQuantidade(quantidade);
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (medicamento == null)
                erros.Add("O campo \"medicamento\" é obrigatório");

            if (funcionario == null)
                erros.Add("O campo \"funcionário\" é obrigatório");

            if (data < DateTime.Now.Date)
                erros.Add("O campo \"data\" deve ser maior que a data atual");

            if (quantidade < 0 )
                erros.Add("O campo \"quantidade\" deve ser maior que 0");

            return erros;
        }
    }

}
