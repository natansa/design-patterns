using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Commands.Interface
{
    public interface IColocarNaFilaCommand : ICommand 
    {
        void Adicionar(IFila fila);
    }
}