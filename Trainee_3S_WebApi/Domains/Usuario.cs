namespace Trainee_3S_WebApi.Domains
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }

        public int TipoUsuarioId { get; set; }

        public TipoUsuario Tipo { get; set; }

        public ICollection<AcessoEspaco> AcessoEspacos { get; set; }

        public Usuario() { }

       

    }
}
