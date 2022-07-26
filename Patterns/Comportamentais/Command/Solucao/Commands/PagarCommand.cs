using Gof.Patterns.Comportamentais.Command.Solucao.Commands.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Executores;
using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Commands
{
    public class PagarCommand : IPagarCommand
    {
        private ICarrinho _carrinho;

        public void Adicionar(ICarrinho carrinho)
        {
            _carrinho = carrinho;
        }

        public void Executar()
        {
            _carrinho.Pagar();
        }
    }
}