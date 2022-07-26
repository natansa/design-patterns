using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Commands.Interface
{
    public interface IPagarCommand : ICommand 
    {
        void Adicionar(ICarrinho carrinho);
    }
}