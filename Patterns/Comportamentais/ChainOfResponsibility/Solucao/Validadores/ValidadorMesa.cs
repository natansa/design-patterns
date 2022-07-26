using Gof.Patterns.Comportamentais.ChainOfResponsibility.Comunicacao;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Base;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Validadores
{
    public class ValidadorMesa : ValidadorTransacao
    {
        private readonly ILogger<ValidadorMesa> _logger;
        private readonly IComunicacao _comunicacao;
        private static readonly decimal _valorParaDesconto = 400M;
        private static readonly decimal _desconto = 0.01M;

        public ValidadorMesa(ILogger<ValidadorMesa> logger, IValidadorTransacao proximoValidador)
            : base(logger, proximoValidador)
        {
            _logger = logger;
            _comunicacao = new Sms();
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
            return pedido.Departamento == Departamento.Mesa;
        }
    }
}