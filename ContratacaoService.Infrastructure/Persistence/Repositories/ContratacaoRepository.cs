using Microsoft.EntityFrameworkCore;
using Contratacao.Domain.Repositories;

namespace Contratacao.Infrastructure.Persistence.Repositories
{
    public class ContratacaoRepository : IContratacaoRepository
    {
        private readonly AppDbContext _context;

        public ContratacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Contratacao> ObterPorIdAsync(int id)
        {
            return await _context.Contratacoes.FindAsync(id);
        }

        public async Task<IEnumerable<Domain.Entities.Contratacao>> ListarTodasAsync()
        {
            return await _context.Contratacoes.ToListAsync();
        }

        public async Task AdicionarAsync(Domain.Entities.Contratacao contratacao)
        {
            await _context.Contratacoes.AddAsync(contratacao);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Domain.Entities.Contratacao contratacao)
        {
            _context.Contratacoes.Update(contratacao);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var contratacao = await ObterPorIdAsync(id);
            if (contratacao != null)
            {
                _context.Contratacoes.Remove(contratacao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SalvarAsync(Domain.Entities.Contratacao contratacao) // ✅ Novo método
        {
            await _context.Contratacoes.AddAsync(contratacao);
            await _context.SaveChangesAsync();
        }
    }
}