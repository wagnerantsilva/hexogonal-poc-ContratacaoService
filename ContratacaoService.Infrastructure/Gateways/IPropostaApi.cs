using Contratacao.Infrastructure.DTOs;
using Refit;

namespace Contratacao.Infrastructure.Gateways
{
    public interface IPropostaApi
    {
        [Get("/api/propostas/{id}")]
        Task<PropostaDto> ObterPropostaPorIdAsync(Guid id);
    }
}