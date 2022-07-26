using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Funcionalidade.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Executores
{
    public class Carrinho : ICarrinho
    {
        private readonly ILogger<Funcionalidade.Pagamento> _logger;
        private ICompra _compra;

        public Carrinho(ILogger<Funcionalidade.Pagamento> logger)
        {
            _logger = logger;
        }

        public void Adicionar(ICompra compra)
        {
            _compra = compra;
        }

        public void Pagar()
        {
            _logger.LogInformation($"Pagamento realizado no valor de R$ {_compra.ObterValorTotal()}");
        }
    }
}