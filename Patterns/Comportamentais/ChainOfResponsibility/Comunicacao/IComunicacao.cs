using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Comunicacao
{
    public interface IComunicacao
    {
        void Enviar(ILogger logger, PedidoMagazine pedido);
    }
}