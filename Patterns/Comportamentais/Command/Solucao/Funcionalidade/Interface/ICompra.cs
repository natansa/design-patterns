using Gof.Patterns.Comportamentais.Command.Solucao.Models;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Funcionalidade.Interface
{
    public interface ICompra
    {
        void Adicionar(Produto produto);
        decimal ObterValorTotal();
        int ObterQuantidadeTotal();
    }
}