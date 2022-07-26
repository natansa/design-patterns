using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Commands.Interface
{
    public interface IAgendarCommand : ICommand 
    {
        void Adicionar(IAgenda agenda);
    }
}