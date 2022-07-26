using Gof.Patterns.Comportamentais.Command.Solucao.Funcionalidade.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface
{
    public interface IExecutor
    {
        void Adicionar(ICompra compra);
    }
}
