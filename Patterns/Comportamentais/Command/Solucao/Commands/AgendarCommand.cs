using Gof.Patterns.Comportamentais.Command.Solucao.Commands.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Commands
{
    public class AgendarCommand : IAgendarCommand
    {
        private IAgenda _agenda;

        public void Adicionar(IAgenda agenda) 
        {
            _agenda = agenda;
        }

        public void Executar()
        {
            _agenda.Agendar();
        }
    }
}