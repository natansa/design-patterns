using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Base;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Validadores
{
    public class ValidadorRoupas : ValidadorTransacao
    {
        private static readonly decimal _valorParaDesconto = 300M;
        private static readonly decimal _desconto = 0.05M;

        public ValidadorRoupas(ILogger<ValidadorRoupas> logger, IValidadorTransacao proximoValidador)
            : base(logger, proximoValidador) { }

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

            return new ResultadoCompra
            (
                $"Valor total: {pedido.ValorTotalDaCompra}. Desconto de: {desconto}. Valor pago: {valorPago}."
            );
        }

        protected override bool PodeValidar(PedidoMagazine pedido)
        {
            return pedido.Departamento == Departamento.Roupas;
        }
    }
}