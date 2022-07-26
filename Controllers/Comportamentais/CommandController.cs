using Gof.Patterns.Comportamentais.Command.Solucao.Funcionalidade.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gof.Controllers.Comportamentais
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> _logger;
        private readonly ICompra _compras;
        private readonly IPagamento _pagamento;

        public CommandController(ILogger<CommandController> logger, ICompra compras, IPagamento pagamento)
        {
            _logger = logger;
            _compras = compras;
            _pagamento = pagamento;
        }

        [HttpPost("adicionar")]
        public IActionResult Adicionar([FromBody] Produto produto)
        {
            _logger.LogInformation($"{nameof(CommandController)} - {nameof(Adicionar)} - {nameof(Produto)}");
            _compras.Adicionar(produto);
            return StatusCode(StatusCodes.Status201Created, produto);
        }

        [HttpPost("pagar")]
        public IActionResult Pagar()
        {
            _logger.LogInformation($"{nameof(CommandController)} - {nameof(Pagar)}");
            _pagamento.RealizarPagamento();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}