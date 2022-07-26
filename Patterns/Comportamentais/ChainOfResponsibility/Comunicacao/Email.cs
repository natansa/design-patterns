using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Comunicacao
{
    public class Email : IComunicacao
    {
        public void Enviar(ILogger logger, PedidoMagazine pedido) 
        {
            logger.LogInformation($"Enviando e-mail para {pedido.Departamento.ToString().ToLower()}@magazine.com.br");
        }
    }
}