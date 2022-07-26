using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Funcionalidade.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Executores
{
    public class Fila : IFila
    {
        private readonly ILogger<Funcionalidade.Pagamento> _logger;
        private ICompra _compra;

        public Fila(ILogger<Funcionalidade.Pagamento> logger)
        {
            _logger = logger;
        }

        public void Adicionar(ICompra compra)
        {
            _compra = compra;
        }

        public void Enfileirar()
        {
            _logger.LogInformation($"Enfileirando compra de {_compra.ObterQuantidadeTotal()} itens, no total de R$ {_compra.ObterValorTotal()}");
        }
    }
}