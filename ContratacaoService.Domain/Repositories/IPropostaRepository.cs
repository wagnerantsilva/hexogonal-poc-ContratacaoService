using Contratacao.Domain.Entities;

namespace Contratacao.Domain.Repositories
{
    public interface IPropostaRepository
    {
        Task<Proposta?> ObterPorIdAsync(Guid id);
        Task SalvarAsync(Proposta proposta);
    }
}
