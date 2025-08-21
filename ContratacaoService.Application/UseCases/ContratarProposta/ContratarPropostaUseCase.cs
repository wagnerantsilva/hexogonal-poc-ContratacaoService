using Contratacao.Domain.Repositories;
using Contratacao.Infrastructure.Gateways;

namespace Contratacao.Application.UseCases.ContratarProposta
{
    public class ContratarPropostaUseCase : IContratarPropostaUseCase
    {
        private readonly IPropostaApi _propostaApi;
        private readonly IContratacaoRepository _contratacaoRepository;

        public ContratarPropostaUseCase(IPropostaApi propostaApi, IContratacaoRepository contratacaoRepository)
        {
            _propostaApi = propostaApi;
            _contratacaoRepository = contratacaoRepository;
        }

        public async Task ExecuteAsync(Guid propostaId)
        {
            var proposta = await _propostaApi.ObterPropostaPorIdAsync(propostaId);

            if (proposta == null)
                throw new InvalidOperationException("Proposta não encontrada.");

            if (proposta.Status != "Aprovada")
                throw new InvalidOperationException("Proposta não está aprovada.");

            var contratacao = new Domain.Entities.Contratacao(proposta.Id, DateTime.UtcNow);
            await _contratacaoRepository.SalvarAsync(contratacao);
        }
    }
}