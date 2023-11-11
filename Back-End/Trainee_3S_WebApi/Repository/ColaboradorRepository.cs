using Trainee_3S_WebApi.Domains;
using Trainee_3S_WebApi.Contexts;
using Trainee_3S_WebApi.ViewModel;

namespace Trainee_3S_WebApi.Repository
{
    public class ColaboradorRepository
    {
        public List<Colaboradore> GetAll()
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                return dbContext.Colaboradores.ToList();
            }
        }

        public Colaboradore? GetById(int id)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                return dbContext.Colaboradores.Where(c => c.IdUsuario == id).FirstOrDefault();
            }
        }

        public void Save(ColaboradorViewModel colaborador)
        {
            UserRepository usuarioRepository = new UserRepository();
            Usuario user = new Usuario();
            user.Email = colaborador.Email;
            user.Senha = colaborador.Senha;
            user.IdTipoUsuario = 2;
            var userId = usuarioRepository.Save(user);
            using (Access3SContext dbContext = new Access3SContext())
            {
                Colaboradore c = new Colaboradore();
                c.Nome = colaborador.Nome;
                c.Pontos = new List<Ponto>();
                c.IdSetor = colaborador.IdSetor;
                c.IdUsuario = userId;
                c.IsAdmin = c.IsAdmin;
                dbContext.Colaboradores.Add(c);
                dbContext.SaveChanges();
            }
        }

        public void Update(Usuario user, int id)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                var usuarioEncontrado = dbContext.Colaboradores.Where(c => c.IdUsuario == id).FirstOrDefault();
                if (usuarioEncontrado != null)
                {
                    dbContext.Colaboradores.Update(usuarioEncontrado);
                    dbContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                var usuario = dbContext.Colaboradores.Where(c => c.IdUsuario == id).FirstOrDefault();
                if (usuario != null)
                {
                    dbContext.Colaboradores.Remove(usuario);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}

