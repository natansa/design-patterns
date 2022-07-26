using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Base
{
    public interface IValidadorTransacao
    {
        ResultadoCompra RealizarCompra(PedidoMagazine pedido);
    }
}