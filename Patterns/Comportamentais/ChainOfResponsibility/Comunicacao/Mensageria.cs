using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Comunicacao
{
    public class Mensageria : IComunicacao
    {
        public void Enviar(ILogger logger, PedidoMagazine pedido) 
        {
            logger.LogInformation($"Enfileirando na fila {pedido.Departamento.ToString().ToLower()}-exchange");
        }
    }
}