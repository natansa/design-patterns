using Gof.Patterns.Comportamentais.ChainOfResponsibility.Comunicacao;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Base;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Validadores
{
    public class ValidadorBanho : ValidadorTransacao
    {
        private readonly ILogger<ValidadorBanho> _logger;
        private readonly IComunicacao _comunicacao;
        private static readonly decimal _valorParaDesconto = 500M;
        private static readonly decimal _desconto = 0.05M;

        public ValidadorBanho(ILogger<ValidadorBanho> logger, IValidadorTransacao proximoValidador) 
            : base(logger, proximoValidador) 
        {
            _logger = logger;
            _comunicacao = new Email();
        }

        protected override ResultadoCompra ExecutarValidacao(PedidoMagazine pedido)
        {
            var desconto = decimal.Zero;
            var valorPago = decimal.Zero;

            if (pedido.ValorTotalDaCompra >= _valorParaDesconto)
            {
                desconto = pedido.ValorTotalDaCompra * _desconto;
                valorPago = pedido.ValorTotalDaCompra - desconto;
            }
            else
            {
                valorPago = pedido.ValorTotalDaCompra;
            }

            _comunicacao.Enviar(_logger, pedido);

            return new ResultadoCompra
            (
                $"Valor total: {pedido.ValorTotalDaCompra}. Desconto de: {desconto}. Valor pago: {valorPago}."
            );
        }

        protected override bool PodeValidar(PedidoMagazine pedido)
        {
            return pedido.Departamento == Departamento.Banho;
        }
    }
}