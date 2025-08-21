namespace Contratacao.Domain.Entities
{
    public class Proposta
    {
        public Guid Id { get; private set; }
        public string Status { get; private set; }

        public Proposta(Guid id, string status)
        {
            Id = id;
            Status = status;
        }

        public bool PodeSerContratada()
        {
            return Status == "Aprovada";
        }
        public void Contratar()
        {
            if (!PodeSerContratada())
            {
                throw new InvalidOperationException("A proposta não pode ser contratada.");
            }
            Status = "Contratada";
        }
    }
}
