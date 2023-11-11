namespace Trainee_3S_WebApi.Domains
{
    public class Espaco
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<AcessoEspaco> Acessos { get; set; }

        public Espaco()
        {

        }
    }
}
