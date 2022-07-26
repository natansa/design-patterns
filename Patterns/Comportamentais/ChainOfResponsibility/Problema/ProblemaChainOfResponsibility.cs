using Gof.Patterns.Comportamentais.ChainOfResponsibility.Comunicacao;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;

namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Problema
{
    public class ProblemaChainOfResponsibility : IProblemaChainOfResponsibility
    {
        private readonly ILogger<ProblemaChainOfResponsibility> _logger;
        private IComunicacao _comunicacao;

        public ProblemaChainOfResponsibility(ILogger<ProblemaChainOfResponsibility> logger)
        {
            _logger = logger;
        }

        public ResultadoCompra RealizarCompra(PedidoMagazine pedido)
        {
            var departamentoInteiro = Convert.ToInt32(pedido.Departamento);
            var departamentoInvalidoInteiro = Convert.ToInt32(Departamento.Invalido);

            if (departamentoInteiro >= departamentoInvalidoInteiro)
            {
                throw new ArgumentException("Departamento Inválido");
            }

            var desconto = decimal.Zero;
            var valorPago = decimal.Zero;

            if (pedido.Departamento == Departamento.Banho &&
                pedido.ValorTotalDaCompra >= 500)
            {
                desconto = pedido.ValorTotalDaCompra * 0.05M;
                valorPago = pedido.ValorTotalDaCompra - desconto;

                _comunicacao = new Email();
                _comunicacao.Enviar(_logger, pedido);

                return new ResultadoCompra
                (
                    Resultado(pedido, desconto, valorPago)
                );
            }

            if (pedido.Departamento == Departamento.Cama &&
                pedido.ValorTotalDaCompra >= 300)
            {
                desconto = pedido.ValorTotalDaCompra * 0.07M;
                valorPago = pedido.ValorTotalDaCompra - desconto;

                _comunicacao = new Mensageria();
                _comunicacao.Enviar(_logger, pedido);

                return new ResultadoCompra
                (
                    Resultado(pedido, desconto, valorPago)
                );
            }

            if (pedido.Departamento == Departamento.Mesa &&
                pedido.ValorTotalDaCompra >= 400)
            {
                desconto = pedido.ValorTotalDaCompra * 0.01M;
                valorPago = pedido.ValorTotalDaCompra - desconto;

                _comunicacao = new Sms();
                _comunicacao.Enviar(_logger, pedido);

                return new ResultadoCompra
                (
                    Resultado(pedido, desconto, valorPago)
                );
            }

            if (pedido.Departamento == Departamento.Acessorios &&
                pedido.ValorTotalDaCompra >= 100)
            {
                desconto = pedido.ValorTotalDaCompra * 0.03M;
                valorPago = pedido.ValorTotalDaCompra - desconto;

                _comunicacao = new Whatsapp();
                _comunicacao.Enviar(_logger, pedido);

                return new ResultadoCompra
                (
                    Resultado(pedido, desconto, valorPago)
                );
            }

            if (pedido.Departamento == Departamento.Roupas &&
                pedido.ValorTotalDaCompra >= 300)
            {
                desconto = pedido.ValorTotalDaCompra * 0.05M;
                valorPago = pedido.ValorTotalDaCompra - desconto;
                return new ResultadoCompra
                (
                    Resultado(pedido, desconto, valorPago)
                );
            }

            valorPago = pedido.ValorTotalDaCompra - desconto;

            return new ResultadoCompra
            (
                Resultado(pedido, desconto, valorPago)
            );
        }

        private static string Resultado(PedidoMagazine pedido, decimal desconto, decimal valorPago)
        {
            return $"Valor total: {pedido.ValorTotalDaCompra}. Desconto de: {desconto}. Valor pago: {valorPago}.";
        }
    }
}
