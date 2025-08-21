using Contratacao.Application.UseCases.ContratarProposta;
using Contratacao.Domain.Repositories;
using Contratacao.Infrastructure.DTOs;
using Contratacao.Infrastructure.Gateways;
using Moq;
using Xunit;

namespace Contratacao.Tests.Application.UseCases
{
    public class ContratarPropostaUseCaseTests
    {
        private readonly Mock<IPropostaApi> _propostaApiMock = new();
        private readonly Mock<IContratacaoRepository> _contratacaoRepoMock = new();

        [Fact]
        public async Task ExecutarAsync_DeveSalvarContratacao_QuandoPropostaAprovada()
        {
            // Arrange
            var propostaId = Guid.NewGuid();
            var propostaDto = new PropostaDto { Id = propostaId, Status = "Aprovada" };


            _propostaApiMock
                .Setup(x => x.ObterPropostaPorIdAsync(propostaId))
                .ReturnsAsync(propostaDto);

            var useCase = new ContratarPropostaUseCase(
                _propostaApiMock.Object,
                _contratacaoRepoMock.Object
            );

            // Act
            await useCase.ExecuteAsync(propostaId);

            // Assert
            _contratacaoRepoMock.Verify(
                x => x.SalvarAsync(It.IsAny<Domain.Entities.Contratacao>()),
                Times.Once
            );
        }
    }
}