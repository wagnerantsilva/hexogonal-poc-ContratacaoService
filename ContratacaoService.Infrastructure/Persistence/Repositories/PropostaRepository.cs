using Contratacao.Domain.Entities;
using Contratacao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Contratacao.Infrastructure.Persistence.Repositories
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly AppDbContext _context;

        public PropostaRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Proposta?> ObterPorIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID da proposta não pode ser vazio.", nameof(id));

            var proposta = await _context.Propostas.FindAsync(id);

            return proposta; 
        }

        public async Task SalvarAsync(Proposta proposta)
        {
            if (proposta == null)
                throw new ArgumentNullException(nameof(proposta), "A proposta não pode ser nula.");

            var existente = await _context.Propostas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == proposta.Id);

            if (existente == null)
                await _context.Propostas.AddAsync(proposta);
            else
                _context.Propostas.Update(proposta);

            await _context.SaveChangesAsync();
        }
    }
}