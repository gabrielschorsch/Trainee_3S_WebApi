namespace Trainee_3S_WebApi.Domains
{
    public class AcessoEspaco
    {   
        public int Id { get; set; }
        public int IdUsuario{ get; set; }
        public int IdEspaco { get; set; }

        public Espaco Espaco { get; set; }
        public Usuario Usuario {  get; set; }
        public AcessoEspaco() { }
    }
}
