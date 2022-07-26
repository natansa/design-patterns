using Gof.Patterns.Comportamentais.Command.Solucao.Commands.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Commands
{
    public class ColocarNaFilaCommand : IColocarNaFilaCommand
    {
        private IFila _fila;

        public void Adicionar(IFila fila)
        {
            _fila = fila;
        }

        public void Executar()
        {
            _fila.Enfileirar();
        }
    }
}