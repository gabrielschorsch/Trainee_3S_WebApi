namespace Trainee_3S_WebApi.Domains
{
    public class Colaborador
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int SetorId { get; set; }

        public Setor Setor { get; set; }
        public Colaborador() { }

    }
}
