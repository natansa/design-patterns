using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Problema
{
    public interface IProblemaChainOfResponsibility
    {
        ResultadoCompra RealizarCompra(PedidoMagazine pedido);
    }
}