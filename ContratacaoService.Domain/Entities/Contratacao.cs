namespace Contratacao.Domain.Entities
{
    public class Contratacao
    {
        public Guid Id { get; private set; }
        public Guid PropostaId { get; private set; }
        public DateTime DataContratacao { get; private set; }


        protected Contratacao() { }


        public Contratacao(Guid propostaId)
        {
            if (propostaId == Guid.Empty)
                throw new ArgumentException("ID da proposta não pode ser vazio.");

            Id = Guid.NewGuid();
            PropostaId = propostaId;
            DataContratacao = DateTime.UtcNow;
        }
        public Contratacao(Guid propostaId, DateTime dataContratacao)
        {
            if (propostaId == Guid.Empty)
                throw new ArgumentException("ID da proposta não pode ser vazio.", nameof(propostaId));

            Id = Guid.NewGuid();
            PropostaId = propostaId;
            DataContratacao = dataContratacao;
        }
    }
}