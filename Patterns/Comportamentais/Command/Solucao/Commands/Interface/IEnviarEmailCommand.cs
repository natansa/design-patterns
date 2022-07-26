using Gof.Patterns.Comportamentais.Command.Solucao.Executores.Interface;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Commands.Interface
{
    public interface IEnviarEmailCommand : ICommand 
    {
        void Adicionar(IEmail email);
    }
}