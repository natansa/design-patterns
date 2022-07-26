using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Base;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Validadores
{
    public class Validador : IValidadorTransacao
    {
        public ResultadoCompra RealizarCompra(PedidoMagazine pedido)
        {
            var departamentoInteiro = Convert.ToInt32(pedido.Departamento);
            var departamentoInvalidoInteiro = Convert.ToInt32(Departamento.Invalido);

            if (departamentoInteiro >= departamentoInvalidoInteiro)
            {
                throw new ArgumentException("Departamento Inválido");
            }

            return new ResultadoCompra
            (
                $"Valor total: {pedido.ValorTotalDaCompra}. Desconto de: {decimal.Zero}. Valor pago: {pedido.ValorTotalDaCompra}."
            );
        }
    }
}