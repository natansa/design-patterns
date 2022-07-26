using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Base
{
    public abstract class ValidadorTransacao : IValidadorTransacao
    {
        private readonly ILogger<ValidadorTransacao> _logger;
        private readonly IValidadorTransacao _proximoValidador;

        protected ValidadorTransacao(ILogger<ValidadorTransacao> logger, IValidadorTransacao proximoValidador)
        {
            _logger = logger;
            _proximoValidador = proximoValidador;
        }

        public ResultadoCompra RealizarCompra(PedidoMagazine pedido)
        {
            if (PodeValidar(pedido))
            {
                return ExecutarValidacao(pedido);
            }

            return _proximoValidador.RealizarCompra(pedido);
        }

        protected abstract ResultadoCompra ExecutarValidacao(PedidoMagazine pedido);

        protected abstract bool PodeValidar(PedidoMagazine pedido);
    }
}
