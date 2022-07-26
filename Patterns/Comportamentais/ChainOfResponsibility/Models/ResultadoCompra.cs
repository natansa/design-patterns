namespace Gof.Patterns.Comportamentais.ChainOfResponsibility.Models
{
    public class ResultadoCompra
    {
        public ResultadoCompra(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; }
    }
}