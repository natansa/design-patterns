using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Comunicacao
{
    public class Sms : IComunicacao
    {
        public void Enviar(ILogger logger, PedidoMagazine pedido) 
        {
            logger.LogInformation($"Enviando SMS para {pedido.Departamento.ToString().ToUpper()}");
        }
    }
}