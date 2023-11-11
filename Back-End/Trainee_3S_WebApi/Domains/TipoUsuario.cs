namespace Trainee_3S_WebApi.Domains
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public TipoUsuario() { }
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public TipoUsuario(int id, string titulo) {
            Id = id;
            Titulo = titulo;
        }
    }
}
