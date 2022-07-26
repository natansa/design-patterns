using Gof.Patterns.Comportamentais.Command.Solucao.Commands.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Commands
{
    public class EnviarEmailCommand : IEnviarEmailCommand
    {
        private IEmail _email;

        public void Adicionar(IEmail email)
        {
            _email = email;
        }

        public void Executar()
        {
            _email.Enviar();
        }
    }
}