namespace Trainee_3S_WebApi.Domains
{
    public class Ponto
    {
        public string Id { get; set; }
        public int IdColaborador { get; set; }
        public Colaborador Colaborador { get; set; }
        public DateTime HorarioPonto { get; set; }
        



    }
}
