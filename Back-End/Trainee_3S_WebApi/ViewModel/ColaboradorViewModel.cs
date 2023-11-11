namespace Trainee_3S_WebApi.ViewModel
{
    public class ColaboradorViewModel
    {
        public int IdColaborador { get; set; }

        public int IdUsuario { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int? IdSetor { get; set; }

        public string Nome { get; set; } = null!;

        public bool IsAdmin { get; set; }
    }
}
