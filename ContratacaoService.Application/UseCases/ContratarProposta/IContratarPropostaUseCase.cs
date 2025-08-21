namespace Contratacao.Application.UseCases.ContratarProposta
{
    public interface IContratarPropostaUseCase
    {
        Task ExecuteAsync(Guid propostaId);
    }
}