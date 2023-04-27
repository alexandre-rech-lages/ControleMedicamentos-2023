using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class Fornecedor : EntidadeBase
    {
        public string nome;
        public string telefone;
        public string email;
        public string cidade;
        public string estado;

        public Fornecedor(string nome, string telefone, string email, string cidade, string estado)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
            this.cidade = cidade;
            this.estado = estado;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Fornecedor fornecedorAtualizado = (Fornecedor) registroAtualizado;

            this.nome = fornecedorAtualizado.nome;
            this.telefone = fornecedorAtualizado.telefone;
            this.email = fornecedorAtualizado.email;
            this.cidade = fornecedorAtualizado.cidade;
            this.estado = fornecedorAtualizado.estado;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (nome.Length <= 3)
                erros.Add("O campo \"nome\" precisa ter mais que 3 letras");

            if (string.IsNullOrEmpty(telefone.Trim()))
                erros.Add("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(email.Trim()))
                erros.Add("O campo \"email\" é obrigatório");            

            return erros;
        }
    }
}
