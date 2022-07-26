using Gof.Patterns.Comportamentais.ChainOfResponsibility.Models;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Problema;
using Gof.Patterns.Comportamentais.ChainOfResponsibility.Solucao.Base;
using Microsoft.AspNetCore.Mvc;

namespace Gof.Controllers.Comportamentais
{
    [ApiController]
    [Route("[controller]")]
    public class ChainOfResponsibilityController : ControllerBase
    {
        private readonly ILogger<ChainOfResponsibilityController> _logger;
        private readonly IProblemaChainOfResponsibility _problema;
        private readonly IValidadorTransacao _solucao;

        public ChainOfResponsibilityController(ILogger<ChainOfResponsibilityController> logger, 
                                               IProblemaChainOfResponsibility problemaChainOfResponsibility,
                                               IValidadorTransacao solucao)
        {
            _logger = logger;
            _problema = problemaChainOfResponsibility;
            _solucao = solucao;
        }

        [HttpPost("problema")]
        public IActionResult Problema([FromBody] PedidoMagazine pedido)
        {
            _logger.LogInformation($"{nameof(ChainOfResponsibilityController)} - {nameof(Problema)}");
            var resultadoCompra = _problema.RealizarCompra(pedido);
            return StatusCode(StatusCodes.Status201Created, resultadoCompra);
        }

        [HttpPost("solucao")]
        public IActionResult Solucao([FromBody] PedidoMagazine pedido)
        {
            _logger.LogInformation($"{nameof(ChainOfResponsibilityController)} - {nameof(Solucao)}");
            var resultadoCompra = _solucao.RealizarCompra(pedido);
            return StatusCode(StatusCodes.Status201Created, resultadoCompra);
        }
    }
}