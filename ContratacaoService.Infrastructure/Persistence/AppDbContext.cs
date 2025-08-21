using Contratacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contratacao.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Proposta> Propostas { get; set; }
        public DbSet<Domain.Entities.Contratacao> Contratacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.Contratacao>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.PropostaId).IsRequired();
                entity.Property(c => c.DataContratacao).IsRequired();
            });

            modelBuilder.Entity<Proposta>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Status).IsRequired();
            });
        }
    }
}