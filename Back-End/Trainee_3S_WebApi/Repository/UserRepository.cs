using Trainee_3S_WebApi.Contexts;
using Trainee_3S_WebApi.Domains;

namespace Trainee_3S_WebApi.Repository
{
    public class UserRepository
    {
        public List<Usuario> GetUsers()
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                return dbContext.Usuarios.ToList();
            }
        }

        public Usuario? GetUserById(int id)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                return dbContext.Usuarios.Where(c => c.IdUsuario == id).FirstOrDefault();
            }
        }

        public int Save(Usuario user)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                var entity = dbContext.Usuarios.Add(user);
                dbContext.SaveChanges();
                return user.IdUsuario;
            }
        }

        public void Update(Usuario user, int id)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                var usuarioEncontrado = dbContext.Usuarios.Where(c => c.IdUsuario == id).FirstOrDefault();
                if(usuarioEncontrado != null)
                {
                    usuarioEncontrado.IdTipoUsuario = user.IdTipoUsuario;
                    usuarioEncontrado.Email = user.Email;
                    dbContext.Usuarios.Update(usuarioEncontrado);
                    dbContext.SaveChanges();
                }
            }
        }

        public void Delete(int id) { 
            using(Access3SContext dbContext = new Access3SContext())
            {
                var usuario = dbContext.Usuarios.Where(c => c.IdUsuario == id).FirstOrDefault();
                if(usuario != null)
                {
                    dbContext.Usuarios.Remove(usuario);
                    dbContext.SaveChanges();
                }
            }
        }

        public Usuario? GetByEmailAndPassword(string email, string password)
        {
            using (Access3SContext dbContext = new Access3SContext())
            {
                return dbContext.Usuarios.Where(c => c.Email == email).Where(c => c.Senha == password).FirstOrDefault();
            }
        }
    }
}
