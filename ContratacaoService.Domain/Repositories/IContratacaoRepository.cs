namespace Contratacao.Domain.Repositories
{
    public interface IContratacaoRepository
    {
        Task<Entities.Contratacao> ObterPorIdAsync(int id);
        Task<IEnumerable<Entities.Contratacao>> ListarTodasAsync();
        Task AdicionarAsync(Entities.Contratacao contratacao);
        Task AtualizarAsync(Entities.Contratacao contratacao);
        Task RemoverAsync(int id);
        Task SalvarAsync(Domain.Entities.Contratacao contratacao);
    }
}
