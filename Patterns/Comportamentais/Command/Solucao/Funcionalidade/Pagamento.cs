using Gof.Patterns.Comportamentais.Command.Solucao.Commands;
using Gof.Patterns.Comportamentais.Command.Solucao.Commands.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Executores;
using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Funcionalidade.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Funcionalidade
{
    public class Pagamento : IPagamento
    {
        private readonly ILogger<Pagamento> _logger;
        private readonly ICompra _compra;
        private readonly IAgenda _agenda;
        private readonly IAgendarCommand _agendarCommand;
        private readonly ICarrinho _carrinho;
        private readonly IPagarCommand _pagarCommand;
        private readonly IFila _fila;
        private readonly IColocarNaFilaCommand _colocarNaFilaCommand;
        private readonly IEmail _email;
        private readonly IEnviarEmailCommand _enviarEmailCommand;

        private ICollection<ICommand> Comandos { get; set; }

        public Pagamento(ILogger<Pagamento> logger,
                         ICompra compra,
                         IAgenda agenda, IAgendarCommand agendarCommand,
                         IFila fila, IColocarNaFilaCommand colocarNaFilaCommand,
                         IEmail email, IEnviarEmailCommand enviarEmailCommand,
                         ICarrinho carrinho, IPagarCommand pagarCommand)
        {
            _logger = logger;
            _compra = compra;
            Comandos = new List<ICommand>();
            _agenda = agenda;
            _agendarCommand = agendarCommand;
            _fila = fila;
            _colocarNaFilaCommand = colocarNaFilaCommand;
            _email = email;
            _enviarEmailCommand = enviarEmailCommand;
            _carrinho = carrinho;
            _pagarCommand = pagarCommand;
        }

        public void RealizarPagamento()
        {
            InserirComando(CriarComandoAgenda());
            InserirComando(CriarComandoFila());
            InserirComando(CriarComandoEmail());
            InserirComando(CriarComandoPagamento());
            ExecutarComandos();
        }

        private void InserirComando(ICommand command)
        {
            Comandos.Add(command);
        }

        private ICommand CriarComandoAgenda()
        {
            _agenda.Adicionar(_compra);
            _agendarCommand.Adicionar(_agenda);
            return _agendarCommand;
        }

        private ICommand CriarComandoFila()
        {
            _fila.Adicionar(_compra);
            _colocarNaFilaCommand.Adicionar(_fila);
            return _colocarNaFilaCommand;
        }

        private ICommand CriarComandoEmail()
        {
            _email.Adicionar(_compra);
            _enviarEmailCommand.Adicionar(_email);
            return _enviarEmailCommand;
        }

        private ICommand CriarComandoPagamento()
        {
            _carrinho.Adicionar(_compra);
            _pagarCommand.Adicionar(_carrinho);
            return _pagarCommand;
        }

        private void ExecutarComandos()
        {
            foreach (var comando in Comandos)
            {
                comando.Executar();
            }
        }
    }
}