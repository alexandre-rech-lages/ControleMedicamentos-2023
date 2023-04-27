using System.Collections;

namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int id;

        public abstract void AtualizarInformacoes(EntidadeBase registroAtualizado);

        public abstract ArrayList Validar();
        
    }
}