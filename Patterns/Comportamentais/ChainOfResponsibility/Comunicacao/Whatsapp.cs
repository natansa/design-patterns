using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Comunicacao
{
    public class Whatsapp : IComunicacao
    {
        public void Enviar(ILogger logger, PedidoMagazine pedido) 
        {
            logger.LogInformation($"Enviando Whatsapp para {pedido.Departamento.ToString().ToUpper()}");
        }
    }
}